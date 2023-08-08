using Gear;
using HarmonyLib;

namespace MeleeTimer.Patches
{
    [HarmonyPatch(typeof(MWS_ChargeUp), nameof(MWS_ChargeUp.Enter))]
    internal static class MWS_ChargeUp_Enter
    {
        static void Postfix(ref MWS_ChargeUp __instance)
        {
            MeleeTimer instance = MeleeTimer.Instance;
            if (instance == null) return;
            if (instance.CU_Instance == __instance) return;

            instance.CU_Instance = __instance;
            instance.OnEnter();
        }
    }
}
