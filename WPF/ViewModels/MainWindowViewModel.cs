using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using WPF.Helpers;
using WPF.Services;
using WPF.Views;

namespace WPF.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private readonly IRegionManager _regionManager;
        private readonly IShopService _shopService;

        public DelegateCommand AddNewShop { get; set; }
        public MainWindowViewModel(IRegionManager regionManager,
            IShopService shopService, IEventAggregator ea)
        {
            _regionManager = regionManager;
            _shopService = shopService;
            ea.GetEvent<UpdateShopsEvent>().Subscribe(UpdateShopList);
            AddNewShop = new DelegateCommand(AddShop);
            Shops = new ObservableCollection<string>(_shopService.GetShops().Select(x => $"{x.Name} {x.Adress.City} {x.Adress.StreetAddress}").ToList());
        }
        private ObservableCollection<string> shops;
        public ObservableCollection<string> Shops
        {
            get { return shops; }
            set 
            {
                shops = value; 
                this.RaisePropertyChanged(nameof(this.Shops));
            }
        }
        private string selected;

        public string Selected
        {
            get { return selected; }
            set 
            {
                selected = value;
                this.RaisePropertyChanged(nameof(this.CanConfirm));
            }
        }

        public bool CanConfirm => !string.IsNullOrEmpty(Selected);
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
            Shops = new ObservableCollection<string>(_shopService.GetShops().Select(x => $"{x.Name} {x.Adress.City} {x.Adress.StreetAddress}").ToList());
        }

    }
}
