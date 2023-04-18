using UnityEngine;
using UnityEngine.UI;

namespace ColourfulFlashPoints
{
    class ContractCardFixup : MonoBehaviour
    {
        private Color fixupColour;
        private Image bgsFill = null;
        private bool bgsSet = false;

        public void setUp(Image bgFill)
        {
            bgsFill = bgFill;
            bgsSet = true;
        }

        public void setColour(Color color)
        {
            fixupColour = color;
        }

        void Update()
        {
            if (bgsSet)
            {
                if (bgsFill.color != fixupColour)
                {
                    bgsFill.color = fixupColour;
                }
            }
        }
    }
}
