using Gear;
using HarmonyLib;

namespace MeleeTimer.Patches
{
    [HarmonyPatch(typeof(MWS_ChargeUp), nameof(MWS_ChargeUp.Exit))]
    internal static class MWS_ChargeUp_Exit
    {
        static void Postfix()
        {
            MeleeTimer instance = MeleeTimer.Instance;
            if (instance == null) return;

            instance.OnExit();
        }
    }
}
