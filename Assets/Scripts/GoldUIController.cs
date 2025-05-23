using UnityEngine;
using TMPro;

public class GoldUIController : MonoBehaviour
{
    public TextMeshProUGUI currentGoldText;

    private void Start()
    {
        GoldManager.Instance.OnGoldChanged.AddListener(UpdateGoldText);
    }

    private void UpdateGoldText(int newGold)
    {
        currentGoldText.text = $"{newGold}G";
    }
}
