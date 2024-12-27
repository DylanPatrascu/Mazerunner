using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SnapperTool : EditorWindow
{
    public float gridSize = 1f;
    public Color gridColor = Color.blue;
    SerializedObject so;
    SerializedProperty propGridSize;
    SerializedProperty propGridColor;


    [MenuItem("Tools/Snapper")]
    public static void OpenMenu() => GetWindow<SnapperTool>("Snapper");

    void OnEnable()
    {
        so = new SerializedObject(this);
        propGridSize = so.FindProperty("gridSize");
        propGridColor = so.FindProperty("gridColor");
        Selection.selectionChanged += Repaint;
        SceneView.duringSceneGui += DuringSceneGUI;
    }
    void OnDisable()
    {
        Selection.selectionChanged -= Repaint;
        SceneView.duringSceneGui -= DuringSceneGUI;

    }

    void DuringSceneGUI(SceneView sceneView)
    {
        Handles.zTest = UnityEngine.Rendering.CompareFunction.LessEqual;

        const float gridDrawExtent = 16;
        int lineCount = Mathf.RoundToInt((gridDrawExtent * 2) / gridSize);
        if (lineCount % 2 == 0) lineCount++;
        int halfLineCount = lineCount / 2;

        Handles.color = gridColor;

        for (int i = 0; i < lineCount; i++)
        {
            int intOffset = i - halfLineCount;
            float xCoord = intOffset * gridSize;
            float zCoord0 = halfLineCount * gridSize;
            float zCoord1 = -halfLineCount * gridSize;
            Vector3 p0 = new Vector3(xCoord, 0f, zCoord0);
            Vector3 p1 = new Vector3(xCoord, 0f, zCoord1);
            Handles.DrawAAPolyLine(p0, p1);
            p0 = new Vector3(zCoord0, 0f, xCoord);
            p1 = new Vector3(zCoord1, 0f, xCoord);
            Handles.DrawAAPolyLine(p0, p1);
            /*
            p0 = new Vector3(xCoord, zCoord0, 0f);
            p1 = new Vector3(xCoord, zCoord1, 0f);
            Handles.DrawAAPolyLine(p0, p1);
            p0 = new Vector3(zCoord0, xCoord, 0f);
            p1 = new Vector3(zCoord1, xCoord, 0f);
            Handles.DrawAAPolyLine(p0, p1);*/
        }
    }

    void OnGUI()
    {
        so.Update();
        EditorGUILayout.PropertyField(propGridSize);
        EditorGUILayout.PropertyField(propGridColor);

        so.ApplyModifiedProperties();
        using (new EditorGUI.DisabledScope(Selection.gameObjects.Length == 0))
        {
            if (GUILayout.Button("Snap Selection"))
            {
                SnapSelection();
            }
        }

    }
    void SnapSelection()
    {
        foreach (GameObject go in Selection.gameObjects)
        {
            Undo.RecordObject(go.transform, "Snap Objects");
            go.transform.position = go.transform.position.Round(gridSize);
        }
    }

}
