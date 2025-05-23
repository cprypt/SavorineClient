using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WeaponUpgradeManager : MonoBehaviour
{
    [Header("UI Elements")]
    public GameObject weaponPage;
    public GameObject weaponResultPage;
    public Image originalWeapon;
    public Image newWeapon;
    public Image resultImage;
    public TextMeshProUGUI upgradeCostText;
    public TextMeshProUGUI requiredExpText;
    public TextMeshProUGUI upgradeChanceText;
    public TextMeshProUGUI upgradeMessageText;

    [Header("Upgrade Settings")]
    public int upgradeCost = 100;
    public int requiredExp = 50;
    public float successChance = 0.7f;  // 70% 확률

    [Header("Player Info")]
    public int playerGold = 500;
    public int playerExp = 80;

    void Start()
    {
        // UI 텍스트 초기화
        upgradeCostText.text = $"{upgradeCost} G";
        requiredExpText.text = $"{requiredExp} EXP";
        upgradeChanceText.text = $"{(int)(successChance * 100)} %";
        upgradeMessageText.text = "";
    }

    public void TryUpgrade()
    {
        if (playerGold < upgradeCost)
        {
            upgradeMessageText.text = "Gold 부족!";
            return;
        }

        if (playerExp < requiredExp)
        {
            upgradeMessageText.text = "경험치 부족!";
            return;
        }

        // 재화 차감
        playerGold -= upgradeCost;

        // 업그레이드 성공 여부 판단
        bool isSuccess = Random.value < successChance;
        resultImage.sprite = isSuccess ? newWeapon.sprite : originalWeapon.sprite;
        upgradeMessageText.text = isSuccess ? "강화 성공!" : "강화 실패!";

        // 결과 화면 전환
        weaponPage.SetActive(false);
        weaponResultPage.SetActive(true);
    }

    public void BackToUpgrade()
    {
        weaponResultPage.SetActive(false);
        weaponPage.SetActive(true);
    }
}
