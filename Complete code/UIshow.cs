using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// UI�Ľ��뽥��
/// </summary>
public class UIshow : MonoBehaviour
{
    private float UI_Alpha = 0;             //��ʼ��ʱ��UI��ʾ
    public float alphaSpeed = 2f;          //�������Ե��ٶ�
    private CanvasGroup canvasGroup;

    // Use this for initialization
    void Start()
    {
        canvasGroup = this.GetComponent<CanvasGroup>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canvasGroup == null)
        {
            return;
        }

        if (UI_Alpha != canvasGroup.alpha)
        {
            canvasGroup.alpha = Mathf.Lerp(canvasGroup.alpha, UI_Alpha, alphaSpeed * Time.deltaTime);
            if (Mathf.Abs(UI_Alpha - canvasGroup.alpha) <= 0.01f)
            {
                canvasGroup.alpha = UI_Alpha;
            }
        }
    }

    public void UI_FadeIn_Event()
    {
        UI_Alpha = 1;
    }

    public void UI_FadeOut_Event()
    {
        UI_Alpha = 0;
    }


}
