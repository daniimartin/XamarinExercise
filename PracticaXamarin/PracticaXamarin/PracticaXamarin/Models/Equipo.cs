using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PracticaXamarin.Models
{
    public class Equipo
    {
        [JsonProperty("IDEQUIPO")]
        public String IdEquipo { get; set; }
        [JsonProperty("NOMBRE")]
        public String Nombre { get; set; }
        [JsonProperty("IMAGEN")]
        public String Imagen { get; set; }
        [JsonProperty("CHAMPIONS")]
        public int Champions { get; set; }

    }
}
