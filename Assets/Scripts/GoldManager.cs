using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class GoldManager : MonoBehaviour
{
    public static GoldManager Instance { get; private set; }

    public UnityEvent<int> OnGoldChanged = new UnityEvent<int>();

    [SerializeField] private int startingGold = 0;
    private int currentGold;

    private void Start()
    {
        currentGold = startingGold;
        OnGoldChanged.Invoke(currentGold); // 초기 상태도 알려줌
    }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public void AddGold(int amount)
    {
        currentGold += amount;
        OnGoldChanged.Invoke(currentGold);
    }

    public bool TrySpendGold(int amount)
    {
        if (currentGold >= amount)
        {
            currentGold -= amount;
            OnGoldChanged.Invoke(currentGold);
            return true;
        }
        return false;
    }

    public int GetCurrentGold() => currentGold;
}
