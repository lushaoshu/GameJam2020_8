using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class SceneModel :SmartModel<SceneControl>
{
    public SceneBase Cur_Data
    {
        get
        {
            return DB.SceneBaseMap[control._cur_scene_id];
        }
    }

}

