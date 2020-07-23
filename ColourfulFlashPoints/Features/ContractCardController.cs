using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ColourfulFlashPoints.Data;
using BattleTech;
using UnityEngine;
using BattleTech.UI;

namespace ColourfulFlashPoints
{
    class ContractCardController
    {

        private static ContractCardController instance;
        public List<SGContractsListItem> lastContractSet = null;
        private Color Fallback = new Color(0.149020f, 0.152941f, 0.168627f, 1.0f);
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
            // Fallback colour, same as game default
            color = new Color(0.149020f, 0.152941f, 0.168627f, 1.0f);
            foreach (ContractMarker marker in Main.settings.contractMarkers)
            {
                if (marker.EvaluateMarker(contract))
                {
                    color = marker.GetColor();
                    return true;
                }
            }

            return true;
        }

    }
}
