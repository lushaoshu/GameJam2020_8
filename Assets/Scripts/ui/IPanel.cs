using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public interface IPanel {
    void OnInit();
    void OnShow();
    void OnDestroy();
    void Display(bool b);
    bool IsVisible { get; }
}
public class PanelBase : IPanel
{
    protected GameObject _gameObject;

    public virtual bool IsVisible {
        get {
            return false;
        }
    }

    public GameObject gameObject { get => _gameObject;  }
    public Camera uiCamera { get => LogicMM.cameraContol.UiCamera;  }
    protected List<Coroutine> _tasks = new List<Coroutine>();

    public virtual void Display(bool b)
    {

    }
    public virtual void OnClick(MonoBehaviour behaviour) {

    }

    public virtual void OnPointerExit(MonoBehaviour behaviour)
    {

    }

    public virtual void OnPointerEnter(MonoBehaviour behaviour)
    {

    }

    public virtual void OnDestroy()
    {

    }

    public virtual void OnInit()
    {

    }

    public virtual void OnShow()
    {

    }
    public virtual void OnDrag(MyDragData myDragData)
    {

    }

    public virtual void OnDragStart(MyDragData myDragData)
    {

    }

    public virtual void OnDragEnd(MyDragData myDragData)
    {

    }

    public void RunUITask(IEnumerator e) {
        _tasks.Add(GameMng.instance.StartCoroutine(e));
    }
}