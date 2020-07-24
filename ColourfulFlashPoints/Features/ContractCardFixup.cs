using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleTech;
using UnityEngine;
using UnityEngine.UI;

namespace ColourfulFlashPoints
{
    class ContractCardFixup : MonoBehaviour
    {
        private Color fixupColour;
        private Image bgsFill = null;

        public void setUp(Image bgFill)
        {
            bgsFill = bgFill;
        }

        public void setColour(Color color)
        {
            fixupColour = color;
        }

        void Update()
        {
            if (bgsFill != null)
            {
                if (bgsFill.color != fixupColour)
                {
                    bgsFill.color = fixupColour;
                }
            }
        }
    }
}
