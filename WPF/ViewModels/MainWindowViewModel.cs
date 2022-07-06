using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using System.Collections.ObjectModel;
using System.Linq;
using WPF.Helpers;
using WPF.Models;
using WPF.Services;
using WPF.Views;

namespace WPF.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private readonly IRegionManager _regionManager;
        private readonly IShopService _shopService;
        private readonly IEventAggregator _eventAggregator;

        public DelegateCommand AddNewShop { get; set; }
        public DelegateCommand ProductsV { get; set; }
        public MainWindowViewModel(IRegionManager regionManager,
            IShopService shopService, IEventAggregator eventAggregator)
        {
            _regionManager = regionManager;
            _shopService = shopService;
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<UpdateShopsEvent>().Subscribe(UpdateShopList);
            AddNewShop = new DelegateCommand(AddShop);
            ProductsV = new DelegateCommand(GoToProducts);
            Shops = new ObservableCollection<Shop>(_shopService.GetShops().AsEnumerable());
        }
        private ObservableCollection<Shop> shops;
        public ObservableCollection<Shop> Shops
        {
            get
            {
                return shops;
            }
            set
            {
                shops = value;
                this.RaisePropertyChanged(nameof(this.ShopsString));
            }
        }
        public ObservableCollection<string> ShopsString =>
                new ObservableCollection<string>(shops.Select(x => $"{x.Name} {x.Adress.City} {x.Adress.StreetAddress}"));

        private int selected;

        public int Selected
        {
            get { return selected; }
            set
            {
                selected = value;
                this.RaisePropertyChanged(nameof(this.CanConfirm));
            }
        }

        public bool CanConfirm => Selected != -1;
        private void AddShop()
        {
            Navigate(nameof(AddShopView));
        }
        private void Navigate(string navigatePath)
        {
            if (navigatePath != null)
                _regionManager.RequestNavigate("MainRegion", navigatePath);
        }
        void UpdateShopList()
        {
            Shops = new ObservableCollection<Shop>(_shopService.GetShops().AsEnumerable());
        }
        void GoToProducts()
        {
            Navigate(nameof(ProductsView));
            _eventAggregator.GetEvent<SendShopInformationEvent>().Publish(Shops[Selected]);
        }

    }
}
