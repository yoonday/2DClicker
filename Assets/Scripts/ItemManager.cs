using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    // Store에서 장비 구매하기 → 오토 클릭 기능 해금

    public StorePopUpUI storePopUp;
    public GameObject unlockBtn;
   


    public void BuyItem(GameObject ob) // 아이템 구매
    {

        // Unlock 버튼 활성화
        // 구매 후 스토어 팝업 닫기
        storePopUp.ToggleStorePopup();
    }

    public void UpgradeObejct(GameObject ob) // 오브젝트 업그레이드
    {
        
    }
}
