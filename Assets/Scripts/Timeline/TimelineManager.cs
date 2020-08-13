using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
/// <summary>
/// TimelineAction 管理器
/// </summary>
public class TimelineManager
{
    static private TimelineManager mgr;
    public GameObject gameObject;
    public Transform transform;
    public List<TimelineAction> timelineActions =new List<TimelineAction>();


    public static TimelineManager GetOrCreatInstance() {
        if (mgr == null)
        {
            var go = new GameObject("_Timeline Controllers");
            GameObject.DontDestroyOnLoad(go);
            mgr = new TimelineManager();
            mgr.gameObject = go;
            mgr.transform = go.transform;
        }
        return mgr;
    }
    //添加timeline
    public TimelineAction AddScenarioTimeline(string config) {
        TimelineAction action;
        action = new TimelineAction(config,gameObject);
        timelineActions.Add(action);
        //保存到列表中
        return action;
    }

}