using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Harmony;
using BattleTech;
using BattleTech.UI;

namespace ColourfulFlashPoints.Patches
{
    [HarmonyPatch(typeof(SGRoomController_CmdCenter), "StartContractScreen")]
    class SGRoomController_CmdCenter_StartContractScreen
    {
        static void Postfix()
        {
            Main.modLog.LogMessage("StartContractScreen Called");
        }
    }
}
