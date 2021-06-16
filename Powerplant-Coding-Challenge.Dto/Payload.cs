using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Powerplant_Coding_Challenge.Dto
{
    public class Payload
    {
        /// <summary>
        /// load: The load is the amount of energy (MWh) that need to be generated during one hour.
        /// </summary>
        [JsonPropertyName("load")]
        public int Load { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("fuels")]
        public Fuels Fuels { get; set; }

        [JsonPropertyName("powerplants")]
        public List<Powerplant> Powerplants { get; set; }
    }
}
