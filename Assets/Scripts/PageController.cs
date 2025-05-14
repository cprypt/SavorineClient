using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PageController : MonoBehaviour
{
    public Image bookPageImage;
    public Sprite[] pageSprites;

    // 페이지에 따라 보여줄 버튼들
    public GameObject craftButton;
    public GameObject backButton;

    public void ChangePage(int index)
    {
        if (index < 0 || index >= pageSprites.Length) return;

        bookPageImage.sprite = pageSprites[index];

        // 버튼 상태 초기화
        craftButton.SetActive(false);
        backButton.SetActive(false);

        // 페이지에 따라 버튼 활성화
        if (index == 4) // 무기 제작 페이지
            craftButton.SetActive(true);
        else if (index == 5 || index == 6) // 제작 결과 페이지
            backButton.SetActive(true);
    }

    public void TryCraft()
    {
    float chance = Random.Range(0f, 1f);
    
    // 성공 시에는 다시 제작 화면(인덱스 4)으로, 실패 시 실패 결과 화면(인덱스 5)
    if (chance < 0.7f)
        ChangePage(4); // 성공: 다시 제작 화면
    else
        ChangePage(5); // 실패: 실패 화면
    }


    public void GoHome()
    {
        SceneManager.LoadScene("HomeScene"); // 혹은 UIManager.ShowPanel(homePanel);
    }
}
