using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public void LoadVillageScene()
    {
        SceneManager.LoadScene("VillageScene");  // 마을 씬으로 이동
    }

    public void LoadCraftingScene()
    {
        SceneManager.LoadScene("CraftingScene");  // 제작 씬으로 이동
    }

    public void LoadShopScene()
    {
        SceneManager.LoadScene("ShopScene");  // 상점 씬으로 이동
    }
}
