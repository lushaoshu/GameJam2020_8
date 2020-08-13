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
/// 任务选择tips
/// </summary>
public class WalkTipsPanel : MyPanel
{
    GameObject go_top;
    GameObject go_down;
    MyText text;
    MyHorizontalLayoutGroup layoutGroup;

    TalkBase talkBase;
    Vector2 pos;
    public WalkTipsPanel() {
        _panelResName = "walk_tips_panel";
    }

    public void InitData(TalkBase talkBase,Vector2 pos) {
        this.talkBase = talkBase;
        this.pos = pos;
    }

    public override void OnInit()
    {
        base.OnInit();
        go_top = gameObject.FindChild("top");
        go_down = gameObject.FindChild("down");
        text = go_top.FindChild<MyText>("text");
        layoutGroup = go_down.GetComponent<MyHorizontalLayoutGroup>();
        text.IsAutoPoint = true;
    }

    public override void OnShow()
    {
        base.OnShow();
        if (talkBase == null) return;
        text.my_text = talkBase.text;
        go_down.SetActive(false);
       
        RunUITask(WaitAnim(text.waitAllTime));
    }

    IEnumerator WaitAnim(float time)
    {
        yield return new WaitForSeconds(time);
        go_down.SetActive(true);
        
        layoutGroup.InitChildren(talkBase.btnCall.Count, (index, tf) =>
        {
            var go = tf.gameObject;
            go.FindChild<MyText>("text").my_text = talkBase.btnCall[index].text;
        }
       );
        LayoutRebuilder.ForceRebuildLayoutImmediate(go_down.GetRectTransform());
        //播放所有特效
        for (int n=0;n< go_down.transform.childCount;n++) {
            var tf= go_down.transform.GetChild(n);
            if(n % 2 == 0)
                tf.DOLocalMoveY(20, 1).From().SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine).Play();
            else
                tf.DOLocalMoveY(20, 1).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine).Play();

        }
    }
}