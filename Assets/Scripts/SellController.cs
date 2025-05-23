using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SellPageController : MonoBehaviour
{
    [System.Serializable]
    public class FoodItem
    {
        public string foodName;
        public Sprite foodSprite;
        public int price;
    }

    [Header("판매 아이템 데이터")]
    public FoodItem[] foodItems;

    [Header("UI 요소")]
    public Image selectedFoodImage;
    public TextMeshProUGUI selectedFoodNameText;
    public TextMeshProUGUI selectedFoodPriceText;
    public TextMeshProUGUI purchaseMessageText;

    public GoldManager goldManager;
    public int selectedSellPrice;

    private int selectedIndex = -1;

    void Start()
    {
        // 처음에는 아무것도 선택되지 않음
        ClearDisplay();
    }

    public void ShowFoodItem(int index)
    {
        if (index < 0 || index >= foodItems.Length)
        {
            ClearDisplay();
            return;
        }

        FoodItem item = foodItems[index];
        selectedFoodImage.sprite = item.foodSprite;
        selectedFoodImage.color = new Color(1, 1, 1, 1); // 투명도 1
        selectedFoodNameText.text = item.foodName;
        selectedFoodPriceText.text = $"{item.price} G";
        purchaseMessageText.text = "";
        selectedIndex = index;
    }

    public void SellItem()
    {   
    goldManager.AddGold(selectedSellPrice);
    // 메시지 출력 없음
    }

    private void ClearDisplay()
    {
        selectedFoodImage.color = new Color(1, 1, 1, 0); // 투명 처리
        selectedFoodNameText.text = "";
        selectedFoodPriceText.text = "";
        purchaseMessageText.text = "";
    }
}

