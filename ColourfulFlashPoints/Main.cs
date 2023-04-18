using System;
using System.IO;
using Newtonsoft.Json;
using ColourfulFlashPoints.Data;
using System.Reflection;

namespace ColourfulFlashPoints
{
    public class Main
    {
        internal static Logger modLog;
        internal static Settings settings;
        internal static string modDir;

        public static void Init(string modDirectory, string settingsJSON)
        {

            modDir = modDirectory;
            modLog = new Logger(modDir, "ColourfulFlashpoints", true);

            ReloadSettings();
            
            Harmony.CreateAndPatchAll(Assembly.GetExecutingAssembly(), "ca.jwolf.ColourfulFlashPoints");
        }

        public static void ReloadSettings()
        {
            try
            {
                using (StreamReader reader = new StreamReader($"{modDir}/settings.json"))
                {
                    string jdata = reader.ReadToEnd();
                    settings = JsonConvert.DeserializeObject<Settings>(jdata);
                }

            }
            catch (Exception ex)
            {
                modLog.LogException(ex);
            }
        }

        public static void addMapMarker(MapMarker marker)
        {
            settings.mapMarkers[marker.systemName] = marker;
        }

        public static void clearMapMarkers()
        {
            settings.mapMarkers.Clear();
        }
    }
}
