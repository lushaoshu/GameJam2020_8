using Entity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

/// <summary>
/// 单个timeline的数据
/// </summary>
public class TimelineAction
{
    string config;
    public TimeLineController controller;
    //List<GameObject> actorBinds = new List<GameObject>();
    List<ScenarioObjController> actorBinds = new List<ScenarioObjController>();
    Dictionary<string, ScenarioObjController> acenarioObjDic = new Dictionary<string, ScenarioObjController>();
    public bool isInitOk = false;
    GameObject rootObj;
    public TimelineAction(string timelineId, GameObject root)
    {
        isInitOk = false;
        config = timelineId;
        this.rootObj = root;
        GameMng.instance.StartCoroutine(CollectSubItems());
    }

    //创建相关对象
    IEnumerator CollectSubItems() {
        controller = TimeLineController.GetTimelineControl(config, config);
        yield return null;
        while (!controller.isInitOk)
        {
            yield return 50;
        }
        //创建虚拟相机prefeb

        //下载fomd需要的资源
        //创建演员
        CreateActors(controller.Data.actorDatas);
        //设置相机，将相机的动态数据赋值

        isInitOk = true;
    }

    public float StartPlay() {
        if (controller == null) return 0;
        controller.AssemblyTimeline(actorBinds.ToArray());
        controller.Play();
        return (float)controller.GetDurationSeconds();
    }

    void CreateActors(ActorData[] datas) {
        actorBinds.Clear();
        for (int i = 0; i < datas.Length; ++i)
        {
            var data = datas[i];
            string key_name = $"{data.aoi_id}_";
            ScenarioObjController scenario = null;
            if (!acenarioObjDic.ContainsKey(key_name))
            {
                //建立对象
                //先判断场景中有没有，没有则创建
                scenario = new ScenarioObjController(LogicMM.role.CreatRole(data.aoi_id));
                scenario.gameObject.transform.position = data.actorPos;
                acenarioObjDic.Add(key_name,scenario);
            }
            actorBinds.Add(scenario);
        }
    }
}