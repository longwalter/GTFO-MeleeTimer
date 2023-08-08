using BepInEx;
using BepInEx.Unity.IL2CPP;
using HarmonyLib;
using Il2CppInterop.Runtime.Injection;

namespace MeleeTimer
{
    public static class PluginData
    {
        public const string GUID = "longwalter_MeleeTimer";
        public const string Name = "MeleeTimer";
        public const string Version = "0.0.2";
    }

    [BepInPlugin(PluginData.GUID, PluginData.Name, PluginData.Version)]
    public class EntryPoint : BasePlugin
    {
        private static Harmony? harmony;

        public override void Load()
        {
            ClassInjector.RegisterTypeInIl2Cpp<MeleeTimer>();

            harmony = new Harmony(PluginData.GUID);
            harmony.PatchAll();

            Logger.Info("Plugin Loaded");
        }
    }
}