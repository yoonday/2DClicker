using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    // Store에서 장비 구매하기 → 오토 클릭 기능 해금

    public StorePopUpUI storePopUp;
    public GameObject unlockAutoBeanBtn;
    public GameObject unlockAutoCoffeeBtn;


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

    public void UpgradeObejct(ItemData itemData) // 오브젝트 업그레이드
    {
        // 단계별로 조건 충족해야 업그레이드 가능
        // 단계는 각 버튼의 텍스트에 표기됨(UIManager의 Lv.아이템이름)
    }
}
