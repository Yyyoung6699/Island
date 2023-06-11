using UnityEngine;
using UnityEngine.UI;

public class AlphaPreserver : MonoBehaviour
{
    private Image image;

    private void Start()
    {
        // 获取Image组件
        image = GetComponent<Image>();

        // 在切换场景时不销毁Image1游戏对象
        DontDestroyOnLoad(gameObject);
    }

    private void OnEnable()
    {
        // 监听场景加载事件
        UnityEngine.SceneManagement.SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        // 取消监听场景加载事件
        UnityEngine.SceneManagement.SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(UnityEngine.SceneManagement.Scene scene, UnityEngine.SceneManagement.LoadSceneMode mode)
    {
        // 在每次加载新场景后更新Image1的Alpha值
        AlphaPreserver[] alphaPreservers = FindObjectsOfType<AlphaPreserver>();

        foreach (AlphaPreserver alphaPreserver in alphaPreservers)
        {
            // 获取Image组件并设置Alpha值
            Image alphaPreserverImage = alphaPreserver.GetComponent<Image>();
            alphaPreserverImage.color = new Color(alphaPreserverImage.color.r, alphaPreserverImage.color.g, alphaPreserverImage.color.b, image.color.a);
        }
    }
}

