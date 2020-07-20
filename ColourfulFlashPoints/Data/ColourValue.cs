using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ColourfulFlashPoints.Data
{
    class ColourValue
    {
        public string Colour = "#FFFFFF";
        public float Alpha = 1.0f;
        public float I = 1.0f;


        public Color GetColor()
        {
            Color color;
            ColorUtility.TryParseHtmlString(Colour, out color);
            color.a = Alpha;
            color.r *= I;
            color.g *= I;
            color.b *= I;
            return color;
        }
    }
}
