using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[System.Serializable]
/// <summary>
/// 片段的行为
/// </summary>
public class MyPlayableBehaviour : PlayableBehaviour
{
    [HideInInspector]
    public ActorTrack parentTrack;//所在的轨道
    [HideInInspector]
    public TimelineClip OwningClip;
    [HideInInspector]
    public MyPlayableAsset tirggerTimelineClip;
    [HideInInspector]
    public GameObject targetObject;

    private bool m_isFirstFrameProcess = false;
    /// <summary>
    /// 进入片段后，每帧执行
    /// </summary>
    /// <param name="playable"></param>
    /// <param name="info"></param>
    /// <param name="playerData">绑定的对象</param>
    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {
       
    }
    /// <summary>
    /// 准备阶段每帧执行
    /// </summary>
    /// <param name="playable"></param>
    /// <param name="info"></param>
    public override void PrepareFrame(Playable playable, FrameData info)
    {
        base.PrepareFrame(playable, info);
    }
    //片段开始播放
    public override void OnBehaviourPlay(Playable playable, FrameData info)
    {
        base.OnBehaviourPlay(playable, info);
    }
    //片段播放停止，首次会执行一次
    public override void OnBehaviourPause(Playable playable, FrameData info)
    {
        base.OnBehaviourPause(playable, info);
    }

    public override void OnBehaviourDelay(Playable playable, FrameData info)
    {
        base.OnBehaviourDelay(playable, info);
    }
    //整个轨道开始
    public override void OnGraphStart(Playable playable)
    {
        base.OnGraphStart(playable);
        m_isFirstFrameProcess = false;
    }
    //整个轨道结束
    public override void OnGraphStop(Playable playable)
    {
        base.OnGraphStop(playable);

    }

    public void UpdateBehaviour(float time , int cur_idx, int total_clip) {

        if ((time >= OwningClip.start) && (time < OwningClip.end))
        {
            OnEnter();
        }
        else {
            OnExit();
        }
    }

    private void OnEnter() {
        if (!m_isFirstFrameProcess)
        {
            
            //if (targetObject)
            //    targetObject.SendMessage("_onTimelineEnter", tirggerTimelineClip);
            m_isFirstFrameProcess = true;
            //GameObject.Find("timeline").GetComponent<PlayableDirector>().Pause();
            //GameObject.Find("timeline").GetComponent<PlayableDirector>().Resume();
            //GameObject.Find("timeline").GetComponent<PlayableDirector>().Play();
        }
    }

    private void OnExit() {
        if (m_isFirstFrameProcess)
        {
           
            m_isFirstFrameProcess = false;
        }
    }
}
