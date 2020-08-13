using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEditor;
using UnityEngine.Playables;

static internal class PlayerableDirectorReader 
{
    [MenuItem("CONTEXT/PlayableDirector/导出Timeline数据")]
    static public void ExportSelectionTimeline(MenuCommand menuCommand) {
        var playableDirector = menuCommand.context as PlayableDirector;
        if (playableDirector != null)
        {
            var timelineAsset = playableDirector.playableAsset;

            var assetFile = AssetDatabase.GetAssetPath(timelineAsset).ToLower();
            var fileName = System.IO.Path.GetFileName(assetFile);

            var data = ScriptableObject.CreateInstance<TimelineData>();
            var assetobject = AssetDatabase.LoadAssetAtPath<TimelineAsset>(assetFile);
            data.timelineDataAsset = assetobject;
            data.timelineDataAssetName = assetobject.name.ToLower();

            int i = 0;
            List<ActorData> actorDatas = new List<ActorData>();
            List<FmodData> fmodDatas = new List<FmodData>();
            //var bindings = playableDirector.playableAsset.outputs.GetEnumerator();
            //while (bindings.MoveNext())
            //{
            //    //获取当前轨道的绑定键
            //    Object sourceObject = bindings.Current.sourceObject;
            //    var bindObj = playableDirector.GetGenericBinding(sourceObject);
            //    //根据绑定键获取当前轨道绑定物体的名称
            //    if (!bindObj)
            //    {
            //        Debug.LogError("轨道错误");
            //        return;
            //    }
            //    if (sourceObject is ActorTrack)//判断轨道
            //    {
            //        var targetObj = (bindObj as GameObject);
            //        if (targetObj)
            //        {
            //            ActorData myData = new ActorData();
            //            myData.actorPos = targetObj.transform.position;
            //            myData.ID = i;
            //            actorDatas.Add(myData);
            //        }

            //    }
            //    else if (sourceObject is AnimationTrack)
            //    {
            //        if (bindObj is Animator)
            //        {
            //            ActorData myData = new ActorData();
            //            var targetObj = (bindObj as Animator).gameObject;
            //            List<ActorAnimationClip> clips = new List<ActorAnimationClip>();
            //            var aninationTrack = (AnimationTrack)sourceObject;
            //            foreach (var clip in aninationTrack.GetClips())
            //            {
            //                if (!clip.animationClip)
            //                {
            //                    return;
            //                }
            //                ActorAnimationClip c = new ActorAnimationClip();
            //                c.start = clip.start;
            //                c.duration = clip.duration;
            //                c.end = clip.end;
            //                c.animationClipName = clip.animationClip.name;
            //                c.clipIn = clip.clipIn;
            //                clips.Add(c);
            //            }
            //            myData.clips = clips.ToArray();
            //            actorDatas.Add(myData);
            //        }
            //    }
            //}
            
            foreach (PlayableBinding bind in timelineAsset.outputs)
            {
                //Debug.Log($"bind:{bind.streamName}");
                //Debug.Log($"bind:{bind.outputTargetType}");
                //if (bind.streamName == "Markers" )//新版unity的Markers轨道，bind.sourceObject为空
                //    continue;
                var bindObj = playableDirector.GetGenericBinding(bind.sourceObject);
                if (!bindObj)
                {
                    continue;
                }
                i++;
               
                if (bind.sourceObject is ActorTrack)//判断轨道
                {
                    var targetObj = (bindObj as GameObject);
                    if (targetObj)
                    {
                        ActorData myData = new ActorData();
                        myData.actorPos = targetObj.transform.position;
                        myData.aoi_id = i;
                        actorDatas.Add(myData);
                    }

                }
                else if (bind.sourceObject is AnimationTrack)
                {
                    if (bindObj is Animator)
                    {
                        ActorData myData = new ActorData();
                        var targetObj = (bindObj as Animator).gameObject;
                        List<ActorAnimationClip> clips = new List<ActorAnimationClip>();
                        var aninationTrack = (AnimationTrack)bind.sourceObject;
                        foreach (var clip in aninationTrack.GetClips())
                        {
                            if (!clip.animationClip)
                            {
                                return;
                            }
                            ActorAnimationClip c = new ActorAnimationClip();
                            c.start = clip.start;
                            c.duration = clip.duration;
                            c.end = clip.end;
                            c.animationClipName = clip.animationClip.name;
                            c.clipIn = clip.clipIn;
                            clips.Add(c);
                        }
                        myData.clips = clips.ToArray();
                        actorDatas.Add(myData);
                    }
                }
             }
            data.actorDatas = actorDatas.ToArray();
            AssetDatabase.CreateAsset(data,
                "assets/Resources/timeline/" + System.IO.Path.GetFileNameWithoutExtension(fileName)+".asset");
            Debug.Log("timeline保存成功");
        }

        
    }
}
