using System;
using Harmony;
using UnityEngine;
using BattleTech;

namespace ColourfulFlashPoints.Patches
{

    [HarmonyPatch(typeof(UnityGameInstance), "Update")]
    class UnityGameInstance_Update
    {
        public static bool Prepare()
        {
            return Main.settings.enableSettingsHotReload;
        }

        public static void Postfix()
        {
            if (Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.LeftAlt) &&
                Input.GetKeyDown(KeyCode.X))
            {
                Main.modLog.LogMessage("Performing Setting Hot Reload!");
                Main.ReloadSettings();
            }
        }
    }
}
