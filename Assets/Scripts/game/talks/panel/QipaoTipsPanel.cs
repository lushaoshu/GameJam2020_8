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
/// 气泡对话
/// </summary>
public class QipaoTipsPanel : MyPanel
{

    MyText text;
    DOTweenAnimation panel_anim;
    public QipaoTipsPanel() {
        _panelResName = "qipao_tips";
    }

    public override void OnInit()
    {
        base.OnInit();
        text = gameObject.FindChild<MyText>("text");
        panel_anim = gameObject.FindChild<DOTweenAnimation>("panel");
        text.IsAutoPoint = true;
    }

    public override void OnShow()
    {
        base.OnShow();
        text.my_text = "<color=red>苗条的理查德</color>！！！！！！！！！！\n<color=green>啦啦啦</color>！！！！！！！！！";
        RunUITask(WaitAnim(text.waitAllTime));
    }

    IEnumerator WaitAnim(float time) {
        yield return new WaitForSeconds(time);
        panel_anim.DOPlay();
    }
}