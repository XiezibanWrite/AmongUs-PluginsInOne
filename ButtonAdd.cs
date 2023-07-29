using HarmonyLib;

using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PluginsInOne.HanPi.ButtonLk
{

    [HarmonyPatch(typeof(MainMenuManager), nameof(MainMenuManager.Start))]
    public class ModUpdaterButton
    {
        private static void Prefix(MainMenuManager __instance)
        {
            
            var template = GameObject.Find("ExitGameButton");
            var hanhuaObj = UnityEngine.Object.Instantiate(template, null);
            GameObject.Destroy(hanhuaObj.GetComponent<AspectPosition>());
            hanhuaObj.transform.localPosition = new(4.4f,-2.3f,0);

            var hanhuabutton = hanhuaObj.GetComponentInChildren<TextMeshPro>();
            hanhuabutton.transform.localPosition = new(4.4f, -2.3f, 0);
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




            var lianxiobj = UnityEngine.Object.Instantiate(template, null);
            GameObject.Destroy(lianxiobj.GetComponent<AspectPosition>());
            lianxiobj.transform.localPosition = new(4.4f, -1.9f, 0);

            var lianxibutton = lianxiobj.GetComponentInChildren<TextMeshPro>();
            lianxibutton.transform.localPosition = new(4.4f, -1.9f, 0);
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



        }
    }
}
