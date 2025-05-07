using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class WheelGenerator : MonoBehaviour
{
    public GameObject sectorPrefab; // 扇形预制体
    public Transform wheelRoot;     // 转盘中心


    public void GenerateWheel(List<Task> tasks)
    {
        //计算权重
        float totalWeight = 0f;
        foreach (var task in tasks)
        {
            totalWeight += task.weight;
        }

        float currentAngle = 0f;
        foreach (var task in tasks)
        {
            // 计算每个任务的弧度
            float anglePerTask = (task.weight / totalWeight) * 360f;

            // 创建扇形并设置其旋转角度
            GameObject sector = Instantiate(sectorPrefab, wheelRoot);
            sector.transform.localRotation = Quaternion.Euler(0, 0, -currentAngle);

            // 设置扇形的名称和图标
            TextMeshProUGUI text = sector.GetComponentInChildren<TextMeshProUGUI>();
            if (text != null)
            {
                text.text = task.name;
            }

            SpriteRenderer icon = sector.GetComponentInChildren<SpriteRenderer>();
            if (icon != null && task.icon != null)
            {
                icon.sprite = task.icon;
            }

            currentAngle += anglePerTask;
        }
    }
}

