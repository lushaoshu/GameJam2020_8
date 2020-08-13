using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
/// <summary>
/// 片段数据
/// </summary>
[System.Serializable]
public class MyPlayableAsset : PlayableAsset
{
    [HideInInspector]
    public MyPlayableBehaviour templete = new MyPlayableBehaviour();//对应的行为
    [HideInInspector]
    public GameObject TrackTargetObject;//所作用的对象
    [HideInInspector]
    public TimelineClip OwningClip;//自己的片段信息

    [SerializeField]
    public Vector3 pos;//test
    public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
    {
        //Debug.LogError("CreatePlayable--");
        var playable = ScriptPlayable<MyPlayableBehaviour>.Create(graph);

        var lightControlBehaviour = playable.GetBehaviour();
        //lightControlBehaviour.light = light.Resolve(graph.GetResolver());

        lightControlBehaviour.targetObject = TrackTargetObject;
        lightControlBehaviour.OwningClip = OwningClip;
        lightControlBehaviour.tirggerTimelineClip = this;

        return playable;
        
    }
}