using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public abstract class SceneBehavior<M> : SmartControl<M>, ISceneBehavior where M : Model, new()
{
    
    public virtual void EnterBehavior()
    {

    }

    public virtual void EnterScene()
    {

    }

    public virtual void InitBehavior()
    {

    }

    public virtual void InitScene()
    {

    }

    public virtual void LeaveBehavior()
    {
        //销毁场景中所有创建的对象

    }

    public virtual void LeaveScene()
    {
 
    }
}

