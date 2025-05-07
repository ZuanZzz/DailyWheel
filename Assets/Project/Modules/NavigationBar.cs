using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NavigationBar : MonoBehaviour
{
    [System.Serializable]
    private struct NavEntry
    {
        public Button Button;
        public GameObject Page;
    }

    [SerializeField] private List<NavEntry> navigationEntries;

    private Dictionary<Button, GameObject> _navMap;
    private GameObject _currentPage;

    private void Awake()
    {
        _navMap = new Dictionary<Button, GameObject>();

        foreach (var entry in navigationEntries)
        {
            if (entry.Button == null || entry.Page == null)
            {
                Debug.LogWarning("Navigation entry incomplete.");
                continue;
            }

            _navMap.Add(entry.Button, entry.Page);
            entry.Button.onClick.AddListener(() => OnNavButtonClicked(entry.Button));
        }

        // 默认激活第一个页面
        if (navigationEntries.Count > 0)
        {
            SwitchToPage(navigationEntries[0].Page);
        }
    }

    private void OnNavButtonClicked(Button button)
    {
        if (_navMap.TryGetValue(button, out GameObject targetPage))
        {
            SwitchToPage(targetPage);
        }
    }

    private void SwitchToPage(GameObject targetPage)
    {
        if (_currentPage == targetPage) return;

        foreach (var kvp in _navMap)
        {
            kvp.Value.SetActive(false);
        }

        targetPage.SetActive(true);
        _currentPage = targetPage;
    }
}

