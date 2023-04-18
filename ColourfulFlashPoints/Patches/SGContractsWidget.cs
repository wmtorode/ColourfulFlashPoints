using System.Collections.Generic;
using BattleTech;
using BattleTech.UI;
using BattleTech.Framework;
using UnityEngine;
using UnityEngine.UI;

namespace ColourfulFlashPoints.Patches
{

    [HarmonyPatch(typeof(SGContractsWidget), "ListContracts", typeof(List<Contract>), typeof(ContractDisplayStyle?))]
    class SGContractsWidget_ListContracts
    {
        static void Postfix(SGContractsWidget __instance, List<Contract> contracts, ContractDisplayStyle? initialSelection = null)
        {
            //Main.modLog.LogMessage("ListContracts Called");
            ContractCardController.Instance.lastContractSet = __instance.listedContracts;
            foreach (SGContractsListItem listedContract in __instance.listedContracts)
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
                    ContractCardFixup fixup = fillObject.GetComponent<ContractCardFixup>();

                    // Add this fixup component to the card, otherwise on first initialization after loading a save or
                    // after a battle, the colours will revert to default
                    if (fixup == null)
                    {
                        fixup = fillObject.AddComponent<ContractCardFixup>();
                    }
                    if (flashpointContract || fpCampaignContract)
                    {
                        if (FlashPointController.Instance.getFlashpointContractColour(listedContract.Contract.Override.ID, fpCampaignContract, out colour))
                        {
                            filler.color = colour;
                            fixup.setColour(colour);
                            fixup.setUp(filler);
                        }
                    }
                    else
                    {
                        // leave priority & restoration campaign missions alone
                        if (!priorityContract && !campaignContract)
                        {
                            if (ContractCardController.Instance.getContractColour(listedContract.Contract, out colour))
                            {
                                filler.color = colour;
                                fixup.setColour(colour);
                                fixup.setUp(filler);
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
}
