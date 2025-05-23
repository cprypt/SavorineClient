using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RecipeController : MonoBehaviour
{

    [System.Serializable]
    public class RecipeData
    {
        public string recipeName;
        public Sprite recipeSprite;
        public int recipePrice;
    }

    public RecipeData[] recipes;

    public Image recipeImage;
    public TextMeshProUGUI recipeNameText;
    public TextMeshProUGUI recipePriceText;

    void Start()
    {
        // 텍스트만 초기화 (이미지는 Inspector에서 투명 처리)
        recipeNameText.text = "";
        recipePriceText.text = "";
    }

    public void ShowRecipe(int index)
    {
        if (index < 0 || index >= recipes.Length) return;

        RecipeData selected = recipes[index];
        recipeImage.sprite = selected.recipeSprite;
        recipeNameText.text = selected.recipeName;
        recipePriceText.text = $"{selected.recipePrice} G";

        // 알파값을 1로 바꿔서 이미지 표시
        Color c = recipeImage.color;
        c.a = 1f;
        recipeImage.color = c;
    }
}
