using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaXamarin.Views
{

    public class MenuPrincipalMenuItem
    {
        public MenuPrincipalMenuItem()
        {
            TargetType = typeof(MenuPrincipalDetail);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}