using Newtonsoft.Json;
using UnityEngine;

namespace ColourfulFlashPoints.Data
{
    public class ColourValue
    {
        public string Colour = "#FFFFFF";
        public float Alpha = 1.0f;
        public float I = 1.0f;

        [JsonIgnore] 
        private Color cachedColour;

        [JsonIgnore] 
        private bool colourSet = false;


        public Color GetColor()
        {
            if (!colourSet)
            {
                ColorUtility.TryParseHtmlString(Colour, out cachedColour);
                cachedColour.a = Alpha;
                cachedColour.r *= I;
                cachedColour.g *= I;
                cachedColour.b *= I;
                colourSet = true;
            }
            
            return cachedColour;
        }
    }
}
