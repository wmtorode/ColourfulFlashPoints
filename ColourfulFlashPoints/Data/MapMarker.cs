﻿namespace ColourfulFlashPoints.Data
{
    public class MapMarker
    {
        public string systemName;
        public FpMarker marker;

        public MapMarker()
        {
            systemName = "";
            marker = new FpMarker();
        }
        public MapMarker(string system, FpMarker settings)
        {
            systemName = system;
            marker = settings;
        }
    }
}