using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 旁白
/// 文字播放完后，开始进行倒计时,倒计时到之后自动进行下一个
/// </summary>
public class PangbaiTipsPanel : MyPanel
{
    float waitTime = 3f;
    MyText text;
    GameObject go_item;
    MyImage quan;
    public PangbaiTipsPanel() {
        _panelResName = "task_tips_panel";
    }

    public override void OnInit()
    {
        base.OnInit();
        text = gameObject.FindChild<MyText>("text");
       
        go_item = gameObject.FindChild("item");
        quan = go_item.FindChild<MyImage>("quan");
        text.IsAutoPoint = true;
    }

    public override void OnShow()
    {
        base.OnShow();
        go_item.SetActive(false);
        text.my_text = "我们的雇主并不知道<color=red>电音头之死</color><color=green>的情况</color>。";
        RunUITask(Wait(text.waitAllTime));
    }

    IEnumerator Wait(float time)
    {
        yield return new WaitForSeconds(time);
        go_item.SetActive(true);
        //圈转动
        quan.fillAmount = 0;
        float speed = 1/ waitTime*0.1f;
        while (quan.fillAmount<1) {

            quan.fillAmount += speed;
            yield return new WaitForSeconds(0.1f);
        }
        go_item.SetActive(false);
    }
}