using UnityEngine;
using UnityEditor;

public class MainCityBehavior : SceneBehavior<MainCityModel>
{
    public override void OnAppInit()
    {
        base.OnAppInit();
        LogicMM.sceneControl.RegisterBehavior(0,this);
    }

    public override void LeaveBehavior()
    {
        base.LeaveBehavior();
    }


}