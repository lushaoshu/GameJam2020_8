using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

static class TransformUtils
{
    /// <summary>
    /// GameObject扩展方法
    /// </summary>
    /// <param name="go"></param>
    /// <param name="id"></param>
    /// <returns></returns>
    public static GameObject FindChild(this GameObject go, string id)
    {
        if (go == null)
        {
            Debug.LogError("FindChild,go is null");
            return null;
        }
        var t = FindChild(go.transform, id);


        return t != null ? t.gameObject : null;
    }
    /// <summary>
    /// GameObject扩展方法
    /// </summary>
    /// <param name="go"></param>
    /// <param name="id"></param>
    /// <returns></returns>
    public static obj FindChild<obj>(this GameObject go, string id) where obj: Component
    {
        if (go == null)
        {
            Debug.LogError("FindChild,go is null");
            return null;
        }
        var t = FindChild(go.transform, id);
        if (t != null)
        {
            return t.GetComponent<obj>();
        }
        else {
            return null;
        }
    }
    /// <summary>
    /// 根据id查找
    /// </summary>
    /// <param name="t"></param>
    /// <param name="id"></param>
    /// <returns></returns>
    static Transform FindChild(Transform t, string id)
    {
        if (id == ".") return t;//查找自己
        //用/分割路径
        if (id.IndexOf("/") >= 0)
        {
            var arr = id.Split('/');
            foreach (var a in arr)
            {
                t = FindChildDirectByQueue(t,a);
                //t = FindChildDirectByRecursive(t, a);
                if (t == null)
                {
                    Debug.LogError("FindChild failed ,id:" + id);
                    break;
                }
            }
            return t;
        }
        //直接查找
        t = FindChildDirectByQueue(t, id);
        //t = FindChildDirectByRecursive(t, id);
        if (t == null)
        {
            Debug.LogError("FindChild failed ,id:" + id);
        }
        return t;
    }
    /// <summary>
    /// 直接查找
    /// </summary>
    /// <param name="t"></param>
    /// <param name="id"></param>
    /// <returns></returns>
    static Transform FindChildDirectByQueue(Transform t, string id)
    {
        var queue = s_findchild_stack;
        queue.Enqueue(t);//进入队列，放到队列的最后

        while (queue.Count > 0)
        {
            t = queue.Dequeue();//取出队列第一个元素
            var t2 = t.Find(id);
            if (t2 != null)
            {
                queue.Clear();
                return t2;
            }
            for (int i = 0, count = t.childCount; i < count; i++)
            {
                t2 = t.GetChild(i);
                queue.Enqueue(t2);
            }
        }
        return null;
    }
    static Queue<Transform> s_findchild_stack = new Queue<Transform>();

    public static RectTransform GetRectTransform(this GameObject obj)
    {
        if (!obj)
            return null;
        return obj.transform as RectTransform;
    }
}
