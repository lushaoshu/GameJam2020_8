using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class TestPanel :MyPanel
{
    public TestPanel() {
        _panelResName = "TestPanel";
    }

    public override void OnClick(MonoBehaviour behaviour)
    {
        base.OnClick(behaviour);
        Debug.Log("OnClick--");
    }

}

