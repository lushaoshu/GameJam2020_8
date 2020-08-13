using UnityEngine;
using UnityEditor;
/// <summary>
/// 测试场景
/// </summary>
public class TestScene : SceneBehavior<TestSceneModel>
{
    public override void OnAppInit()
    {
        base.OnAppInit();
        LogicMM.sceneControl.RegisterBehavior(2,this);
    }

    public override void LeaveBehavior()
    {
        base.LeaveBehavior();
    }


}