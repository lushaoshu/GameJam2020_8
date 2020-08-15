using Entity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class RoleControl : SmartControl<RoleModel>
{
    public GameObject root;

    public GameObject CreatRole(int aoi_id) {
        var config = DB.AOIBaseMap[aoi_id];
        var _gameObject = GameObject.Instantiate(Resources.Load<GameObject>(ResPathDefs.AOI_PETH + config.res));
        if (!_gameObject) Debug.Log($"{config.res},Resources中找不到");
        //创建根节点
        if (!root)
        {
            root = new GameObject("aoi_root");
        }
        _gameObject.transform.parent = root.transform;
        _gameObject.transform.position = Vector3.zero;
        _gameObject.name = config.id.ToString();
        return _gameObject;
    }

    public override void OnAppInit()
    {
        base.OnAppInit();
        //GameMng.instance.StartCoroutine(StarTimeline());
    }

    //private IEnumerator StarTimeline() {
    //    var timeline =TimelineManager.GetOrCreatInstance().AddScenarioTimeline("timeline/test");
    //    while (!timeline.isInitOk)
    //    {
    //        yield return null;
    //    }
    //    timeline.StartPlay();
    //}
}