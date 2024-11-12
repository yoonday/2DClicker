using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorePopUpUI : MonoBehaviour
{
    public GameObject storePopUp;  // ����� ��ư �˾�

    public void ToggleStorePopup()
    {
        bool isActive = storePopUp.activeSelf;
        storePopUp.SetActive(!isActive);
    }
}
