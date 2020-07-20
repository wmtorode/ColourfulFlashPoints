using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColourfulFlashPoints.Data
{
    class Settings
    {
        public bool debug = false;
        public List<FpMarker> markers = new List<FpMarker>();
        public List<ContractMarker> contractMarkers = new List<ContractMarker>();
    }
}
