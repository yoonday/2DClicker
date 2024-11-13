using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;


public class UIManager : MonoBehaviour
{
    // 싱글톤으로 다른 클래스에서 접근 가능하게 할 것

    public static UIManager Instance;

    public TMP_Text beanAmount;
    public TMP_Text moneyAmount;

    public TMP_Text beanLv;
    public TMP_Text coffeeLv;

    // 오토 버튼 정보
    public GameObject beanAutoBtn;
    public TMP_Text beanAutoBtnText;
  
    public GameObject coffeeAutoBtn;
    public TMP_Text coffeeAutoBtnText;


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
        moneyAmount.text = "Money : $ " + money.ToString("F1");
    }

    public void UpdateUnlockBtn(string autoBtnName) // 구매 시(ItemManager에서 BuyItem 호출시) itemData에 등록해놓은 이름의 버튼 컴포넌트 활성화
    {
        GameObject targetButton = GameObject.Find(autoBtnName); // 같은 이름 오브젝트 찾기

        if (targetButton != null)
        {
            Button buttonComponent = targetButton.GetComponent<Button>();
            if (buttonComponent != null)
            {
                // Button 컴포넌트 Interactable 활성화 해주기
                buttonComponent.interactable = true;
            }
        }
    }

    public void UpdateAutoBtn()
    {
        // 오토 버튼 레벨 업데이트
    }

}
