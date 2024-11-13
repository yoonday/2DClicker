using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyManager : MonoBehaviour
{
    // 싱글톤으로 다른 클래스에서 접근 가능하게 할 것

    public static CurrencyManager Instance;

    // **** TODO :: 테스트 목적으로 100으로 변경 → 다시 0으로 바꾸기
    private float money = 100;

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
        // 잔액에 따라서
        // 1. 커피 판매할 수 있음
        // 2. Store에서 구입할 수 있는 아이템만 버튼이 활성화되게 하기
      
        return money >= amount;
    }

}
