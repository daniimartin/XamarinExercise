using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PracticaXamarin.Models
{
    public class Apuesta
    {
        [JsonProperty("Usuario")]
        public String Usuario { get; set; }
        [JsonProperty("Resultado")]
        public String Resultado { get; set; }

    }
}
