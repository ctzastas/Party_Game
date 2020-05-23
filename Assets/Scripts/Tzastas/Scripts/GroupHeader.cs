using UnityEngine;
using UnityEditor;

/*[InitializeOnLoad]
public class GroupHeader : MonoBehaviour {
         
    static GroupHeader() {
        EditorApplication.hierarchyWindowItemOnGUI += HierarchyWindowItemOnGUI;
    }
         
    static void HierarchyWindowItemOnGUI(int instanceID, Rect selectionRect) {
        var gameObject = EditorUtility.InstanceIDToObject(instanceID) as GameObject;
        if (gameObject != null && gameObject.name.StartsWith("---", System.StringComparison.Ordinal)) {
            EditorGUI.DrawRect(selectionRect,Color.gray);
            EditorGUI.DropShadowLabel(selectionRect,gameObject.name.Replace("-", "").ToUpperInvariant());
        }
    }
}*/