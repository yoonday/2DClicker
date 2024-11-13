using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickManager : MonoBehaviour
{
    // �̱������� ���� �پ��� Ŀ�ǿ��� ����ϵ��� 
    public static ClickManager Instance;

    // Ŭ������ �� Ŀ�� ��, ���� ���� �� ����
    public static int clickReward = 1; // Ŀ�� �� ��ư Ŭ�� 1ȸ�� ���� �� �ִ� Ŀ�� ��
    public static float moneyReward = 0.3f; // Ŀ�� ��ư Ŭ�� 1ȸ�� ���� �� �ִ� ��($ ����)


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
       
    }



    // Ŀ�� �� ��ư Ŭ������ �� �� ScoreManager�� clickReward �ݿ��ǰ� �ϱ�
    public void OnBeanClick()
    {
        ScoreManager.Instance.UpdateBeanCount(clickReward);
    }

    // Ŀ�� ��ư Ŭ������ ��
    public void OnCoffeeClick()
    {
        if (ScoreManager.Instance.CanUseBeans(clickReward))
        {
            ScoreManager.Instance.UpdateBeanCount(-clickReward);
            CurrencyManager.Instance.EarnMoney(moneyReward * clickReward);
        }
    }


}
