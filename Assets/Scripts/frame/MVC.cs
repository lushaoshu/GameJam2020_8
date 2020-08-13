using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ModuleBase {
    public static List<ModuleBase> ModuleList = new List<ModuleBase>();
    public static Dictionary<Type, ModuleBase> ModleMap = new Dictionary<Type, ModuleBase>();


    public ModuleBase() {
        var key = GetType();
        if (ModleMap.ContainsKey(key)) {
            Debug.LogError($"{key},重复存在");
        }
        ModuleList.Add(this);
        ModleMap.Add(key, this);
    }
    public virtual void OnAppInit() { }//全局初始化

    public virtual void OnFrameUpdate() { }

    public void RunTask(IEnumerator e)
    {
        GameMng.instance.StartCoroutine(e);
    }
}
public abstract class Control : ModuleBase
{

}
public abstract class Model : ModuleBase
{

}
public abstract class SmartControl<M> : Control
        where M:Model,new()
{
    public M model;
    public SmartControl() {
        model = new M();
    }

}
public abstract class SmartModel<C> : Model
        where C: Control
{
    protected C control;
    public SmartModel() {
        control = ModleMap[typeof(C)] as C;
    }
}