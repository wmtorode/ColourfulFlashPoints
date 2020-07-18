using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Harmony;
using BattleTech;

using UnityEngine;
using System.IO;


namespace ColourfulFlashPoints.Patches
{
    [HarmonyPatch(typeof(FlashpointDef), "get_isHeavyMetalCampaign")]
    class FlashpointDef_GetisHeavyMetalCampaign_Patch
    {
        static void Postfix(FlashpointDef __instance, ref bool __result)
        {
            if(!__result)
            {
                __result = FlashPointController.Instance.useHmAnimation(__instance.Description.Id);
            }
        }
    }
}
