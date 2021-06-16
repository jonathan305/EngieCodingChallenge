using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Powerplant_Coding_Challenge.Dto
{
    public class PowerplantProductionResponse
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("p")]
        public decimal P { get; set; }

        public PowerplantProductionResponse(string name, int p)
        {
            this.Name = name;
            this.P = p;
        }
    }
}
