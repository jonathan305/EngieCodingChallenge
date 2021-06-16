using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Powerplant_Coding_Challenge.Dto
{
    public class Fuels
    {
        [JsonPropertyName("gas(euro/MWh)")]
        public decimal GasEuroMWh { get; set; }

        [JsonPropertyName("kerosine(euro/MWh)")]
        public decimal KerosineEuroMWh { get; set; }

        [JsonPropertyName("co2(euro/ton)")]
        public int Co2EuroTon { get; set; }

        [JsonPropertyName("wind(%)")]
        public int Wind { get; set; }
    }
}
