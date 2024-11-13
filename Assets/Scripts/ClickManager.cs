using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickManager : MonoBehaviour
{
    // 싱글톤으로 만들어서 다양한 커피에서 사용하도록 
    public static ClickManager Instance;

    // 클릭했을 때 커피 콩, 돈의 증가 및 감소
    public int clickReward = 1; // 커피 콩 버튼 클릭 1회당 얻을 수 있는 커피 콩
    public float moneyReward = 0.3f; // 커피 버튼 클릭 1회당 얻을 수 있는 돈($ 기준)


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
       
    }



    // 커피 콩 버튼 클릭했을 때 → ScoreManager에 clickReward 반영되게 하기
    public void OnBeanClick()
    {
        ScoreManager.Instance.UpdateBeanCount(clickReward);
    }

    // 커피 콩 업그레이드 했을 때 → ClickReward 늘리기
    public void IncreaseClickReward(int amount)
    {
        clickReward += amount;
    }

    // 커피 버튼 클릭했을 때
    public void OnCoffeeClick()
    {
        if (ScoreManager.Instance.CanUseBeans(clickReward))
        {
            ScoreManager.Instance.UpdateBeanCount(-clickReward);
            CurrencyManager.Instance.EarnMoney(moneyReward);
        }
    }


}
