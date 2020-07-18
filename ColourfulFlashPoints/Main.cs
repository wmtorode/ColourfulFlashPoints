using System;
using System.IO;
using Newtonsoft.Json;
using ColourfulFlashPoints.Data;
using Harmony;
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

            var harmony = HarmonyInstance.Create("ca.jwolf.ColourfulFlashPoints");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }
    }
}
