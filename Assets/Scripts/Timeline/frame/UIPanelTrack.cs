using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[TrackClipType(typeof(UIPanelPlayableAsset))]//轨道对应的片段
public class UIPanelTrack : TrackAsset
{

    public override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount)
    {
        
        var director = go.GetComponent<PlayableDirector>();
        //var trackTargetObject = director.GetGenericBinding(this) as GameObject;
        foreach (var clip in GetClips())
        {
            var myAsset = clip.asset as UIPanelPlayableAsset;
            if (myAsset)
            {
                myAsset.templete.ParentTrack = this;
                //myAsset.TrackTargetObject = trackTargetObject;
                myAsset.OwningClip = clip;

            }

        }

        var tbl = ScriptPlayable<UIPanelMixer>.Create(graph, inputCount);
        return tbl;
        //return base.CreateTrackMixer(graph, go, inputCount);
    }


}
