using AmongUs.Data;


namespace PluginsInOne.Modules
{
    internal class CustomName
    {
        public static BepInEx.Logging.ManualLogSource Logger = null!;
        public static void ApplySuffix(PlayerControl player)
        {
            Logger = BepInEx.Logging.Logger.CreateLogSource("HanPi.CustomName");
            string name = DataManager.player.Customization.Name;
            string fname = DataManager.player.Customization.Name;
            if (AmongUsClient.Instance.IsGameStarted)
            {
                player.RpcSetName(fname);
                return;
            }
            if (GameStates.IsLobby && !name.Contains('\r') && player.FriendCode.GetDevUser().HasTag())
            {
                name = player.FriendCode.GetDevUser().GetTag() + name;
            }
           
            player.RpcSetName(name);
            
            
        }
    }
}
        

