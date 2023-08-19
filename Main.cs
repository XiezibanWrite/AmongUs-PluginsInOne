using BepInEx;
using BepInEx.Unity.IL2CPP;
using HarmonyLib;
namespace PluginsInOne;

[BepInPlugin(Id, ModName, VersionString)]
[BepInProcess("Among Us.exe")]

public partial class PluginsInOnePlugin : BasePlugin
{
    public Harmony Harmony { get; } = new(Id);
    public const string ModName = "PluginsInOne";

    public const string Id = "4hgroup.developer.PluginsInOne";
    // 模组版本
    public const string VersionString = "0.0.1";
    public static bool customcursor = true;

    //对控制台输出Log所需
    public static BepInEx.Logging.ManualLogSource Logger = null!;
    public const string Antidecompile = "nowright";

    public override void Load()
    {
        Logger = BepInEx.Logging.Logger.CreateLogSource("PluginsInOne");
        Logger.LogInfo("Loading Plugins...");

        Harmony.PatchAll();
        Logger.LogInfo("Loading Success!");

    }


}