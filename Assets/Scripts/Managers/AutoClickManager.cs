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
    private Color beanInitialColor; // ��ư �⺻ ��
    public Color beanCoroutineColor; // �ڷ�ƾ ���� �� ��

    public Button coffeeAutoBtn;
    private Color coffeeInitialColor;
    public Color coffeeCoroutineColor;



    void Start()
    {
        // ���� �ʱ� ���� �� ����
        if (beanAutoBtn != null)
        {
            beanInitialColor = beanAutoBtn.image.color;
        }
        if (coffeeAutoBtn != null)
        {
            coffeeInitialColor = coffeeAutoBtn.image.color;
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
        Button buttonComponent = targetButton.GetComponent<Button>(); // ���� �����ϱ� ����

        if (coroutine != null) // �̹� ���� ���̸� ���߱�
        {
            StopCoroutine(coroutine);
            coroutine = null;

   
            // ���� ���� ������ ������
            if (itemData.autoBtnName == "btn_Auto_Bean" && beanAutoBtn != null)
            {
                beanAutoBtn.image.color = beanInitialColor;
            }
            else if (itemData.autoBtnName == "btn_Auto_Coffee" && coffeeAutoBtn != null)
            {
                coffeeAutoBtn.image.color = coffeeInitialColor;
            }
        }
        else
        {
            coroutine = StartCoroutine(AutoClickCoroutine(itemData));


            // ��ư Ȱ��ȭ�Ǿ��� �� �� �ٸ��� �ٲٱ�
            if (itemData.autoBtnName == "btn_Auto_Bean" && beanAutoBtn != null)
            {
                beanAutoBtn.image.color = beanCoroutineColor; 
            }
            else if (itemData.autoBtnName == "btn_Auto_Coffee" && coffeeAutoBtn != null)
            {
                coffeeAutoBtn.image.color = coffeeCoroutineColor;
            }
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
