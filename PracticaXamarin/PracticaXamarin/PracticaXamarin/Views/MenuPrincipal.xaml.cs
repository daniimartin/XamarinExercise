using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PracticaXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPrincipal : MasterDetailPage
    {

        public List<MasterPage> menu { get; set; }

        public MenuPrincipal()
        {
            InitializeComponent();
            menu = new List<MasterPage>();
            var page1 = new MasterPage() { Titulo = "Equipos", PaginaHija = typeof(EuiposView) };
            var page2 = new MasterPage() { Titulo = "Apuestas realizadas", PaginaHija = typeof(ApuestasView) };
            var page3 = new MasterPage() { Titulo = "Realizar apuesta", PaginaHija = typeof(RealizarApuestaView) };
            menu.Add(page1);
            menu.Add(page2);
            menu.Add(page3);
            this.lsvmenu.ItemsSource = menu;
            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(MainPage)));
            this.lsvmenu.ItemSelected += ListView_ItemSelected;

        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = (MasterPage)e.SelectedItem;
            Type page = item.PaginaHija;

            Detail = new NavigationPage((Page)Activator.CreateInstance(page));
            IsPresented = false;
        }
    }
}