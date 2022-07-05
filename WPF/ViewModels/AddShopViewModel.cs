using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.Models;
using WPF.Services;

namespace WPF.ViewModels
{
    public class AddShopViewModel : BindableBase
    {
        public DelegateCommand AddNewShop { get; set; }
        public AddShopViewModel(IRegionManager regionManager, IShopService shopService)
        {
            _regionManager = regionManager;
            _shopService = shopService;
            AddNewShop = new DelegateCommand(AddShop);
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

        private string city;

        public string City
        {
            get { return city; }
            set 
            {
                city = value;
                this.RaisePropertyChanged(nameof(this.CanAdd));
            }
        }
        private string streetadress;

        public string StreetAdress
        {
            get { return streetadress; }
            set 
            {
                streetadress = value;
                this.RaisePropertyChanged(nameof(this.CanAdd));
            }
        }
        private string zipcode;
        private readonly IRegionManager _regionManager;
        private readonly IShopService _shopService;

        public string ZipCode
        {
            get { return zipcode; }
            set 
            {
                zipcode = value;
                this.RaisePropertyChanged(nameof(this.CanAdd));
            }
        }
        public bool CanAdd => !string.IsNullOrEmpty(Name) &&
            !string.IsNullOrEmpty(City) &&
            !string.IsNullOrEmpty(StreetAdress) &&
            !string.IsNullOrEmpty(ZipCode);

        public void AddShop()
        {
            var shop = new Shop()
            {
                Name = this.Name,
                Adress = new Adress()
                {
                    City = this.City,
                    StreetAddress = this.StreetAdress,
                    ZipCode = this.ZipCode
                }
            };
            _shopService.AddShop(shop);
            var view = _regionManager.Regions.Where(x => x.Name == "MainRegion").Single().ActiveViews.First();
            _regionManager.Regions.Where(x => x.Name == "MainRegion").Single().Remove(view);
        }

    }
}
