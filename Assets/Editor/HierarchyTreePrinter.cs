using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.Text;

public class HierarchyTreePrinter
{
    [MenuItem("Tools/Print Hierarchy Tree %#t")] // Ctrl+Shift+T
    public static void PrintSelectedHierarchyTree()
    {
        GameObject[] selectedObjects = Selection.gameObjects;

        if (selectedObjects.Length == 0)
        {
            Debug.LogWarning("请先在 Hierarchy 中选择一个或多个物体。");
            return;
        }

        // 构建输出字符串
        StringBuilder sb = new StringBuilder();

        // 排序选中的物体（按层级顺序）
        List<GameObject> sortedObjects = new List<GameObject>(selectedObjects);
        sortedObjects.Sort((a, b) => string.Compare(a.transform.GetSiblingIndex().ToString(), b.transform.GetSiblingIndex().ToString()));

        foreach (GameObject go in sortedObjects)
        {
            PrintHierarchy(go.transform, "", true, sb);
        }

        Debug.Log(sb.ToString());
    }

    private static void PrintHierarchy(Transform transform, string indent, bool isLast, StringBuilder sb)
    {
        string pointer = isLast ? "└── " : "├── ";
        sb.AppendLine(indent + pointer + transform.name);

        indent += isLast ? "    " : "│   ";

        int childCount = transform.childCount;
        for (int i = 0; i < childCount; i++)
        {
            bool last = (i == childCount - 1);
            PrintHierarchy(transform.GetChild(i), indent, last, sb);
        }
    }
}
