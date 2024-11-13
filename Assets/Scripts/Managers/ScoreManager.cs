using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    // 커피 콩, 돈 관리 → 싱글톤으로 다른 클래스에서 접근 가능하게 할 것
    
    public static ScoreManager Instance;

    private int beanCount = 0;
    private float money = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }

    }

    public void UpdateBeanCount(int amount)
    {
        beanCount += amount;
        UIManager.Instance.UpdateBeanUI(beanCount);
    }

    public void UpdateMoney(float amount)
    {
        money += amount;
        UIManager.Instance.UpdateMoneyUI(money);
    }

    public bool CanUseBeans(int amount)
    {
        return beanCount >= amount;
    }
}
