using CellMenu;
using HarmonyLib;
using UnityEngine;

namespace MeleeTimer.Patches
{
    [HarmonyPatch(typeof(CM_PageRundown_New), "PlaceRundown")]
    internal static class CM_PageRundown_New_PlaceRundown
    {
        static void Postfix()
        { 
            if (!CM_PageRundown_New_PlaceRundown.InjectedFlag)
            {
                CM_PageRundown_New_PlaceRundown.InjectedFlag = true;
                GameObject gameObject = new GameObject("MT_CompInject");
                gameObject.AddComponent<MeleeTimer>();
                UnityEngine.Object.DontDestroyOnLoad(gameObject);
            }
        }

        private static bool InjectedFlag;
    }
}