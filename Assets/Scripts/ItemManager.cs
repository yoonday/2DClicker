using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    // Store���� ��� �����ϱ� �� ���� Ŭ�� ��� �ر�

    public StorePopUpUI storePopUp;
    public GameObject unlockBtn;
   


    public void BuyItem(GameObject ob) // ������ ����
    {

        // Unlock ��ư Ȱ��ȭ
        // ���� �� ����� �˾� �ݱ�
        storePopUp.ToggleStorePopup();
    }

    public void UpgradeObejct(GameObject ob) // ������Ʈ ���׷��̵�
    {
        
    }
}
