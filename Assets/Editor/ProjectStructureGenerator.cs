// 放在 Assets/Editor 文件夹中
using UnityEditor;
using UnityEngine;
using System.IO;

public class ProjectStructureGenerator
{
    [MenuItem("Tools/Generate Project Structure")]
    public static void GenerateStructure()
    {
        string[] folders = new string[]
        {
            "Assets/Project",
            "Assets/Project/Core",
            "Assets/Project/UI",
            "Assets/Project/Modules",
            "Assets/Project/Animations",
            "Assets/Project/Audio",
            "Assets/Project/PlatformBridge",
            "Assets/Project/Data",

            "Assets/Art",
            "Assets/Art/Sprites",
            "Assets/Art/Icons",
            "Assets/Art/Fonts",
            "Assets/Art/UI",

            "Assets/Scenes",
            "Assets/Prefabs",
            "Assets/Resources",
            "Assets/Plugins",
            "Assets/Editor", // 确保本脚本在这里

            "Documentation",
            "Documentation/DevLogs",
            "Documentation/DesignSpecs"
        };

        foreach (var folder in folders)
        {
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
                Debug.Log($"✅ Created: {folder}");
            }
            else
            {
                Debug.Log($"🔸 Exists: {folder}");
            }
        }

        // 创建一些初始文档（可选）
        // CreateTextFile("Documentation/Architecture.md", "# Architecture Design\n\nDescribe your system modules here.");
        // CreateTextFile("Documentation/SetupGuide.md", "# Setup Guide\n\nWrite environment setup instructions here.");
        // CreateTextFile("Documentation/DataFormat.md", "# Data Format\n\nDefine your saved data schema here.");
        // CreateTextFile("Documentation/NativeBridge.md", "# Native Bridge\n\nDocument native API calls here.");
        // CreateTextFile("Documentation/DevLogs/2025-05-06.md", "# Dev Log: 2025-05-06\n\n- Initial setup complete.\n- Structure generated.\n");

        AssetDatabase.Refresh();
        Debug.Log("✅ Project folder structure generated!");
    }

    private static void CreateTextFile(string path, string content)
    {
        if (!File.Exists(path))
        {
            File.WriteAllText(path, content);
            Debug.Log($"📝 Created file: {path}");
        }
    }
}


// 后期扩展设想：
// 自动生成模块模板代码（例如 TaskModule.cs，带注释和架构说明）。

// 支持自定义命名空间或作者标签。

// 集成 Git 初始化与 .gitignore 创建。

// 扩展脚本式“新模块创建器”，点击按钮快速新建一个模块结构。