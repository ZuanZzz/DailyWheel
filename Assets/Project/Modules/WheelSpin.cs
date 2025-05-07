using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WheelSpin : MonoBehaviour
{
    public Transform wheelRoot;      // 转盘的根节点（空物体）
    public Button spinButton;        // 控制旋转的按钮
    public int sectorCount = 8;      // 扇形数量
    public float spinDuration = 4f;  // 旋转时间
    private bool isSpinning = false;

    void Start()
    {
        spinButton.onClick.AddListener(Spin);
    }

    public void Spin()
    {
        if (isSpinning) return;

        isSpinning = true;
        int randomSector = Random.Range(0, sectorCount);      // 随机中奖编号
        float sectorAngle = 360f / sectorCount;
        float targetAngle = 360f * Random.Range(3, 6) + (randomSector * sectorAngle); // 多圈 + 停在指定扇区

        StartCoroutine(SpinWheel(targetAngle));
    }

    private IEnumerator SpinWheel(float angle)
    {
        float startAngle = wheelRoot.eulerAngles.z;
        float endAngle = startAngle - angle;  // Unity 的旋转是逆时针为正
        float elapsed = 0f;

        while (elapsed < spinDuration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / spinDuration;
            // 缓动函数：先快后慢（ease out）
            float eased = 1f - Mathf.Pow(1f - t, 3f);
            float currentAngle = Mathf.Lerp(startAngle, endAngle, eased);
            wheelRoot.eulerAngles = new Vector3(0f, 0f, currentAngle);
            yield return null;
        }

        wheelRoot.eulerAngles = new Vector3(0f, 0f, endAngle);  // 精准落位
        isSpinning = false;
        // 你可以在这里添加中奖逻辑，比如弹出面板
    }
}
