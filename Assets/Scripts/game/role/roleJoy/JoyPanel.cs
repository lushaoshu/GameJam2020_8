using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class JoyPanel : MyPanel
{
    public JoyPanel() {
        _panelResName = "JpyPanel";
    }

    public override void Display(bool b)
    {
        base.Display(b);
    }

    public override void OnClick(MonoBehaviour behaviour)
    {
        base.OnClick(behaviour);
    }

    public override void OnDestroy()
    {
        base.OnDestroy();
    }

    public override void OnInit()
    {
        base.OnInit();
    }

    public override void OnShow()
    {
        base.OnShow();
    }
}
