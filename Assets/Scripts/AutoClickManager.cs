using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AutoClickManager : ClickManager // ClickManager 상속 받기
{
    // 버튼 누르면 코루틴으로 클릭 반복되게 하기(실행 중인 코루틴 반복 안되게 하기)
    private Coroutine coroutine;
    
    // 클릭 간격 설정 → 업데이트해서 클릭 간격 더 짧게 조정하기
    public float clickInterval = 2.0f;

    public Button beanAutoBtn;
    private Color beanInitialColor;

    public Button coffeeAutoBtn;
    private Color CoffeeInitialColor;
  
    private bool isAutoBtnActivate;



    void Start()
    {
        // 색상 초기 세팅 값 저장
        if (beanAutoBtn != null)
        {
            beanInitialColor = beanAutoBtn.image.color;
        }
        if (coffeeAutoBtn != null)
        {
            CoffeeInitialColor = coffeeAutoBtn.image.color;
        }
    }

    public void SpeedUpClickInterval(float time)
    {
        if (clickInterval > 0) // 간격이 0이 되지 않도록 
        {
            clickInterval -= time;
        }
    }


    public void OnAutoClick(ItemData itemData) // UIManager - UpdateUnlock처럼 이름으로 찾기
    {
        GameObject targetButton = GameObject.Find(itemData.autoBtnName);
        // TODO :: 색상 변경하기
        // Button buttonComponent = targetButton.GetComponent<Button>();

        if (coroutine != null) // 이미 실행 중이면 멈추기
        {
            StopCoroutine(coroutine);
            coroutine = null;
            isAutoBtnActivate = false;
            // TODO :: 색상 원래 색으로 돌리기
        }
        else
        {
            coroutine = StartCoroutine(AutoClickCoroutine(itemData));
            isAutoBtnActivate = true;
            // TODO :: 버튼 활성화되었을 때 색 다르게 바꾸기
        }

    }

    private IEnumerator AutoClickCoroutine(ItemData itemData)
    {

        while (true) // 무한 반복
        {
            if (itemData.autoBtnName == "btn_Auto_Bean")
            {
                OnBeanClick();
            }
            else if (itemData.autoBtnName == "btn_Auto_Coffee")
            {
                OnCoffeeClick();
            }

            yield return new WaitForSeconds(clickInterval);
        }
    }
}
