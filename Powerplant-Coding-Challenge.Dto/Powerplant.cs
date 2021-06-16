using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Powerplant_Coding_Challenge.Dto
{
    public class Powerplant
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("efficiency")]
        public decimal Efficiency { get; set; }

        [JsonPropertyName("pmin")]
        public int Pmin { get; set; }

        [JsonPropertyName("pmax")]
        public int Pmax { get; set; }
    }
}
