using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class ItemManager : MonoBehaviour
{
    // Store에서 장비 구매하기 → 오토 클릭 기능 해금

    public StorePopUpUI storePopUp;
    public GameObject unlockAutoBeanBtn;
    public GameObject unlockAutoCoffeeBtn;

    public List<ItemData> itemDataList;

    private void Start()
    {
        // 게임 시작 시 amount를 1로 초기화 → TODO :: 나중에 저장 기능 만들면 수정하기
        foreach (var itemData in itemDataList)
        {
            itemData.amount = 1;
        }
    }


    public void BuyItem(ItemData itemData) // 아이템 구매
    {
        if (CurrencyManager.Instance.CanAfford(itemData.price) && itemData.amount > 0)
        {
            CurrencyManager.Instance.SpendMoney(itemData.price);
            itemData.amount = 0; // 구매 후 수량 0으로 만들기

            // Unlock 해금 - itemData에 등록해놓은 버튼
            UIManager.Instance.UpdateUnlockBtn(itemData.autoBtnName);
        }

        // 구매 후 스토어 팝업 닫기
        storePopUp.ToggleStorePopup(); 
    }


    public void UpgradeObject(ItemData itemData) // 오브젝트 업그레이드
    {
        int upgradeCost = itemData.UpgradeItemLevelCost(itemData.currentLevel + 1); // 업그레이드에 필요한 비용 계산

        if (CurrencyManager.Instance.CanAfford(upgradeCost))
        {
            CurrencyManager.Instance.SpendMoney(upgradeCost);

            if (itemData.tag == "Item")
            {
                // 아이템 업그레이드: clickReward 1씩 증가
               AddClickReward(1);
            }
            else if (itemData.tag == "Auto")
            {
                // 오토 클릭 업그레이드: 클릭 간격 감소
                // AutoClickManager.SpeedUpClickInterval(0.1f);
            }

            itemData.currentLevel++; // 현재 레벨 증가 

            int nextLevelCost = itemData.UpgradeItemLevelCost(itemData.currentLevel + 1); // 레벨업에 따른 비용 반영
            UIManager.Instance.UpdateUpgradeBtn(itemData.itemName, itemData.currentLevel, nextLevelCost);// UI 버튼 업데이트
           
        }
    }

     // 커피 콩 업그레이드 했을 때 → ClickReward 늘리기
    public void AddClickReward(int amount)
    {
        ClickManager.clickReward += amount;
    }

}
