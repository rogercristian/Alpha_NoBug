using UnityEditor;
using UnityEngine;

public class CustomHeaderObjects : MonoBehaviour
{
    public Color textColor = Color.black;
    public Color backgroundColor = Color.white;

    public void OnValidate()
    {
        EditorApplication.RepaintHierarchyWindow();
    }
}
