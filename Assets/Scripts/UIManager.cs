using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;


public class UIManager : MonoBehaviour
{
    // �̱������� �ٸ� Ŭ�������� ���� �����ϰ� �� ��

    public static UIManager Instance;

    public TMP_Text beanAmount;
    public TMP_Text moneyAmount;

    public TMP_Text beanLv;
    public TMP_Text coffeeLv;

    // ���� ��ư ����
    public GameObject beanAutoBtn;
    public TMP_Text beanAutoBtnText;
  
    public GameObject coffeeAutoBtn;
    public TMP_Text coffeeAutoBtnText;


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
    public void UpdateBeanUI(int beanCount)
    {
        beanAmount.text = "Coffee Beans : " + beanCount.ToString();
    }

    public void UpdateMoneyUI(float money)
    {
        moneyAmount.text = "Money : $ " + money.ToString("F1");
    }

    public void UpdateUnlockBtn(string autoBtnName) // ���� ��(ItemManager���� BuyItem ȣ���) itemData�� ����س��� �̸��� ��ư ������Ʈ Ȱ��ȭ
    {
        GameObject targetButton = GameObject.Find(autoBtnName); // ���� �̸� ������Ʈ ã��

        if (targetButton != null)
        {
            Button buttonComponent = targetButton.GetComponent<Button>();
            if (buttonComponent != null)
            {
                // Button ������Ʈ Interactable Ȱ��ȭ ���ֱ�
                buttonComponent.interactable = true;
            }
        }
    }

    public void UpdateAutoBtn()
    {
        // ���� ��ư ���� ������Ʈ
    }

}
