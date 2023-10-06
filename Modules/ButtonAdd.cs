using HarmonyLib;
using TMPro;
using UnityEngine;
using UnityEngine.UI;



namespace PluginsInOne.Modules
{

    [HarmonyPatch(typeof(MainMenuManager), nameof(MainMenuManager.Start))]
    public class ModUpdaterButton
    {
        //对控制台输出Log所需
        public static BepInEx.Logging.ManualLogSource Logger = null!;
        private static void Prefix(MainMenuManager __instance)
        {
            Logger = BepInEx.Logging.Logger.CreateLogSource("HanPi.ButtonLk");

            var template = GameObject.Find("ExitGameButton");
            var hanhuaObj = Object.Instantiate(template, null);
            Object.Destroy(hanhuaObj.GetComponent<AspectPosition>());
            hanhuaObj.transform.localPosition = new(1.4764f, -2.2764f, 0);

            var hanhuabutton = hanhuaObj.GetComponentInChildren<TextMeshPro>();
            hanhuabutton.transform.localPosition = new(1.4764f, -2.2764f, 0);
            hanhuabutton.alignment = TextAlignmentOptions.Right;
            __instance.StartCoroutine(Effects.Lerp(0.1f, new System.Action<float>((p) =>
            {
                hanhuabutton.SetText("汉化组官网");
            })));

            PassiveButton passiveButtonxiaozhan = hanhuaObj.GetComponent<PassiveButton>();
            SpriteRenderer buttonSpritehanhua = hanhuaObj.transform.FindChild("Inactive").GetComponent<SpriteRenderer>();

            passiveButtonxiaozhan.OnClick = new Button.ButtonClickedEvent();
            passiveButtonxiaozhan.OnClick.AddListener((System.Action)(() => Application.OpenURL("https://amonguscn.club")));
            Color hanhuaColor = new Color32(255, 0, 0, byte.MaxValue);
            buttonSpritehanhua.color = hanhuabutton.color = hanhuaColor;
            passiveButtonxiaozhan.OnMouseOut.AddListener((System.Action)delegate
            {
                buttonSpritehanhua.color = hanhuabutton.color = hanhuaColor;
            });
            Logger.LogInfo("Website Button Add Success");




            var lianxiobj = Object.Instantiate(template, null);
            Object.Destroy(lianxiobj.GetComponent<AspectPosition>());
            lianxiobj.transform.localPosition = new(1.4764f, -1.8764f, 0);

            var lianxibutton = lianxiobj.GetComponentInChildren<TextMeshPro>();
            lianxibutton.transform.localPosition = new(1.4764f, -1.8764f, 0);
            lianxibutton.alignment = TextAlignmentOptions.Right;
            __instance.StartCoroutine(Effects.Lerp(0.1f, new System.Action<float>((p) =>
            {
                lianxibutton.SetText("联系汉化组");
            })));

            PassiveButton passiveButtonlianxi = lianxiobj.GetComponent<PassiveButton>();
            SpriteRenderer buttonSpritelianxi = lianxiobj.transform.FindChild("Inactive").GetComponent<SpriteRenderer>();

            passiveButtonlianxi.OnClick = new Button.ButtonClickedEvent();
            passiveButtonlianxi.OnClick.AddListener((System.Action)(() => Application.OpenURL("https://jq.qq.com/?_wv=1027&k=3wPXhLE1")));
            Color lianxiColor = new Color32(255, 255, 0, byte.MaxValue);
            buttonSpritelianxi.color = lianxibutton.color = lianxiColor;
            passiveButtonlianxi.OnMouseOut.AddListener((System.Action)delegate
            {
                buttonSpritelianxi.color = lianxibutton.color = lianxiColor;
            });

            Logger.LogInfo("QQ Group Button Add Success");




            var cursorObj = Object.Instantiate(template, null);
            Object.Destroy(cursorObj.GetComponent<AspectPosition>());
            cursorObj.transform.localPosition = new(4.4f, 1.6782f, 0);

            var cursorbutton = cursorObj.GetComponentInChildren<TextMeshPro>();
            cursorbutton.transform.localPosition = new(4.4f, 1.6782f, 0);
            cursorbutton.alignment = TextAlignmentOptions.Right;
            __instance.StartCoroutine(Effects.Lerp(0.1f, new System.Action<float>((p) =>
            {
                if (PluginsInOnePlugin.customcursor == true)
                {
                    cursorbutton.SetText("自定义光标：开");
                }
                else
                {
                    cursorbutton.SetText("自定义光标：关");
                }

            })));
            PassiveButton passiveButtoncursor = cursorObj.GetComponent<PassiveButton>();
            SpriteRenderer buttonSpritecursor = cursorObj.transform.FindChild("Inactive").GetComponent<SpriteRenderer>();

            passiveButtoncursor.OnClick = new Button.ButtonClickedEvent();
            passiveButtoncursor.OnClick.AddListener((System.Action)(() =>
            {
                if (PluginsInOnePlugin.customcursor == true)
                {
                    Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                    PluginsInOnePlugin.customcursor = false;
                    cursorbutton.SetText("自定义光标：关");
                }
                else
                {
                    Patches.CursorChange.CursorInit();
                    PluginsInOnePlugin.customcursor = true;
                    cursorbutton.SetText("自定义光标：开");
                }



            }));
        }
    }
}