using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using Harmony;
using BattleTech;
using BattleTech.UI;
using BattleTech.Framework;
using BattleTech.Data;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ColourfulFlashPoints.Patches
{

    [HarmonyPatch(typeof(SGContractsWidget), "ListContracts", typeof(List<Contract>), typeof(ContractDisplayStyle?))]
    class SGContractsWidget_ListContracts
    {
        static void Postfix(SGContractsWidget __instance, List<SGContractsListItem> ___listedContracts, List<Contract> contracts, ContractDisplayStyle? initialSelection = null)
        {
            Main.modLog.LogMessage("ListContracts Called");
            ContractCardController.Instance.lastContractSet = ___listedContracts;
            foreach (SGContractsListItem listedContract in ___listedContracts)
            {
                GameObject fillObject = listedContract.gameObject.transform.findChild("ENABLED-bg-fill").gameObject;
                if (fillObject != null)
                {
                    bool priorityContract = listedContract.Contract.Override.contractDisplayStyle == ContractDisplayStyle.BaseCampaignStory;
                    bool campaignContract = listedContract.Contract.Override.contractDisplayStyle == ContractDisplayStyle.BaseCampaignRestoration;
                    bool flashpointContract = listedContract.Contract.IsFlashpointContract;
                    bool fpCampaignContract = listedContract.Contract.IsFlashpointCampaignContract;
                    Image filler = fillObject.GetComponent<Image>();
                    Color colour;
                    if (flashpointContract || fpCampaignContract)
                    {
                        if (FlashPointController.Instance.getFlashpointContractColour(listedContract.Contract.Override.ID, fpCampaignContract, out colour))
                        {
                            filler.color = colour;
                        }
                    }
                    else
                    {
                        // leave priority & restoration campaign missions alone
                        if (!priorityContract && !campaignContract)
                        {
                            if (ContractCardController.Instance.getContractColour(listedContract.Contract, out colour))
                            {
                                Main.modLog.LogMessage($"Before Colour: {filler.color.r}, {filler.color.g}, {filler.color.b}");
                                filler.color = colour;
                                Main.modLog.LogMessage($"After Colour: {filler.color.r}, {filler.color.g}, {filler.color.b}");
                            }
                        }
                    }

                }
                else
                {
                    Main.modLog.LogMessage("Failed to find fill object!");
                }
            }
        }
        
    }

    [HarmonyPatch(typeof(SGContractsWidget), "ClearContracts")]
    class SGContractsWidget_ClearContracts
    {
        static void Prefix(List<SGContractsListItem> ___listedContracts)
        {
            Main.modLog.LogMessage($"ClearContracts Called");
            foreach (SGContractsListItem listedContract in ___listedContracts)
            {
                GameObject fillObject = listedContract.gameObject.transform.findChild("ENABLED-bg-fill").gameObject;
                if (fillObject != null)
                {
                    Image filler = fillObject.GetComponent<Image>();
                    Main.modLog.LogMessage($"Before Pooling Colour: {filler.color.r}, {filler.color.g}, {filler.color.b}");
                }
            }
        }
    }

    [HarmonyPatch(typeof(SGContractsWidget), "Init", typeof(SimGameState), typeof(Action<bool>))]
    class SGContractsWidget_Init
    {
        static void Postfix()
        {
            Main.modLog.LogMessage("Init Called");
        }
    }

    [HarmonyPatch(typeof(SGContractsWidget), "PopulateContract", typeof(Contract), typeof(Action))]
    class SGContractsWidget_PopulateContract
    {
        static void Postfix(List<SGContractsListItem> ___listedContracts)
        {
            Main.modLog.LogMessage("PopulateContract Called");
        }
    }

    [HarmonyPatch(typeof(SGContractsWidget), "SetMode", typeof(SGContractsWidget.ScreenMode))]
    class SGContractsWidget_SetMode
    {
        static void Postfix(SGContractsWidget.ScreenMode mode, List<SGContractsListItem> ___listedContracts)
        {
            Main.modLog.LogMessage($"SetMode Called: {mode}");
        }
    }
}
