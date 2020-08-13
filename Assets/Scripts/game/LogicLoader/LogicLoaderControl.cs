using System;
using System.Collections;
using UnityEngine;

/// <summary>
/// 登录相关
/// </summary>
public class LogicLoaderControl :SmartControl<LogicLoaderModel>
{


    public void StartGame() {
        GameMng.instance.StartCoroutine(_StartGame());
    }

    IEnumerator _StartGame() {

        //登录

        //加载资源
        yield return GameMng.instance.StartCoroutine(DB.LodingData());
        //mcv模块初始化
        LogicMM.FireOnAppInit();
        //链接服务器


        //进主城
        LogicMM.sceneControl.EnterScene(0);
        yield return null;
    }
}

