using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StorePopUpUI : MonoBehaviour
{
    public GameObject storePopUp;  // 스토어 버튼 팝업

    // 스토어 아이템 데이터 정보 (버튼, 데이터)
    public List<ItemData> storeItems; 
    public List<GameObject> storeItemButtons; 

    public void ToggleStorePopup()
    {
        bool isActive = storePopUp.activeSelf;
        storePopUp.SetActive(!isActive);

        if (storePopUp.activeSelf) // 팝업창이 활성화되어있을 때 상태 업데이트
        {
            UpdateButtonStates();
        }

    }

    private void UpdateButtonStates() // 보유 금액을 만족했을 때 아이템 구매 가능하도록 상태 업데이트
    {
        for (int i = 0; i < storeItems.Count; i++)
        {
            // 각 아이템 가격 넘겼을 때 구매 가능하게 함
            bool canAfford = CurrencyManager.Instance.CanAfford(storeItems[i].price);

            // 아이템 구매한 적이 없고, 금액이 충분하면 아이템 버튼을 활성화
            bool isAvailable = storeItems[i].amount > 0;

            // 잔액, 잔여 수량 확인 후 버튼 컴포넌트 Interactable 활성화
            Button buttonComponent = storeItemButtons[i].GetComponent<Button>();
            buttonComponent.interactable = canAfford && isAvailable;
            
        }
    }
}
