using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(AspectUtility))]
public class AspectUtilityEditor : Editor
{
    Vector2 res;
    public override void OnInspectorGUI(){
        base.OnInspectorGUI();
        EditorGUILayout.LabelField("Screen Width: " + res.x.ToString());
        EditorGUILayout.LabelField("Screen Height: " + res.y.ToString());
        if(GUILayout.Button("Refresh")){
            RefreshResolution();
        }
        if(GUILayout.Button("Set Camera")){
            AspectUtility tgt = target as AspectUtility;
            RefreshResolution();
            tgt.SetTheCamera(res);
        }
        if(GUILayout.Button("Refresh Canvas")){
            RefreshResolution();
            Canvas.ForceUpdateCanvases();
        }
    }

    void RefreshResolution(){
        System.Type T = System.Type.GetType("UnityEditor.GameView,UnityEditor");
        System.Reflection.MethodInfo GetSizeOfMainGameView = T.GetMethod("GetSizeOfMainGameView",System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);
        System.Object Res = GetSizeOfMainGameView.Invoke(null,null);
        res = (Vector2)Res;
    }

}