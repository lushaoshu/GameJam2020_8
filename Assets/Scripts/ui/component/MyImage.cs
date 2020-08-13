using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

[AddComponentMenu("UI/MyImage",0)]
public class MyImage : Image
{
    [SerializeField]
    private bool isFade = false;

    public bool IsFade { get => isFade; set { isFade = value; OnInit(); }  }

    public override Material material
    {
        get
        {
            if (isFade)
            {
                return m_fade_ui_mat;
            }
            else
            {
                return base.material;
            }
        }
    }

    static Material _fade_ui_mat = null;
    public static Material m_fade_ui_mat
    {
        get
        {
            if (!_fade_ui_mat)
            {
                _fade_ui_mat = new Material(Shader.Find("自定义/灰度"));
                _fade_ui_mat.hideFlags = HideFlags.DontSave;
                _fade_ui_mat.enableInstancing = true;
                _fade_ui_mat.name = "UI_Img Fade Alpha";
            }
            return _fade_ui_mat;
        }
    }


    static Material _default_ui_mat = null;
    public static Material m_default_ui_mat
    {
        get
        {
            if (!_default_ui_mat)
            {
                _fade_ui_mat = new Material(Shader.Find("UI/Default"));
                _fade_ui_mat.hideFlags = HideFlags.DontSave;
                _fade_ui_mat.enableInstancing = true;
                _fade_ui_mat.name = "UIDefault";
            }
            return _default_ui_mat;
        }
    }

    void OnInit()
    {
        if (!gameObject.activeInHierarchy) return;

        SetAllDirty();

    }
    [MenuItem("GameObject/UI/MyImage", priority = 0)]
    public static void CreateMyImageText()
    {
        Transform par = null;
        if (Selection.gameObjects.Length > 0)
        {
            par = Selection.gameObjects[0].transform;
            if (AssetDatabase.Contains(par.gameObject))
            {
                par = null;
            }
        }
        GameObject go = new GameObject("MyImage");
        go.transform.SetParent(par);
        go.AddComponent<MyImage>();
        RectTransform rt = go.transform as RectTransform;
        rt.localScale = Vector3.one;
        rt.localPosition = Vector3.zero;
        rt.sizeDelta = new Vector3(100f, 100f);
        EditorGUIUtility.PingObject(go);
    }


}
