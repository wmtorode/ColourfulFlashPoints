using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ColourfulFlashPoints.Data
{
    class Settings
    {
        public bool debug = false;
        public bool enableSettingsHotReload = false;
        public List<FpMarker> markers = new List<FpMarker>();
        public List<ContractMarker> contractMarkers = new List<ContractMarker>();
        [JsonIgnore]
        public Dictionary<string, MapMarker> mapMarkers = new Dictionary<string, MapMarker>();
    }
}
