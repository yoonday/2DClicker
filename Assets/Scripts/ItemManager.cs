using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    // Store���� ��� �����ϱ� �� ���� Ŭ�� ��� �ر�

    public StorePopUpUI storePopUp;
    public GameObject unlockAutoBeanBtn;
    public GameObject unlockAutoCoffeeBtn;


    public void BuyItem(ItemData itemData) // ������ ����
    {
        if (CurrencyManager.Instance.CanAfford(itemData.price) && itemData.amount > 0)
        {
            CurrencyManager.Instance.SpendMoney(itemData.price);
            itemData.amount = 0; // ���� �� ���� 0���� �����

            // Unlock �ر� - itemData�� ����س��� ��ư
            UIManager.Instance.UpdateUnlockBtn(itemData.autoBtnName);
        }

        // ���� �� ����� �˾� �ݱ�
        storePopUp.ToggleStorePopup(); 
    }

    public void UpgradeObejct(ItemData itemData) // ������Ʈ ���׷��̵�
    {
        // �ܰ躰�� ���� �����ؾ� ���׷��̵� ����
        // �ܰ�� �� ��ư�� �ؽ�Ʈ�� ǥ���(UIManager�� Lv.�������̸�)
    }
}
