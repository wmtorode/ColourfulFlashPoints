using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ColourfulFlashPoints.Data;

namespace ColourfulFlashPoints
{
    class FlashPointController
    {
        private static FlashPointController instance;
        public static FlashPointController Instance
        {
            get
            {
                if (instance == null) instance = new FlashPointController();
                return instance;
            }
        }

        public bool useHmAnimation(string fpId)
        {
            FpMarker marker = findMarker(fpId);
            if (marker != null)
            {
                return marker.useHmAnimation;
            }
            return false;
        }

        public FpMarker findMarker(string fpId)
        {
            foreach (FpMarker marker in Main.settings.markers)
            {
                if (fpId.StartsWith(marker.flashpointPrefix))
                {
                    return marker;
                }
            }
            return (FpMarker)null;
        }

        private string getFpPrefix(string contractId)
        {
            return contractId.TrimStart('c', '_');
        }

        public bool useHmContractElement(string contractId)
        {
            FpMarker marker = findMarker(getFpPrefix(contractId));
            if (marker != null)
            {
                return marker.useHmAnimation;
            }
            return false;
        }

        public bool contractHasFpMarker(string contractId)
        {
            FpMarker marker = findMarker(getFpPrefix(contractId));
            if (marker != null)
            {
                return true;
            }
            return false;
        }

    }
}
