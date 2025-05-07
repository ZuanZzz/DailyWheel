using System.Collections.Generic;
using UnityEngine;
using Project.Models.TestTasks;

public class TaskManager : MonoBehaviour
{
    public WheelGenerator wheelGenerator; // 引用转盘生成器
    public TestTasks TestTasks; // 静态任务数据

    void Start()
    {
        // 生成转盘
        wheelGenerator.GenerateWheel(TestTasks.tasks);
    }
}