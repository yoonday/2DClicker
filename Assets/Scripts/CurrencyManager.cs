using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyManager : MonoBehaviour
{
    // 싱글톤으로 다른 클래스에서 접근 가능하게 할 것

    public static CurrencyManager Instance;

    private float money;

    private void Awake()
    {
        Instance = this;
    }
    public void EarnMoney(float amount)
    {
        money += amount;
        UIManager.Instance.UpdateMoneyUI(money);
    }

    public void SpendMoney(float amount)
    {
        if (CanAfford(amount))
        {
            money -= amount;
            UIManager.Instance.UpdateMoneyUI(money);
        }
    }

    public bool CanAfford(float amount)
    {
        return money >= amount;
    }

}
