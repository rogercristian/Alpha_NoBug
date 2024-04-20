using UnityEditor;
using UnityEngine;

public class CustomHierarchyMenu : EditorWindow
{
    [MenuItem("GameObject/Create Custom Header")]
    static void CreatCustomHeader(MenuCommand menuCommand)
    {
        GameObject obj = new GameObject("Header");
        Undo.RegisterCreatedObjectUndo(obj, "Create Custom Header");
        GameObjectUtility.SetParentAndAlign(obj, menuCommand.context as GameObject);
        obj.AddComponent<CustomHeaderObjects>();

        Selection.activeGameObject = obj;
    }
}
