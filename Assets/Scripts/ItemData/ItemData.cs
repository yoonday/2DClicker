using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "ScriptableObjects/ItemData", order = 1)]
public class ItemData : ScriptableObject
{
    public string itemName; // 아이템 이름
    public int price;       // 아이템 가격
    public int initialUpgradeCost = 10; // 최초 업그레이드 비용
    public int currentLevel = 1; // 현재 레벨
    public int maxLevel;    // 최대 업그레이드 레벨
    public string description; // 아이템 설명
    public int amount = 1; // 아이템 수량

    public string tag; // 태그 - 일반, 오토 버튼 업그레이드 구분하기 위함
    public string autoBtnName; // 오토 버튼 이름

    public int UpgradeItemLevelCost(int level) // 업그레이드 비용 단계별 비용 2의 제곱으로 늘어남
    {
        return initialUpgradeCost* (int)Mathf.Pow(2, level - 1);
    }
}
