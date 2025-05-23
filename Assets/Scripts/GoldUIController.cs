using UnityEngine;
using TMPro;

public class GoldUIController : MonoBehaviour
{
    public TextMeshProUGUI currentGoldText;

    private void Start()
    {
        // 코드로도 이벤트 리스너 등록 가능
        GoldManager.Instance.OnGoldChanged.AddListener(UpdateGoldUI);
    }

    // 인스펙터에서 연결 가능한 public 메서드
    public void UpdateGoldUI(int newGold)
    {
        if (currentGoldText != null)
        {
            currentGoldText.text = $"{newGold}G";
        }
    }
}

