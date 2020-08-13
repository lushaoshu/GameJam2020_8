using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class MyPanel :PanelBase
{

    MyPanelEventListener _listener = null;
    public override bool IsVisible => gameObject && gameObject.activeSelf;

    public override void Display(bool b)
    {
        if (b)
        {
            _show();

        }
        else {
            _hide();

        }

    }

    protected string _panelResName;
    private void _hide()
    {
        if (!IsVisible) return;
        if (gameObject)
            gameObject.SetActive(false);

        _tasks.ForEach(a => GameMng.instance.StopCoroutine(a));
        _tasks.Clear();
        //销毁
        OnDestroy();
    }

    private void _show()
    {
        if (!gameObject) {
            BuildPanel();
            _init();
            OnInit();
        }
        gameObject.SetActive(true);
        OnShow();
    }
    private void _init() {
        var canvas = _gameObject.GetComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceCamera;
        canvas.worldCamera = uiCamera;
        IsSightVisible = true;

        _tasks.ForEach(a=> GameMng.instance.StopCoroutine(a));
        _tasks.Clear();
    }
    void BuildPanel() {
        //从res中获取预制体
        _gameObject= GameObject.Instantiate(Resources.Load<GameObject>("ui\\panel\\"+_panelResName));
        if (!_gameObject) Debug.Log($"{_panelResName},Resources中找不到");
        _gameObject.name = this._panelResName;
        _gameObject.transform.position = Vector3.zero;
        //加入管理
        MyGUIManager.GetInstance().AddPanelObject(this);

        if (_listener == null)
            _listener = new MyPanelEventListener();
        var eventBase = _gameObject.AddComponent<IUIEvent>();
        _listener.OnInit(this, eventBase);

    }

    public bool IsSightVisible;
    /// <summary>
    /// 频繁显示的ui用这个
    /// </summary>
    public void SightShow() {
        if(!IsVisible) return;
        _gameObject.SetLayerRecursively(GameConfig.LAYER_UI) ;
        IsSightVisible = true;
    }
    public void SightHide()
    {
        if (!IsVisible) return;
        _gameObject.SetLayerRecursively(GameConfig.LAYER_HIDE);
        IsSightVisible = false;
    }
}
