using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
/// <summary>
/// 对剧情中对象的封装
/// </summary>
public class ScenarioObjController
{
    public GameObject gameObject;
    public ScenarioObjController(GameObject gameObject) {
        this.gameObject = gameObject;
    }
}