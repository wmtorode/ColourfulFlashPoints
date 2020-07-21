using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ColourfulFlashPoints.Data
{
    class FpMarker
    {
        public bool useHmAnimation = false;
        public string flashpointPrefix = "";
        public bool swapColour = false;
        public bool keepAlpha = true;
        public bool useOnlyInner = true;
        public bool autoDetectContracts = true;
        public bool useContractColourOverride = false;
        public ColourValue contractColour = new ColourValue();
        public ColourValue innerCircle = new ColourValue();
        public ColourValue dottedHmRing = new ColourValue();
        public ColourValue innerHmPulsing = new ColourValue();
        public ColourValue outerCircle = new ColourValue();
        public ColourValue outerPulsing = new ColourValue();
        public ColourValue outerPulsingFill = new ColourValue();
        public List<string> contractIds = new List<string>();

        public Color GetColor(string componentName, float currentAlpha)
        {
            Color color = innerCircle.GetColor();
            if (!useOnlyInner)
            {
                switch (componentName)
                {
                    case "rotatingCircleDotted":
                        color = dottedHmRing.GetColor();
                        break;
                    case "innerCirclePulsing":
                        color = innerHmPulsing.GetColor();
                        break;
                    case "outerCircle":
                        color = outerCircle.GetColor();
                        break;
                    case "outerCirclePulsing":
                        color = outerPulsing.GetColor();
                        break;
                    case "outerCirclePulsing2":
                    case "outerCirclePulsingFill":
                        color = outerPulsingFill.GetColor();
                        break;
                    default:
                        color = innerCircle.GetColor();
                        break;
                }
            }

            if (keepAlpha)
            {
                color.a = currentAlpha;
            }
            return color;
        }
    }
}
