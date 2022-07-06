using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.Helpers;
using WPF.Models;
using WPF.Services;

namespace WPF.ViewModels
{
    public class AddProductViewModel : BindableBase
    {
        private readonly IProductService _productService;
        private readonly IEventAggregator _eventAggregator;
        private readonly IRegionManager _regionManager;
        public DelegateCommand Exit { get; set; }

        public DelegateCommand AddNewProduct { get; set; }

        public AddProductViewModel(IProductService productService, IEventAggregator eventAggregator,
            IRegionManager regionManager)
        {
            _productService = productService;
            _eventAggregator = eventAggregator;
            _regionManager = regionManager;
            _eventAggregator.GetEvent<SendShopInformationEvent>().Subscribe(ActualShop);
            AddNewProduct = new DelegateCommand(AddProduct);
            Exit = new DelegateCommand(Back);
        }

        private void AddProduct()
        {
            _productService.AddProduct(new Product()
            {
                Name = this.Name,
                Quantity = this.Quantity,
                Price = this.Price,
                LastUpdateTime = DateTime.Now,
                ShopId = this.Shop.Id
            });
            Back();
        }

        public Shop Shop { get; private set; }

        private void ActualShop(Shop sended)
        {
            Shop = sended;
        }
        private string name;

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                this.RaisePropertyChanged(nameof(this.CanAdd));
            }
        }
        private int quantity;

        public int Quantity
        {
            get { return quantity; }
            set
            {
                quantity = value;
                this.RaisePropertyChanged(nameof(this.CanAdd));
            }
        }
        private decimal price;

        public decimal Price
        {
            get { return price; }
            set
            {
                price = value;
                this.RaisePropertyChanged(nameof(this.CanAdd));
            }
        }
        public bool CanAdd => !string.IsNullOrEmpty(Name);
        private void Back()
        {
            var view = _regionManager.Regions.Where(x => x.Name == "MainRegion").Single().Views.Last();
            _regionManager.Regions.Where(x => x.Name == "MainRegion").Single().Remove(view);
        }
    }
}
