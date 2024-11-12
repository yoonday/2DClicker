using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    // 싱글톤으로 다른 클래스에서 접근 가능하게 할 것

    public static UIManager Instance;

    public TMP_Text beanAmount;
    public TMP_Text moneyAmount;

    public TMP_Text beanLv;
    public TMP_Text coffeeLv;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    public void UpdateBeanUI(int beanCount)
    {
        beanAmount.text = "Coffee Beans : " + beanCount.ToString();
    }

    public void UpdateMoneyUI(float money)
    {
        moneyAmount.text = "Money : $" + money.ToString();
    }
}
