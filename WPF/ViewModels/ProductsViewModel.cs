using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.Helpers;
using WPF.Models;
using WPF.Services;

namespace WPF.ViewModels
{
    public class ProductsViewModel : BindableBase
    {
        private readonly IProductService _productService;
        private readonly IEventAggregator _eventAggregator;
        private readonly IRegionManager _regionManager;
        public DelegateCommand Exit { get; set; }
        public DelegateCommand AddProduct { get; set; }

        public ProductsViewModel(IProductService productService ,IEventAggregator eventAggregator,
            IRegionManager regionManager)
        {
            _productService = productService;
            _eventAggregator = eventAggregator;
            _regionManager = regionManager;
            _eventAggregator.GetEvent<SendShopInformationEvent>().Subscribe(ActualShop);
            Exit = new DelegateCommand(Back);
            AddProduct = new DelegateCommand(AddNewProduct);
        }

        private void AddNewProduct()
        {
            _regionManager.RequestNavigate("MainRegion", "AddProductView");
            _eventAggregator.GetEvent<SendShopInformationEvent>().Publish(Shop);
        }

        private void Back()
        {
            var view = _regionManager.Regions.Where(x => x.Name == "MainRegion").Single().ActiveViews.First();
            _regionManager.Regions.Where(x => x.Name == "MainRegion").Single().Remove(view);
        }

        private ObservableCollection<Product> products;

        public ObservableCollection<Product> Products
        {
            get { return products; }
            set 
            {
                products = value; 
                this.RaisePropertyChanged(nameof(this.Products));
            }
        }

        public Shop Shop { get; set; }
        private void ActualShop(Shop sended)
        {
            Shop = sended;
            Products = new ObservableCollection<Product>(_productService.GetProducts(Shop.Id));
        }
    }
}
