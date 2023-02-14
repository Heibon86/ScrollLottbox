using Configs;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ScrollItemTable))]
public class ScrollItemTableEditor : Editor
{
    public override void OnInspectorGUI()
    {
        var scrollItemTable = target as ScrollItemTable;

        base.OnInspectorGUI();

        if (scrollItemTable.GetScrollItemAmount() < scrollItemTable.MinScrollItemAmount)
        {
            var guiStyle = new GUIStyle();
            guiStyle.normal.textColor = Color.red;
            GUILayout.Label("Capacity Scroll Item Settings", guiStyle);
        }
    }
}
