using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ColourfulFlashPoints.Data;
using BattleTech;
using UnityEngine;

namespace ColourfulFlashPoints
{
    class ContractCardController
    {
        private static ContractCardController instance;
        public static ContractCardController Instance
        {
            get
            {
                if (instance == null) instance = new ContractCardController();
                return instance;
            }
        }

        public bool getContractColour(Contract contract, out Color color)
        {
            color = new Color();
            foreach (ContractMarker marker in Main.settings.contractMarkers)
            {
                if (marker.EvaluateMarker(contract))
                {
                    color = marker.GetColor();
                    return true;
                }
            }

            return false;
        }

    }
}
