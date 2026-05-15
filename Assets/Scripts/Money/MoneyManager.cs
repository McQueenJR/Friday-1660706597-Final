using UnityEngine;
using TMPro;

public class MoneyManager : MonoBehaviour
{
    public static MoneyManager Instance;

    public int money = 20;

    public TextMeshProUGUI moneyText;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        UpdateUI();
    }

    public bool HasEnoughMoney(int cost)
    {
        return money >= cost;
    }

    public void SpendMoney(int cost)
    {
        money -= cost;

        UpdateUI();
    }

    void UpdateUI()
    {
        moneyText.text = "Money : " + money;
    }
}