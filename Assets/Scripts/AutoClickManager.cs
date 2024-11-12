using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AutoClickManager : ClickManager // ClickManager 상속 받기
{
    // 버튼 누르면 코루틴으로 클릭 반복되게 하기(실행 중인 코루틴 반복 안되게 하기)
    private Coroutine coroutine;
    
    // 클릭 간격 설정 → 업데이트해서 클릭 간격 더 짧게 조정하기
    public float clickInterval = 4.0f;



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnAutoClick()
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }

        coroutine = StartCoroutine(AutoClickCoroutine());

    }

    private IEnumerator AutoClickCoroutine()
    {
        OnBeanClick();
        yield return new WaitForSeconds(clickInterval);
    }
}
