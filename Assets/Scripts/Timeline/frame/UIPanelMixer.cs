using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Playables;
/// <summary>
/// 整个轨道的行为
/// </summary>
public class UIPanelMixer : PlayableAsset,IPlayableBehaviour
{
    UIPanelPlayableBehaviour controlBehaviour = new UIPanelPlayableBehaviour();
    public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
    {
        return ScriptPlayable<UIPanelPlayableBehaviour>.Create(graph, controlBehaviour);
    }

    public void OnBehaviourPause(Playable playable, FrameData info)
    {
       
    }

    public void OnBehaviourPlay(Playable playable, FrameData info)
    {
       
    }

    public void OnGraphStart(Playable playable)
    {
       
    }

    public void OnGraphStop(Playable playable)
    {
       
    }

    public void OnPlayableCreate(Playable playable)
    {
       
    }

    public void OnPlayableDestroy(Playable playable)
    {
      
    }

    public void PrepareFrame(Playable playable, FrameData info)
    {
      
    }

    public void ProcessFrame(Playable playable, FrameData info, object playerData)
    {
        int inputCount = playable.GetInputCount();
        float time = (float)playable.GetGraph().GetRootPlayable(0).GetTime();
        for (int i = 0; i < inputCount; i++)
        {
            ScriptPlayable<UIPanelPlayableBehaviour> inputPlayable = (ScriptPlayable <UIPanelPlayableBehaviour>) playable.GetInput(i);
            UIPanelPlayableBehaviour input = inputPlayable.GetBehaviour();
            input.UpdateBehaviour(time,i,inputCount);
        }

    }
}