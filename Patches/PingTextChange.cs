using HarmonyLib;
using TMPro;
using UnityEngine;


namespace PluginsInOne.Patches
{
    //[HarmonyPriority(Priority.VeryHigh)] // to show this message first, or be overrided if any plugins do
    [HarmonyPatch(typeof(PingTracker), nameof(PingTracker.Update))]
    public static class PingTracker_Update
    {
        public const bool a = true;
        public static BepInEx.Logging.ManualLogSource Logger = null!;

        [HarmonyPostfix]

        public static void Postfix(PingTracker __instance)
        {

            Logger = BepInEx.Logging.Logger.CreateLogSource("PingTextChange");
            var position = __instance.GetComponent<AspectPosition>();
            position.DistanceFromEdge = new Vector3(3.6f, 0.1f, 0);
            position.AdjustPosition();

            __instance.text.text =
                $"延迟: {AmongUsClient.Instance.Ping} 毫秒";





        }
    }
}