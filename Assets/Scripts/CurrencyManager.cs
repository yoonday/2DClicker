using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyManager : MonoBehaviour
{
    // �̱������� �ٸ� Ŭ�������� ���� �����ϰ� �� ��

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
