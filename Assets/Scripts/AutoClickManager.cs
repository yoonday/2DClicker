using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AutoClickManager : ClickManager // ClickManager ��� �ޱ�
{
    // ��ư ������ �ڷ�ƾ���� Ŭ�� �ݺ��ǰ� �ϱ�(���� ���� �ڷ�ƾ �ݺ� �ȵǰ� �ϱ�)
    private Coroutine coroutine;
    
    // Ŭ�� ���� ���� �� ������Ʈ�ؼ� Ŭ�� ���� �� ª�� �����ϱ�
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
