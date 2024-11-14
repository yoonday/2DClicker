using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StorePopUpUI : MonoBehaviour
{
    public GameObject storePopUp;  // ����� ��ư �˾�

    // ����� ������ ������ ���� (��ư, ������)
    public List<ItemData> storeItems; 
    public List<GameObject> storeItemButtons; 

    public void ToggleStorePopup()
    {
        bool isActive = storePopUp.activeSelf;
        storePopUp.SetActive(!isActive);

        if (storePopUp.activeSelf) // �˾�â�� Ȱ��ȭ�Ǿ����� �� ���� ������Ʈ
        {
            UpdateButtonStates();
        }

    }

    private void UpdateButtonStates() // ���� �ݾ��� �������� �� ������ ���� �����ϵ��� ���� ������Ʈ
    {
        for (int i = 0; i < storeItems.Count; i++)
        {
            // �� ������ ���� �Ѱ��� �� ���� �����ϰ� ��
            bool canAfford = CurrencyManager.Instance.CanAfford(storeItems[i].price);

            // ������ ������ ���� ����, �ݾ��� ����ϸ� ������ ��ư�� Ȱ��ȭ
            bool isAvailable = storeItems[i].amount > 0;

            // �ܾ�, �ܿ� ���� Ȯ�� �� ��ư ������Ʈ Interactable Ȱ��ȭ
            Button buttonComponent = storeItemButtons[i].GetComponent<Button>();
            buttonComponent.interactable = canAfford && isAvailable;
            
        }
    }
}
