using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class LogPanel : MyPanel
{
    Text text_tip;
    public LogPanel(){
        _panelResName = "LogPanel";

    }

    public void UpdatePanel(string text) {
        if (!IsVisible)
            return;
        text_tip.text += text+ "\n";
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
        text_tip = gameObject.FindChild<Text>("text_tip");
        text_tip.text = "";
    }

    public override void OnShow()
    {
        base.OnShow();
    }

    public static LogPanel logPanel;
    public static void LogError2UI(string text)
    {
        Log2UI(string.Format("<color=red>{0}</color>", text));
    }

    public static void LogInfo2UI(string text)
    {
        Log2UI(string.Format("<color=white>{0}</color>", text));
    }

    private static void Log2UI(string text ) {
        if (logPanel == null)
            logPanel = MyGUIManager.GetInstance().GetOrCreatePanel<LogPanel>();
        if (!logPanel.IsVisible)
            logPanel.Display(true);

        logPanel.UpdatePanel(text);
    }
}

