using BepInEx;
using BepInEx.Unity.IL2CPP;
using HarmonyLib;
using PluginsInOne.Modules;
using System.Linq;

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
        //DevManager.Init();
        Harmony.PatchAll();
        Logger.LogInfo("Loading Success!");

    }


}
public static class GameStates
{
    public static bool InGame = false;
    public static bool AlreadyDied = false;
    public static bool IsLobby => AmongUsClient.Instance.GameState == AmongUsClient.GameStates.Joined;
    public static bool IsInGame => InGame;
    public static bool IsEnded => AmongUsClient.Instance.GameState == AmongUsClient.GameStates.Ended;
    public static bool IsNotJoined => AmongUsClient.Instance.GameState == AmongUsClient.GameStates.NotJoined;
    public static bool IsOnlineGame => AmongUsClient.Instance.NetworkMode == NetworkModes.OnlineGame;
    public static bool IsLocalGame => AmongUsClient.Instance.NetworkMode == NetworkModes.LocalGame;
    public static bool IsFreePlay => AmongUsClient.Instance.NetworkMode == NetworkModes.FreePlay;
    public static bool IsInTask => InGame && !MeetingHud.Instance;
    public static bool IsMeeting => InGame && MeetingHud.Instance;
    public static bool IsVoting => IsMeeting && MeetingHud.Instance.state is MeetingHud.VoteStates.Voted or MeetingHud.VoteStates.NotVoted;
    public static bool IsProceeding => IsMeeting && MeetingHud.Instance.state is MeetingHud.VoteStates.Proceeding;
    public static bool IsCountDown => GameStartManager.InstanceExists && GameStartManager.Instance.startState == GameStartManager.StartingStates.Countdown;
    /**********TOP ZOOM.cs***********/
    public static bool IsShip => ShipStatus.Instance != null;
    public static bool IsCanMove => PlayerControl.LocalPlayer?.CanMove is true;
    public static bool IsDead => PlayerControl.LocalPlayer?.Data?.IsDead is true;
}