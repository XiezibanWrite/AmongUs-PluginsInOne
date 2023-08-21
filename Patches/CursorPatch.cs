using HarmonyLib;
using UnityEngine;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using PluginsInOne.Modules;

namespace PluginsInOne.Patches
{
    [HarmonyPatch(typeof(MainMenuManager), nameof(MainMenuManager.Start))]
    public class CursorChange
    {
        public static Dictionary<string, Sprite> CachedSprites = new();
        private static void Prefix(MainMenuManager __instance)
        {
            if (PluginsInOnePlugin.customcursor == false)
            {
                return;
            }
            CursorInit();
            PluginsInOnePlugin.customcursor = true;
        }
        public static void CursorInit()
        {
            Sprite sprite = PictureLoad.LoadSprite("PluginsInOne.Resources.Cursor.png");
            Cursor.SetCursor(sprite.texture, Vector2.zero, CursorMode.Auto);
        }

    }
}
