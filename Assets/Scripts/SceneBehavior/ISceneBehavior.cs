using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public interface ISceneBehavior
{

    //场景
    void InitScene();//初始化
    void EnterScene();//进入
    void LeaveScene();//离开

    //玩法
    void InitBehavior();//初始化
    void EnterBehavior();
    void LeaveBehavior();




}

