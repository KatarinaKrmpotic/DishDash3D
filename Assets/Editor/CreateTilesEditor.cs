using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CreateTilesEditor : EditorWindow
{
    [MenuItem("Game/CreateCubes")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(CreateTilesEditor));
    }

    static GameObject cube;
    static int width;

    void OnGUI()
    {
        cube = (GameObject)EditorGUILayout.ObjectField(cube, typeof(GameObject), true);
        width = (int)EditorGUILayout.IntField(width);

        if (GUILayout.Button("create"))
        {
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    var go = Instantiate(cube);
                    go.transform.position = new Vector3(i, 0.0f, j);
                    go.transform.rotation = Quaternion.identity;
                }
            }
        }
    }
}
