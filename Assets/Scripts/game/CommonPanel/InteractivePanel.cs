using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class InteractivePanel : MyPanel
{
    GameObject panel;
    Vector3 pos;
    Text text_value;
    string value;
    public InteractivePanel() {
        _panelResName = "InteractivePanel";
    }
    public override void OnInit()
    {
        base.OnInit();
        panel = gameObject.FindChild("panel");
        text_value = gameObject.FindChild<Text>("text_tip");
    }
    public void InitData(Vector3 pos,string value) {
        this.pos = pos;
        this.value = value;
        UpdatePanel();
    }
    public override void OnShow()
    {
        base.OnShow();
        UpdatePanel();
    }
    public void UpdatePanel() {
        if (!IsVisible) return;
        text_value.text = value;
        Vector3 _pos = Camera.main.WorldToViewportPoint(pos);
        panel.transform.position = uiCamera.ViewportToWorldPoint(_pos);
    }
    public override void OnDestroy()
    {
        base.OnDestroy();
    }
}