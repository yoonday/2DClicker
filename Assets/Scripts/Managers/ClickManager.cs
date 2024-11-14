using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickManager : MonoBehaviour
{
    // 싱글톤으로 만들어서 다양한 커피에서 사용하도록 
    public static ClickManager Instance;

    // 클릭했을 때 커피 콩, 돈의 증가 및 감소
    public static int clickReward = 1; // 커피 콩 버튼 클릭 1회당 얻을 수 있는 커피 콩
    public static float moneyReward = 0.3f; // 커피 버튼 클릭 1회당 얻을 수 있는 돈($ 기준)


    // 클릭 시 효과음
    [SerializeField] private AudioClip BeanClickClip; // 커피 클릭할 때 
    [SerializeField] private AudioClip coffeeClickClip;

    // 파티클 시스템
    public ParticleSystem clickParticle;

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
        ParticleEffect();

        if (BeanClickClip) SoundManager.PlayClip(BeanClickClip);
    }

    // 커피 버튼 클릭했을 때
    public void OnCoffeeClick()
    {
        if (ScoreManager.Instance.CanUseBeans(clickReward))
        {
            ScoreManager.Instance.UpdateBeanCount(-clickReward);
            CurrencyManager.Instance.EarnMoney(moneyReward * clickReward);
            ParticleEffect();

            if (coffeeClickClip) SoundManager.PlayClip(coffeeClickClip);
        }
    }

    private void ParticleEffect()
    {
        if (clickParticle != null)
        {
            clickParticle.Play();
        }
        
    }


}
