using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorePopUpUI : MonoBehaviour
{
    public GameObject storePopUp;  // 스토어 버튼 팝업

    public void ToggleStorePopup()
    {
        bool isActive = storePopUp.activeSelf;
        storePopUp.SetActive(!isActive);
    }
}
