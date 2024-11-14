using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class ItemManager : MonoBehaviour
{
    // Store���� ��� �����ϱ� �� ���� Ŭ�� ��� �ر�

    public StorePopUpUI storePopUp;
    public GameObject unlockAutoBeanBtn;
    public GameObject unlockAutoCoffeeBtn;

    public List<ItemData> itemDataList;

    private void Start()
    {
        // ���� ���� �� amount�� 1�� �ʱ�ȭ �� TODO :: ���߿� ���� ��� ����� �����ϱ�
        foreach (var itemData in itemDataList)
        {
            itemData.amount = 1;
        }
    }


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


    public void UpgradeObject(ItemData itemData) // ������Ʈ ���׷��̵�
    {
        int upgradeCost = itemData.UpgradeItemLevelCost(itemData.currentLevel + 1); // ���׷��̵忡 �ʿ��� ��� ���

        if (CurrencyManager.Instance.CanAfford(upgradeCost))
        {
            CurrencyManager.Instance.SpendMoney(upgradeCost);

            if (itemData.tag == "Item")
            {
                // ������ ���׷��̵�: clickReward 1�� ����
               AddClickReward(1);
            }
            else if (itemData.tag == "Auto")
            {
                // ���� Ŭ�� ���׷��̵�: Ŭ�� ���� ����
                // AutoClickManager.SpeedUpClickInterval(0.1f);
            }

            itemData.currentLevel++; // ���� ���� ���� 

            int nextLevelCost = itemData.UpgradeItemLevelCost(itemData.currentLevel + 1); // �������� ���� ��� �ݿ�
            UIManager.Instance.UpdateUpgradeBtn(itemData.itemName, itemData.currentLevel, nextLevelCost);// UI ��ư ������Ʈ
           
        }
    }

     // Ŀ�� �� ���׷��̵� ���� �� �� ClickReward �ø���
    public void AddClickReward(int amount)
    {
        ClickManager.clickReward += amount;
    }

}
