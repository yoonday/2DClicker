using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class ItemDataController : MonoBehaviour
{
    // 상점에 아이템 새로 추가할 때 사용하기
    public ItemData itemData; // 프리팹에 연결

    public TMP_Text itemNameText;     
    public TMP_Text itemDescriptionText;
    public TMP_Text itemPriceText;

    private void Start()
    {
        if (itemData != null)
        {
            itemNameText.text = itemData.itemName;
            itemDescriptionText.text = itemData.description;
            itemPriceText.text = itemData.price.ToString();
        }
    }
}
