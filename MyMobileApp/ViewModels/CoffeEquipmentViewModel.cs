using MvvmHelpers;
using MvvmHelpers.Commands;
using MyMobileApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
//using Xamarin.Forms.PlatformConfiguration.AndroidSpecific.AppCompat;
//using Xamarin.Forms.PlatformConfiguration.AndroidSpecific.AppCompat;
//using static System.Net.Mime.MediaTypeNames;
using Xamarin.Forms;

namespace MyMobileApp.ViewModels
{
    public class CoffeeEquipmentViewModel : ViewModelBase
    {
        public AsyncCommand RefreshCommand { get; }
        public AsyncCommand<Coffee> FavoriteCommand { get; }
        public ObservableRangeCollection<Coffee> Coffee { get; set; }
        public ObservableRangeCollection<Grouping<string, Coffee>> CoffeeGroups { get; set; }
        public CoffeeEquipmentViewModel()
        {
            Title = "Coffee Equipment";
            RefreshCommand = new AsyncCommand(Refresh);
            FavoriteCommand = new AsyncCommand<Coffee>()
            Coffee = new ObservableRangeCollection<Coffee>();
            CoffeeGroups = new ObservableRangeCollection<Grouping<string, Coffee>>();

            var image = "silhouette.png";

            Coffee.Add(new Coffee { Roaster = "Jacobs", Name = "Barista", Image = image });
            Coffee.Add(new Coffee { Roaster = "Jacobs", Name = "Strong", Image = image });
            Coffee.Add(new Coffee { Roaster = "New Brasilia", Name = "Горчиво", Image = image });
            Coffee.Add(new Coffee { Roaster = "Tchibo", Name = "Средна хубост", Image = image });
            Coffee.Add(new Coffee { Roaster = "Кафето на Ангел", Name = "Залез в кухнята", Image = image });
            Coffee.Add(new Coffee { Roaster = "Кафето на Ангел", Name = "Кафето на програмиста", Image = image });
            Coffee.Add(new Coffee { Roaster = "Английско кафе", Name = "Кана буламач", Image = image });

            CoffeeGroups.Add(new Grouping<string, Coffee>("Английско кафе", new[] { Coffee[6]}));
            CoffeeGroups.Add(new Grouping<string, Coffee>("Кафето на Ангел", new[] { Coffee[4], Coffee[5] }));
            CoffeeGroups.Add(new Grouping<string, Coffee>("Jacobs", Coffee.Take(2)));
            CoffeeGroups.Add(new Grouping<string, Coffee>("New Brasilia", new[] { Coffee[2] }));
            CoffeeGroups.Add(new Grouping<string, Coffee>("Tchibo", new[] { Coffee[3] }));

        }
        Coffee previoslySelected;
        Coffee selectedCoffee;
        public Coffee SelectedCoffee 
        {
            get => selectedCoffee;
            set
            {
                if (value != null)
                {
                    Application.Current.MainPage.DisplayAlert("Избрано", value.Name, "Ok");
                    previoslySelected = value;
                    value = null;
                }
                selectedCoffee = value;
                OnPropertyChanged();
            }
        }

        async Task Refresh()
        {
            IsBusy = true;
            await Task.Delay(2000);
            IsBusy = false;
        }

       
    }
}
