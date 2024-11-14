using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;


public class UIManager : MonoBehaviour
{
    // 싱글톤으로 다른 클래스에서 접근 가능하게 할 것

    public static UIManager Instance;

    public ItemData beanData;
    public ItemData coffeeData;

    public TMP_Text beanAmount;
    public TMP_Text moneyAmount;

    public TMP_Text beanLv;
    public TMP_Text coffeeLv;

    // 업그레이드 버튼
    public TMP_Text beanUpgradeBtnTxt;
    public TMP_Text coffeeUpgradeBtnTxt;

    // 오토 버튼 정보
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
        // 초기값
        int initialBeanCount = 0;
        float initialMoney = CurrencyManager.Instance.money;
        int initialBeanLevel = beanData.currentLevel;
        int initialCoffeeLevel = coffeeData.currentLevel;
        int nextBeanUpgradeCost = 20;
        int nextCoffeeUpgradeCost = 40;

        // 초기 UI 업데이트 함수 호출
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

    public void UpdateUnlockBtn(string autoBtnName) // 구매 시(ItemManager에서 BuyItem 호출시) itemData에 등록해놓은 이름의 버튼 컴포넌트 활성화
    {
        GameObject targetButton = GameObject.Find(autoBtnName); // 같은 이름 오브젝트 찾기

        if (targetButton != null)
        {
            Button buttonComponent = targetButton.GetComponent<Button>();
            if (buttonComponent != null)
            {
                // Button 컴포넌트 Interactable 활성화 해주기
                buttonComponent.interactable = true;
            }
        }
    }

    public void UpdateUpgradeBtn(string itemName, int currentLevel, int nextLevelCost)
    {
        TMP_Text upgradeBtnText = null;
        TMP_Text currentLvTxt = null;

        // itemName에 따라 올바른 텍스트 필드 선택
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

        // 선택한 텍스트 필드가 null이 아닌 경우 업데이트
        if (upgradeBtnText != null)
        {
            upgradeBtnText.text = "Next Level Cost: $" + nextLevelCost;
            currentLvTxt.text = $"Lv.{currentLevel} {itemName}";
        }
    }

    public void UpdateAutoBtn()
    {
        // 오토 버튼 레벨 업데이트 (일반 버튼 업그레이드 하고 여유되면 하기)
    }

    
}
