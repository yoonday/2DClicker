using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AutoClickManager : ClickManager // ClickManager ��� �ޱ�
{
    // ��ư ������ �ڷ�ƾ���� Ŭ�� �ݺ��ǰ� �ϱ�(���� ���� �ڷ�ƾ �ݺ� �ȵǰ� �ϱ�)
    private Coroutine coroutine;
    
    // Ŭ�� ���� ���� �� ������Ʈ�ؼ� Ŭ�� ���� �� ª�� �����ϱ�
    public float clickInterval = 2.0f;

    public Button beanAutoBtn;
    private Color beanInitialColor;

    public Button coffeeAutoBtn;
    private Color CoffeeInitialColor;
  
    private bool isAutoBtnActivate;



    void Start()
    {
        // ���� �ʱ� ���� �� ����
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
        if (clickInterval > 0) // ������ 0�� ���� �ʵ��� 
        {
            clickInterval -= time;
        }
    }


    public void OnAutoClick(ItemData itemData) // UIManager - UpdateUnlockó�� �̸����� ã��
    {
        GameObject targetButton = GameObject.Find(itemData.autoBtnName);
        // TODO :: ���� �����ϱ�
        // Button buttonComponent = targetButton.GetComponent<Button>();

        if (coroutine != null) // �̹� ���� ���̸� ���߱�
        {
            StopCoroutine(coroutine);
            coroutine = null;
            isAutoBtnActivate = false;
            // TODO :: ���� ���� ������ ������
        }
        else
        {
            coroutine = StartCoroutine(AutoClickCoroutine(itemData));
            isAutoBtnActivate = true;
            // TODO :: ��ư Ȱ��ȭ�Ǿ��� �� �� �ٸ��� �ٲٱ�
        }

    }

    private IEnumerator AutoClickCoroutine(ItemData itemData)
    {

        while (true) // ���� �ݺ�
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
