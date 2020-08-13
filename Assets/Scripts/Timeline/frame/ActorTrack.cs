using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[TrackClipType(typeof(MyPlayableAsset))]//轨道对应的片段
[TrackBindingType(typeof(GameObject))]//轨道控制的组件
public class ActorTrack : TrackAsset
{

    public override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount)
    {
        
        var director = go.GetComponent<PlayableDirector>();
        var trackTargetObject = director.GetGenericBinding(this) as GameObject;
        foreach (var clip in GetClips())
        {
            var myAsset = clip.asset as MyPlayableAsset;
            if (myAsset)
            {
                myAsset.templete.parentTrack = this;
                myAsset.TrackTargetObject = trackTargetObject;
                myAsset.OwningClip = clip;

            }

        }

        var tbl = ScriptPlayable<ActionMixer>.Create(graph, inputCount);
        return tbl;
        //return base.CreateTrackMixer(graph, go, inputCount);
    }


}