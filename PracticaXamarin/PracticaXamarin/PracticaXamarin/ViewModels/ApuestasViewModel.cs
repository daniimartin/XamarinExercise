using PracticaXamarin.Helpers;
using PracticaXamarin.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace PracticaXamarin.ViewModels
{
    public class ApuestasViewModel : ViewModelBase
    {

        private HelperAzureApuestas helper;

        public ApuestasViewModel()
        {
            helper = new HelperAzureApuestas();
            Task.Run(async () => {
                List<Apuesta> lista = await helper.GetApuestas();
                this.Apuestas = new ObservableCollection<Apuesta>(lista);
            });
        }

        private ObservableCollection<Apuesta> _Apuestas;

        public ObservableCollection<Apuesta> Apuestas
        {
            get { return this._Apuestas; }
            set
            {
                this._Apuestas = value;
                OnPropertyChanged("Apuestas");
            }
        }
    }
}
