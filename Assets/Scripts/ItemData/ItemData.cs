using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "ScriptableObjects/ItemData", order = 1)]
public class ItemData : ScriptableObject
{
    public string itemName; // ������ �̸�
    public int price;       // ������ ����
    public int initialUpgradeCost = 10; // ���� ���׷��̵� ���
    public int currentLevel = 1; // ���� ����
    public int maxLevel;    // �ִ� ���׷��̵� ����
    public string description; // ������ ����
    public int amount = 1; // ������ ����

    public string tag; // �±� - �Ϲ�, ���� ��ư ���׷��̵� �����ϱ� ����
    public string autoBtnName; // ���� ��ư �̸�

    public int UpgradeItemLevelCost(int level) // ���׷��̵� ��� �ܰ躰 ��� 2�� �������� �þ
    {
        return initialUpgradeCost* (int)Mathf.Pow(2, level - 1);
    }
}
