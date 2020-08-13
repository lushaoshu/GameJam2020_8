using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class MyGUIManager :MonoBehaviour
{
    static MyGUIManager _instance;
    Dictionary<Type, PanelBase> m_panelMap = null;
    public static MyGUIManager GetInstance() {
        if (_instance==null) {
            GameObject go = new GameObject("UI Root", typeof(RectTransform));
            _instance = go.AddComponent<MyGUIManager>();
        }
        return _instance;
    }

    public T GetOrCreatePanel<T>() where T : PanelBase, new()
    {
        if (m_panelMap == null) m_panelMap = new Dictionary<Type, PanelBase>();
        if (m_panelMap.ContainsKey(typeof(T)))
            return m_panelMap[typeof(T)] as T;
        T panel = new T();
        m_panelMap[typeof(T)] = panel;
        return panel;
    }
    public T GetExistPanel<T>() where T : PanelBase, new()
    {
        if (m_panelMap == null) return null;
        if (m_panelMap.ContainsKey(typeof(T)))
            return m_panelMap[typeof(T)] as T;
        return null;
    }
    public void AddPanelObject(MyPanel panel) {
        if (!panel.gameObject) return;
        panel.gameObject.transform.SetParent(transform);
    }
}

