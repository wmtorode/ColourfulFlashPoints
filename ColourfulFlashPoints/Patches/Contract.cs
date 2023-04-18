using BattleTech;
using BattleTech.Framework;


namespace ColourfulFlashPoints.Patches
{

    [HarmonyPatch(typeof(Contract), "get_IsFlashpointContract")]
    class Contract_GetIsFlashpointContract_Patch
    {
        static void Postfix(Contract __instance, ref bool __result)
        {
            if (__instance.Override != null)
            {
                if(__instance.Override.contractDisplayStyle == ContractDisplayStyle.BaseFlashpoint || __instance.Override.contractDisplayStyle == ContractDisplayStyle.HeavyMetalFlashpointCampaign)
                {
                    if(FlashPointController.Instance.contractHasFpMarker(__instance.Override.ID))
                    {
                        __result = !FlashPointController.Instance.useHmContractElement(__instance.Override.ID);
                    }
                }
            }
        }
    }

    [HarmonyPatch(typeof(Contract), "get_IsFlashpointCampaignContract")]
    class Contract_GetIsFlashpointCampaignContract_Patch
    {
        static void Postfix(Contract __instance, ref bool __result)
        {
            if (__instance.Override != null)
            {
                if (__instance.Override.contractDisplayStyle == ContractDisplayStyle.BaseFlashpoint || __instance.Override.contractDisplayStyle == ContractDisplayStyle.HeavyMetalFlashpointCampaign)
                {
                    if (FlashPointController.Instance.contractHasFpMarker(__instance.Override.ID))
                    {
                        __result = FlashPointController.Instance.useHmContractElement(__instance.Override.ID);
                    }
                }
            }
        }
    }
}
