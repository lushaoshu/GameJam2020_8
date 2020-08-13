using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
/// <summary>
/// timeline加载相关
/// </summary>
public class TimeLineController
{
    PlayableDirector director;
    public GameObject gameObject;
    string dataConfigName;
    string TimelineName;
    public bool isInitOk = false;

    public TimelineData Data {

        get { return _data; }
    }
    TimelineData _data;
    public void Play() {
        if (!gameObject.activeSelf)
            gameObject.SetActive(true);
        director.Play();
    }

    public double GetDurationSeconds() {
        return director.duration;
    }

    public static TimeLineController GetTimelineControl(string config, string timelineName)
    {
        TimeLineController controller = null;
        //这里做个cache，避免重复创建
        controller = new TimeLineController(config, timelineName);
        return controller;
    }

    public TimeLineController(string config ,string name) {
         dataConfigName= config;
         TimelineName= name;
         isInitOk = false;
        GameMng.instance.StartCoroutine(LodConfig());
    }

    private IEnumerator LodConfig() {
        yield return null;
        isInitOk = false;
        _data = Resources.Load<TimelineData>(dataConfigName);
        var playableAsset=Resources.Load<PlayableAsset>(TimelineName);
        if (!gameObject)
        {
            gameObject = new GameObject("TimelineController_"+dataConfigName);
            director = gameObject.AddComponent<PlayableDirector>();
        }
        director.playableAsset = playableAsset;
        gameObject.transform.parent = TimelineManager.GetOrCreatInstance().gameObject.transform;
        isInitOk = true;
    }
    /// <summary>
    /// 组装数据，赋值到timeline中
    /// </summary>
    public void AssemblyTimeline(ScenarioObjController[] actorBinds) {
        if (!director)
            return;
        int cnt = 0;
        var binds = director.playableAsset.outputs.ToArray();
        for (int i = 0; i < binds.Length; i++)
        {
            var bind = binds[i];
            //判断轨道
            if (bind.sourceObject is ActorTrack)
            {
                if (actorBinds[cnt].gameObject)
                {
                    director.SetGenericBinding(bind.sourceObject, actorBinds[cnt].gameObject);
                    //赋值轨道的控制组件
                    //给每个片段赋值，ExposedReference
                    
                }
                cnt++;
            }
            else if (bind.sourceObject is AnimationTrack)
            {
                if (actorBinds.Length <= cnt)
                {
                    Debug.LogError("数据错误");
                }
                else {
                    if (actorBinds[cnt].gameObject)
                    {
                        director.SetGenericBinding(bind.sourceObject, actorBinds[cnt].gameObject.GetMissComponent<Animator>());
                    }
                       
                    cnt++;
                }
            }
        }
    }
}