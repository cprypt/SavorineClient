using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CookingPageController : MonoBehaviour
{
    public Image bookImage;
    public Sprite[] pageSprites;

    [Range(0f, 1f)]
    public float animalEventChance = 1.0f;

    public GameObject yReturnButton;
    public GameObject resultBackButton;

    public GameObject cookPanel;
    public GameObject homePanel;

    public void ChangePage(int index)
    {
        if (index >= 0 && index < pageSprites.Length)
        {
            bookImage.sprite = pageSprites[index];
        }

        // 버튼 활성화 제어
        yReturnButton?.SetActive(index == 4);      // 동물 등장 화면일 때만 Y 버튼
        resultBackButton?.SetActive(index == 3);   // 결과 화면일 때만 BACK 버튼
    }

    public void ShowResultWithChance()
    {
        ChangePage(3); // 요리 결과 화면 먼저

        float rand = Random.value;
        if (rand < animalEventChance)
        {
            Invoke(nameof(ShowAnimalEvent), 1.0f);
        }
    }

    private void ShowAnimalEvent()
    {
        ChangePage(4); // 동물 등장 화면
    }

    // 제작 결과 → 요리 초기화면
    public void BackToStart()
    {
        ChangePage(0);
    }

    // 동물 등장 → 요리 제작화면
    public void BackToCooking()
    {
        ChangePage(2);
    }

    // X 버튼 → 집 화면으로
    public void ExitToHome()
    {
        cookPanel.SetActive(false);
        homePanel.SetActive(true);
    }
}
