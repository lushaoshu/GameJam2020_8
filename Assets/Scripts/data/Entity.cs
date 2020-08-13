using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System;

namespace Entity
{
    public class SceneBase
    {
        public int id;
        public string res;
        public string name;
        public Vector3 player_pos;
        public bool is_tset;//是否为测试地图
    }

    //对话配置
    public class TalkBase
    {
        public int id;
        public int time;//默认是当字体显示完
        public string text;
        public List<TalkBtnBase> btnCall;
        public TaskTypeDefs taskType;
        public float errerTime;
    }
    //NPC配置
    public class NPCBase
    {
        public int id;
        public int aoi_id;
        public string OpeningRemarksText;//开场白
        public string EveryDayText;//每日对话
        public Dictionary<string, List<TalkDescriptionBase>> TaskeText;//任务对话   key 任务id，value  对话描述配置的List
        public Dictionary<string, int> SeeStatus;//角色可见任务状态

    }
    //对话描述配置
    public class TalkDescriptionBase
    {
        public int id;
        public int aoi_id;//说对话的人
    }
    //对话选项配置
    public class TalkBtnBase
    {
        public string text;
        public int param;//参数
    }

    public class TaskBase
    {
        public int id;
        public int next_taske_id;
        public int before_taske_id;
        public string name;
        public List<int> rewards_id;
        public int scene_id;
        public int npc_id;

    }
    /// <summary>
    /// 对应每一个对象
    /// </summary>
    public class AOIBase
    {
        public int id;
        public string res;//prefeb 路径
    }

    public static class TaskStatusDefs
    {
        public static int enableReceive;//可接去
        public static int tasking;//正在完成
        public static int end;//完成

    }

    public enum TaskTypeDefs
    {
        tv = 1,//电视广播
        qipao = 2,//气泡
        quanxiang = 3,//小选项
        pangbai = 4,//旁白
        task = 5//主线剧情
    }

    public static class ResPathDefs
    {
        public static string AOI_PETH = "Prefabs/";
    }
}