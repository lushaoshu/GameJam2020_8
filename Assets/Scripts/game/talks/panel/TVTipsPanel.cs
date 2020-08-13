using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.UI;
/// <summary>
/// 电视对话tips
/// 屏幕正下方
/// 背景帧动画
/// 文字打字效果
/// </summary>
public class TVTipsPanel : MyPanel
{

    MyText text;
    public TVTipsPanel() {
        _panelResName = "tv_tips_panel";
    }

    public override void OnInit()
    {
        base.OnInit();
        text = gameObject.FindChild<MyText>("text");
        text.IsAutoPoint = true;
    }

    public override void OnShow()
    {
        base.OnShow();
        text.my_text = "啦啦啦啦！！！！！！！！！！";
    }
}