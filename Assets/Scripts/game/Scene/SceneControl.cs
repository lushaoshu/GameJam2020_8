using Entity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;


public class SceneControl :SmartControl<SceneModel>
{
    Dictionary<int, ISceneBehavior> _behaviors = new Dictionary<int, ISceneBehavior>();
    List<GameObject> scene_dos = new List<GameObject>();//场景中所有的对象

    ISceneBehavior _cur_behavior;//当前玩法
    ISceneBehavior _last_behavior;//上一个玩法
    public int _last_scene_id;//上一个场景
    public int _cur_scene_id=-1;//当前场景

    ISceneBehavior _def_behavior;//默认玩法

    string Path
    {
        get
        {
            return LogicMM.sceneControl.model.Cur_Data.is_tset ?
                @"scence/test/" : @"scence/";
        }
    }
    public void RegisterBehavior(int scene_sort, ISceneBehavior behavior) {
        _behaviors.Add(scene_sort, behavior);
    }

    public ISceneBehavior GetBehavior(int sceneID) {
        if (_behaviors.ContainsKey(sceneID))
            return _behaviors[sceneID];
        return null;
    }

    //服务端调用
    public void EnterScene(int sceneID)
    {
        GameMng.instance.StartCoroutine(_EnterScene(sceneID));
    }
    IEnumerator _EnterScene(int sceneID) {
        var newBehavior = GetBehavior(sceneID);
        var new_sceneBase = DB.SceneBaseMap[sceneID];
        if (_cur_behavior != newBehavior)
        {
            //退出当前玩法
            _cur_behavior?.LeaveBehavior();
            _last_behavior = _cur_behavior;
            _cur_behavior = newBehavior;
        }
        if (sceneID != _cur_scene_id)
        {
            _cur_behavior?.LeaveScene();
            _last_scene_id = _cur_scene_id;
            _cur_scene_id = sceneID;

            //加载新场景
            yield return GameMng.instance.StartCoroutine(BuildScene(new_sceneBase));
        }
        //初始化
        InitScene(new_sceneBase);

        _cur_behavior.InitBehavior();
        _cur_behavior.InitScene();
        //进入
        _cur_behavior.EnterBehavior();
        _cur_behavior.EnterScene();
        yield return null;
    }
    void InitScene(SceneBase sceneBase) {
        //创建主角
        //初始化主角
        //var behaviour = LogicMM.mainRole.AddMainRole();
        //behaviour.transform.position = sceneBase.player_pos;
    }
    IEnumerator BuildScene(SceneBase sceneBase)
    {
        //从res中获取预制体
        var _gameObject = GameObject.Instantiate(Resources.Load<GameObject>(Path + sceneBase.res));
        if (!_gameObject) Debug.Log($"{sceneBase.res},Resources中找不到");
        //创建根节点
        var go = new GameObject("map--"+sceneBase.name);
        _gameObject.transform.parent = go.transform;

        yield return null;
    }
}



