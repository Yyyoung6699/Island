using UnityEngine;
using UnityEngine.UI;

public class AlphaPreserver : MonoBehaviour
{
    private Image image;

    private void Start()
    {
        // ��ȡImage���
        image = GetComponent<Image>();

        // ���л�����ʱ������Image1��Ϸ����
        DontDestroyOnLoad(gameObject);
    }

    private void OnEnable()
    {
        // �������������¼�
        UnityEngine.SceneManagement.SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        // ȡ���������������¼�
        UnityEngine.SceneManagement.SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(UnityEngine.SceneManagement.Scene scene, UnityEngine.SceneManagement.LoadSceneMode mode)
    {
        // ��ÿ�μ����³��������Image1��Alphaֵ
        AlphaPreserver[] alphaPreservers = FindObjectsOfType<AlphaPreserver>();

        foreach (AlphaPreserver alphaPreserver in alphaPreservers)
        {
            // ��ȡImage���������Alphaֵ
            Image alphaPreserverImage = alphaPreserver.GetComponent<Image>();
            alphaPreserverImage.color = new Color(alphaPreserverImage.color.r, alphaPreserverImage.color.g, alphaPreserverImage.color.b, image.color.a);
        }
    }
}

