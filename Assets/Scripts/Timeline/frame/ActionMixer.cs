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
public class ActionMixer : PlayableAsset,IPlayableBehaviour
{
    MyPlayableBehaviour controlBehaviour = new MyPlayableBehaviour();
    public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
    {
        return ScriptPlayable<MyPlayableBehaviour>.Create(graph, controlBehaviour);
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
            ScriptPlayable<MyPlayableBehaviour> inputPlayable = (ScriptPlayable < MyPlayableBehaviour >) playable.GetInput(i);
            MyPlayableBehaviour inout = inputPlayable.GetBehaviour();
            inout.UpdateBehaviour(time,i,inputCount);
        }

    }
}