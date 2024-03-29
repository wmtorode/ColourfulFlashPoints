﻿using ColourfulFlashPoints.Data;
using UnityEngine;

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

        public FpMarker findMarkerForContract(string contractId)
        {
            FpMarker marker = findMarker(getFpPrefix(contractId));
            if (marker != null)
            {
                if (marker.autoDetectContracts)
                {
                    return marker;
                }
            }
            foreach(FpMarker fpMarker in Main.settings.markers)
            {
                foreach(string cId in fpMarker.contractIds)
                {
                    if (cId == contractId)
                    {
                        return fpMarker;
                    }
                }
            }
            return (FpMarker)null;
        }

        public bool getFlashpointContractColour(string contractId, bool HmColour, out Color color)
        {
            color = new Color(0.521569f, 0.858824f, 0.964706f, 0.062745f);
            if (HmColour)
            {
                color = new Color(0.368627f, 0.792157f, 0.635294f, 0.250980f);
            }
            FpMarker marker = findMarkerForContract(contractId);
            if (marker != null)
            {
                if(marker.swapColour)
                {
                    color = marker.GetColor(FpMarker.ContractFillerName, 1.0f);
                    return true;
                }
            }
            return true;
        }

        private string getFpPrefix(string contractId)
        {
            return contractId.TrimStart('c', '_');
        }

        public bool useHmContractElement(string contractId)
        {
            FpMarker marker = findMarkerForContract(contractId);
            if (marker != null)
            {
                return marker.useHmAnimation;
            }
            return false;
        }

        public bool contractHasFpMarker(string contractId)
        {
            FpMarker marker = findMarkerForContract(contractId);
            if (marker != null)
            {
                return true;
            }
            return false;
        }

    }
}
