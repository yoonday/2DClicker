using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "ScriptableObjects/ItemData", order = 1)]
public class ItemData : ScriptableObject
{
    public string itemName; // 아이템 이름
    public int price;       // 아이템 가격
    public int initialUpgradeCost = 10; // 최초 업그레이드 비용
    public int maxLevel;    // 최대 업그레이드 레벨
    public string description; // 아이템 설명
    public int amount = 1; // 아이템 수량

    public string autoBtnName; // 오토 버튼 이름

    public int UpgradeItemLevel(int level) // 단계별 비용 2의 제곱으로 늘어남
    {
        return initialUpgradeCost* (int)Mathf.Pow(2, level - 1);
    }
}
