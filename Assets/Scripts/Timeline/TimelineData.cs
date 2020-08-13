using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Timeline;

[Serializable]
public class TimelineData :ScriptableObject
{
    [SerializeField]
    public TimelineAsset timelineDataAsset;//timeline 资源
    [SerializeField]
    public string timelineDataAssetName;
 
    [SerializeField]
    public ActorData[] actorDatas = new ActorData[0];
    [SerializeField]
    public VCamData[] vCamDatas = new VCamData[0];
    [SerializeField]
    public FmodData[] fModDatas = new FmodData[0];
    //[SerializeField]
    //public MyTimelineData[] myDatas = new MyTimelineData[0];
}

[Serializable]
public struct ActorData
{
    public int aoi_id;//aoi_id
    public Vector3 actorPos;
    public ActorAnimationClip[] clips;//演员动画
}
[Serializable]
public struct VCamData
{

}
[Serializable]
public struct FmodData
{

}

//[Serializable]
//public struct MyTimelineData
//{
//    public int ID;
//    public Vector3 actorPos;
//    public ActorAnimationClip[] clips;//演员动画
//}

[Serializable]
public struct ActorAnimationClip//GUP动画用
{
    public double start;
    public double duration;
    public double end;
    public string animationClipName;
    public double clipIn;
}