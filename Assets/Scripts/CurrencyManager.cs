using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyManager : MonoBehaviour
{
    // �̱������� �ٸ� Ŭ�������� ���� �����ϰ� �� ��

    public static CurrencyManager Instance;

    // **** TODO :: �׽�Ʈ �������� 100���� ���� �� �ٽ� 0���� �ٲٱ�
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
        // �ܾ׿� ����
        // 1. Ŀ�� �Ǹ��� �� ����
        // 2. Store���� ������ �� �ִ� �����۸� ��ư�� Ȱ��ȭ�ǰ� �ϱ�
      
        return money >= amount;
    }

}
