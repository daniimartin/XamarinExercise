using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PracticaXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPrincipalMaster : ContentPage
    {
        public ListView ListView;

        public MenuPrincipalMaster()
        {
            InitializeComponent();

            BindingContext = new MenuPrincipalMasterViewModel();
            ListView = MenuItemsListView;
        }

        class MenuPrincipalMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<MenuPrincipalMenuItem> MenuItems { get; set; }
            
            public MenuPrincipalMasterViewModel()
            {
                MenuItems = new ObservableCollection<MenuPrincipalMenuItem>(new[]
                {
                    new MenuPrincipalMenuItem { Id = 0, Title = "Page 1" },
                    new MenuPrincipalMenuItem { Id = 1, Title = "Page 2" },
                    new MenuPrincipalMenuItem { Id = 2, Title = "Page 3" },
                    new MenuPrincipalMenuItem { Id = 3, Title = "Page 4" },
                    new MenuPrincipalMenuItem { Id = 4, Title = "Page 5" },
                });
            }
            
            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}