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

namespace ColourfulFlashPoints.Patches
{

    [HarmonyPatch(typeof(SGContractsWidget), "AddContract", typeof(Contract))]
    class SGContractsWidget_AddContract
    {
        private static SGContractsWidget lastInstance;
        private static PropertyInfo pInfo = AccessTools.Property(typeof(SGContractsWidget), "Sim");

        private static void onContractSelected(Contract contract)
        {
            lastInstance.PopulateContract(contract, (Action)null);
        }
        public static bool Prefix(SGContractsWidget __instance, Contract contract, DataManager ___dm, RectTransform ___ContractListParent, HBSRadioSet ___ContractListRadioSet, List<SGContractsListItem> ___listedContracts)
        {
            lastInstance = __instance;
            SimGameState sim = (SimGameState)pInfo.GetValue(__instance);
            string id = "uixPrfPanl_SIM_contract-Element";
            int num = contract.Override.contractDisplayStyle == ContractDisplayStyle.BaseCampaignStory ? 1 : 0;
            bool flag = contract.Override.contractDisplayStyle == ContractDisplayStyle.BaseCampaignRestoration;
            bool flashpointContract = contract.IsFlashpointContract;
            bool campaignContract = contract.IsFlashpointCampaignContract;
            if (num != 0)
                id = "uixPrfPanl_SIM_contractStory-Element";
            else if (flag)
                id = "uixPrfPanl_SIM_contractStory-Element";
            else if (flashpointContract)
                id = "uixPrfPanl_SIM_contractFlashpoint-Element";
            else if (campaignContract)
                id = "uixPrfPanl_SIM_contractMiniCampaign-Element";
            GameObject gameObject = ___dm.PooledInstantiate(id, BattleTechResourceType.UIModulePrefabs, new Vector3?(), new Quaternion?(), (Transform)___ContractListParent);
            SGContractsListItem component = gameObject.GetComponent<SGContractsListItem>();
            if ((bool)((UnityEngine.Object)component))
            {
                gameObject.transform.localScale = Vector3.one;
                component.Init(contract, sim);
                component.OnContractSelected.RemoveAllListeners();
                component.OnContractSelected.AddListener(new UnityAction<Contract>(onContractSelected));
                component.AddToRadioSet(___ContractListRadioSet);
                ___listedContracts.Add(component);
            }
            return false;
        }
    }
}
