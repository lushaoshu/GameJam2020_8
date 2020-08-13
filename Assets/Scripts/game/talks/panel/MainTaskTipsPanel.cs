using DG.Tweening;
using Entity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 旁白
/// 文字播放完后，开始进行倒计时,倒计时到之后自动进行下一个
/// </summary>
public class MainTaskTipsPanel : MyPanel
{
    float waitTime = 5f;
    float errerTime = 2f;

    MyImage cur;
    MyImage errer;
    MyVerticalLayoutGroup layoutGroup;
    TalkBase talkBase;
    Vector2 pos;
    public MainTaskTipsPanel() {
        _panelResName = "main_task_panel";
    }

    public void InitData(TalkBase talkBase, Vector2 pos)
    {
        this.talkBase = talkBase;
        this.pos = pos;
    }

    public override void OnInit()
    {
        base.OnInit();

        cur = gameObject.FindChild<MyImage>("cur");
        errer = gameObject.FindChild<MyImage>("errer");
        layoutGroup = gameObject.FindChild<MyVerticalLayoutGroup>("down");
    }

    public override void OnShow()
    {
        base.OnShow();
        if (talkBase == null) return;
        waitTime = talkBase.time;
        errerTime = talkBase.errerTime;

        errer.fillAmount = errerTime / waitTime;

        layoutGroup.InitChildren(talkBase.btnCall.Count, (index,tf)=>
        {
            var go = tf.gameObject;
            go.FindChild<MyText>("text").my_text = talkBase.btnCall[index].text;
        });
        RunUITask(Wait());
    }

    IEnumerator Wait()
    {
        cur.fillAmount = 0;
        float speed = 1/ waitTime*0.01f;
        while (cur.fillAmount<1) {

            cur.fillAmount += speed;
            yield return new WaitForSeconds(0.01f);
        }
        Display(false);
    }
}