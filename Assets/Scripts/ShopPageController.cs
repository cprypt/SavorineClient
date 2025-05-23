using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopPageController : MonoBehaviour
{
    [Header("페이지 오브젝트")]
    public GameObject recipePage;
    public GameObject weaponPage;
    public GameObject weaponResultPage;
    public GameObject sellPage;

    [Header("레시피 이미지 및 이름")]
    public Image recipeImage;
    public TextMeshProUGUI recipeNameText;
    public Sprite[] recipeSprites;
    public string[] recipeNames;

    [Header("무기 이미지")]
    public Image weaponImage;
    public Sprite weaponResultSprite;

    void Start()
    {
        ShowRecipePage(); // 기본 페이지
    }

    // --- 페이지 전환 ---
    public void ShowRecipePage()
    {
        SetActivePage(recipePage);
    }

    public void ShowWeaponPage()
    {
        SetActivePage(weaponPage);
    }

    public void ShowSellPage()
    {
        SetActivePage(sellPage);
    }

    public void ShowWeaponResultPage()
    {
        SetActivePage(weaponResultPage);
    }

    void SetActivePage(GameObject target)
    {
        recipePage.SetActive(false);
        weaponPage.SetActive(false);
        weaponResultPage.SetActive(false);
        sellPage.SetActive(false);

        if (target != null)
            target.SetActive(true);
    }

    // --- 레시피 선택 ---
    public void SelectRecipe(int index)
    {
        if (index >= 0 && index < recipeSprites.Length)
        {
            recipeImage.sprite = recipeSprites[index];
            recipeImage.color = new Color(1, 1, 1, 1f); // 투명도 복원
            recipeNameText.text = recipeNames[index];
        }
    }

    // --- 무기 업그레이드 ---
    public void TryCraftWeapon()
    {
        ShowWeaponResultPage();
        weaponImage.sprite = weaponResultSprite;
    }

    // --- 무기 업그레이드 → 다시 이전 화면 ---
    public void BackFromResult()
    {
        ShowWeaponPage();
    }
}

