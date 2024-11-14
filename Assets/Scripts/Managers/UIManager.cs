using System;
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

    public ItemData beanData;
    public ItemData coffeeData;

    public TMP_Text beanAmount;
    public TMP_Text moneyAmount;

    public TMP_Text beanLv;
    public TMP_Text coffeeLv;

    // ���׷��̵� ��ư
    public TMP_Text beanUpgradeBtnTxt;
    public TMP_Text coffeeUpgradeBtnTxt;

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

    private void Start()
    {
        // �ʱⰪ
        int initialBeanCount = 0;
        float initialMoney = CurrencyManager.Instance.money;
        int initialBeanLevel = beanData.currentLevel;
        int initialCoffeeLevel = coffeeData.currentLevel;
        int nextBeanUpgradeCost = 20;
        int nextCoffeeUpgradeCost = 40;

        // �ʱ� UI ������Ʈ �Լ� ȣ��
        UpdateBeanUI(initialBeanCount);
        UpdateMoneyUI(initialMoney);
        UpdateUpgradeBtn("Coffee Bean", initialBeanLevel, nextBeanUpgradeCost);
        UpdateUpgradeBtn("Americano", initialCoffeeLevel, nextCoffeeUpgradeCost);

     
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

    public void UpdateUpgradeBtn(string itemName, int currentLevel, int nextLevelCost)
    {
        TMP_Text upgradeBtnText = null;
        TMP_Text currentLvTxt = null;

        // itemName�� ���� �ùٸ� �ؽ�Ʈ �ʵ� ����
        switch (itemName)
        {
            case "Coffee Bean":
                upgradeBtnText = beanUpgradeBtnTxt;
                currentLvTxt = beanLv;
                break;
            case "Americano":
                upgradeBtnText = coffeeUpgradeBtnTxt;
                currentLvTxt = coffeeLv;
                break;
            default:
                
                break;
        }

        // ������ �ؽ�Ʈ �ʵ尡 null�� �ƴ� ��� ������Ʈ
        if (upgradeBtnText != null)
        {
            upgradeBtnText.text = "Next Level Cost: $" + nextLevelCost;
            currentLvTxt.text = $"Lv.{currentLevel} {itemName}";
        }
    }

    public void UpdateAutoBtn()
    {
        // ���� ��ư ���� ������Ʈ (�Ϲ� ��ư ���׷��̵� �ϰ� �����Ǹ� �ϱ�)
    }

    
}
