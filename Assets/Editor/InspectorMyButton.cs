using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine.UI;

[CustomEditor(typeof(MyButton))]
public class InspectorMyButton : Editor
{

    MyButton myButton;
    private void OnEnable()
    {
        myButton = (MyButton)target;
    }


    //public override void OnInspectorGUI()
    //{
    //    base.OnInspectorGUI();

    //    myButton.sound_event = EditorGUILayout.TextField("sound_event", myButton.sound_event);
    //}
}