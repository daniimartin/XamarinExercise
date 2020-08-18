using PracticaXamarin.Helpers;
using PracticaXamarin.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace PracticaXamarin.ViewModels
{
    public class EquiposViewModel : ViewModelBase
    {
        private HelperAzureApuestas helper;

        public EquiposViewModel()
        {
            helper = new HelperAzureApuestas();
            Task.Run(async () => {
                List<Equipo> lista = await helper.GetEquipos();
                this.Equipos = new ObservableCollection<Equipo>(lista);
            });
        }

        private ObservableCollection<Equipo> _Equipos;

        public ObservableCollection<Equipo> Equipos
        {
            get { return this._Equipos; }
            set
            {
                this._Equipos = value;
                OnPropertyChanged("Equipos");
            }
        }
    }
}
