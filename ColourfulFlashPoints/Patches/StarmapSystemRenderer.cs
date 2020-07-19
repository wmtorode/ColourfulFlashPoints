using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Harmony;
using BattleTech;
using UnityEngine;

namespace ColourfulFlashPoints.Patches
{
    [HarmonyPatch(typeof(StarmapSystemRenderer), "SetFlashpointAvailable")]
    class StarmapSystemRenderer_SetFlashpointAvailable
    {
        static void Postfix(StarmapSystemRenderer __instance)
        {
            if (__instance.flashpointAvailableLocal != null)
            {
                foreach (ParticleSystemRenderer componentsInChild in __instance.flashpointAvailableLocal.GetComponentsInChildren<ParticleSystemRenderer>())
                {
                    Main.modLog.LogMessage(" " + componentsInChild.name + ": materials");
                    foreach (Material material in componentsInChild.materials)
                    {
                        Main.modLog.LogMessage("Material: " + material.name);
                        Color color;
                        ColorUtility.TryParseHtmlString("#FF00FF", out color);
                        color.a = 1f;
                        color.r *= 5f;
                        color.g *= 5f;
                        color.b *= 5f;
                        material.SetColor("_ColorBB", color);
                        material.SetColor("_Color", color);
                        try
                        {
                            material.SetColor("_TintColor", color);
                            material.SetColor("_EmisColor", color);
                        }
                        catch { }
                    }
                }
            }
        }
    }
}
