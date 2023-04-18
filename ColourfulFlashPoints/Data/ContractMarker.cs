using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using UnityEngine;
using BattleTech;

namespace ColourfulFlashPoints.Data
{
    class ContractMarker
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public EContractTargetType type = EContractTargetType.ContractType;
        public List<string> contractIds = new List<string>();
        public ColourValue colour = new ColourValue();

        public Color GetColor()
        {
            return colour.GetColor();
        }

        private bool checkType(Contract contract)
        {
            return contractIds.Contains(contract.Override.ContractTypeValue.Name);
        }

        private bool checkContractId(Contract contract)
        {
            return contractIds.Contains(contract.Override.ID);
        }

        private bool checkContractName(Contract contract)
        {
            return contractIds.Contains(contract.Override.contractName);
        }

        public bool EvaluateMarker(Contract contract)
        {
            switch(type)
            {
                case EContractTargetType.ContractType:
                    return checkType(contract);
                case EContractTargetType.ContractId:
                    return checkContractId(contract);
                case EContractTargetType.ContractName:
                    return checkContractName(contract);
                default:
                    return false;
            }
        }
    }
}
