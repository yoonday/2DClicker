using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    // Ŀ�� ��, �� ���� �� �̱������� �ٸ� Ŭ�������� ���� �����ϰ� �� ��
    
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
