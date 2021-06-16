using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Harmony;
using BattleTech;
using BattleTech.UI;
using UnityEngine;
using ColourfulFlashPoints.Data;

namespace ColourfulFlashPoints.Patches
{

    [HarmonyPatch(typeof(SGNavigationScreen), "GetSystemFlashpoint", typeof(Flashpoint))]
    class SGNavigationScreen_GetSystemFlashpoint
    {
        static void Postfix(SGNavigationScreen __instance, Flashpoint flashpoint, ref StarmapSystemRenderer __result)
        {
            if(flashpoint.CurStatus == Flashpoint.Status.AVAILABLE || flashpoint.CurStatus == Flashpoint.Status.SELECTED_ENROUTE)
            {
                GameObject prefab = null;
                if (flashpoint.Def.isHeavyMetalCampaign)
                {
                    if (__result.flashpointMiniCampaignLocal != null)
                    {
                        prefab = __result.flashpointMiniCampaignLocal;
                    }
                }
                else
                {
                    if (__result.flashpointAvailableLocal != null)
                    {
                        prefab = __result.flashpointAvailableLocal;
                    }
                }

                if (prefab != null)
                {
                    FpMarker marker = FlashPointController.Instance.findMarker(flashpoint.Def.Description.Id);
                    if (marker != null && marker.swapColour)
                    {
                        foreach (ParticleSystem componentsInChild in prefab.GetComponentsInChildren<ParticleSystem>())
                        {
                            //Main.modLog.LogMessage(" " + componentsInChild.name + ": pr");
                            var main = componentsInChild.main;
                            var colorGrad = main.startColor;
                            Color color = marker.GetColor(componentsInChild.name, colorGrad.colorMax.a);
                            colorGrad.colorMax = color;
                            main.startColor = colorGrad;
                        }
                    }
                }
            }
        }
    }

    [HarmonyPatch(typeof(SGNavigationScreen), "ShowFlashpointSystems")]
    class SGNavigationScreen_ShowFlashpointSystems
    {
        static void Postfix(SGNavigationScreen __instance, SimGameState ___simState)
        {
            foreach (MapMarker marker in Main.settings.mapMarkers.Values)
            {
                StarmapSystemRenderer systemRenderer = ___simState.Starmap.Screen.GetSystemRenderer(marker.systemName);
                GameObject prefab =null;
                if (marker.marker.useHmAnimation)
                {
                    systemRenderer.SetFlashpointMiniCampaign(true);
                    prefab = systemRenderer.flashpointMiniCampaignLocal;
                }
                else
                {
                    systemRenderer.SetFlashpointAvailable(true);
                    prefab = systemRenderer.flashpointAvailableLocal;
                }

                if (marker.marker.swapColour)
                {
                    foreach (ParticleSystem componentsInChild in prefab.GetComponentsInChildren<ParticleSystem>())
                    {
                        //Main.modLog.LogMessage(" " + componentsInChild.name + ": pr");
                        var main = componentsInChild.main;
                        var colorGrad = main.startColor;
                        Color color = marker.marker.GetColor(componentsInChild.name, colorGrad.colorMax.a);
                        colorGrad.colorMax = color;
                        main.startColor = colorGrad;
                    }
                }
            }
        }
    }
}
