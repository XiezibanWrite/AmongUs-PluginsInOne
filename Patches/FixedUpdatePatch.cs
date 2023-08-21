using HarmonyLib;
using PluginsInOne.Modules;


namespace PluginsInOne.Patches
{
    [HarmonyPatch(typeof(PlayerControl), nameof(PlayerControl.FixedUpdate))]
    class FixedUpdatePatch
    {
        public static void Postfix(PlayerControl __instance)
        {
    
            if (GameStates.IsLocalGame || GameStates.IsLocalGame)
            {
                CustomName.ApplySuffix(__instance);
            }
                
        }
    }
}
