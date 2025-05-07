
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Project.Models.TestTasks;

public class WheelSpinDOTween : MonoBehaviour
{
    public Transform wheelRoot;
    public Button spinButton;
    public float spinDuration = 4f;
    private bool isSpinning = false;

    public TestTasks TestTasks; // 静态任务数据

    void Start()
    {
        spinButton.onClick.AddListener(() => Spin(TestTasks.tasks));
    }

    public void Spin(List<Task> tasks)
    {
        if (isSpinning) return;
        isSpinning = true;

        //计算权重
        float totalWeight = 0f;
        foreach (var task in tasks)
        {
            totalWeight += task.weight;
        }

        int randomSector = Random.Range(0, tasks.Count); // 随机选择一个扇区
        float startAngle = wheelRoot.eulerAngles.z; // 获取当前角度
        float offsetAngle = 360f / totalWeight * tasks[randomSector].weight; // 计算偏移角度
        float targetAngle = startAngle + offsetAngle + 360f * Random.Range(3, 6); // 目标角度

        wheelRoot.DORotate(
            new Vector3(0, 0, -targetAngle), // Z轴逆时针旋转
            spinDuration,
            RotateMode.FastBeyond360
        )
        .SetEase(Ease.OutQuart) // 缓动效果（你也可以换成 Ease.OutBack、OutCirc 等）
        .OnComplete(() =>
        {
            isSpinning = false;
            Debug.Log("Stop at sector: " + randomSector);
            // TODO: 你可以在这里触发中奖逻辑
        });
    }
}
