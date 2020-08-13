using Entity;
using System;

using System.Threading.Tasks;
using UnityEngine;

public class TalksControl : SmartControl<TalksModel>
{

    public override void OnAppInit()
    {
        base.OnAppInit();
        // MyGUIManager.GetInstance().GetOrCreatePanel<TVTipsPanel>().Display(true);
        // MyGUIManager.GetInstance().GetOrCreatePanel<QipaoTipsPanel>().Display(true);
        //MyGUIManager.GetInstance().GetOrCreatePanel<WalkTipsPanel>().Display(true);
        // MyGUIManager.GetInstance().GetOrCreatePanel<TaskTipsPanel>().Display(true);
         
        //ShowTips(DB.TalkBaseMap[1]);
    }


    public void ShowTips(int id) {
        TalkBase config = DB.TalkBaseMap[id];
        switch (config.taskType) {
            case TaskTypeDefs.tv:
                MyGUIManager.GetInstance().GetOrCreatePanel<TVTipsPanel>().Display(true);
                break;
            case TaskTypeDefs.task:
                var _task_panel = MyGUIManager.GetInstance().GetOrCreatePanel<MainTaskTipsPanel>();
                _task_panel.InitData(config, Vector2.zero);
                _task_panel.Display(true);
                break;
            case TaskTypeDefs.quanxiang:
                var panel=MyGUIManager.GetInstance().GetOrCreatePanel<WalkTipsPanel>();
                panel.InitData(config, Vector2.zero);
                panel.Display(true);
                break;
            case TaskTypeDefs.qipao:
                MyGUIManager.GetInstance().GetOrCreatePanel<QipaoTipsPanel>().Display(true);
                break;
            case TaskTypeDefs.pangbai:
                MyGUIManager.GetInstance().GetOrCreatePanel<PangbaiTipsPanel>().Display(true);
                break;
            default:
                Debug.LogError("ShowTips--没有定义该类型的tips");
                break;
        }

    }
}

