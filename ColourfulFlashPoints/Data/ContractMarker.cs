using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ColourfulFlashPoints.Data
{
    class ContractMarker
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public EContractTargetType type = EContractTargetType.ContractType;
        public string target;
        public bool preserveAlpha = true;
        public ColourValue colour;
    }
}
