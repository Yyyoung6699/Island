using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class UIshow3 : MonoBehaviour
{
    private float UI_Alpha = 0;             //��ʼ��ʱ��UI��ʾ
    public float alphaSpeed = 2f;          //�������Ե��ٶ�
    private CanvasGroup canvasGroup;
    bool jiaochengbool;
    // Use this for initialization
    void Start()
    {
        jiaochengbool = false;
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
        GameObject[] jiaocheng = FindObjectsOfType<GameObject>()
    .Where(obj => (obj.CompareTag("GreenTree") || obj.CompareTag("RedTree") || obj.CompareTag("SandTree") || obj.CompareTag("SnowTree")))
    .ToArray();

        if (jiaocheng.Length > 8 && jiaochengbool == false)
        {
            StartCoroutine(ExecuteFadeOutAfterDelay());
            jiaochengbool = true;
        }
    }

    private IEnumerator ExecuteFadeOutAfterDelay()
    {
        // ִ��FadeIn
        UI_FadeIn_Event();
        // �ȴ�2��
        yield return new WaitForSeconds(2f);
        // ִ��FadeOut
        UI_FadeOut_Event();
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
