using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneFader : MonoBehaviour
{
    [SerializeField] private CanvasGroup group;
    [SerializeField] private float duration = 1f;
    [SerializeField] private bool fadeInOnStart; 

    private void Start()
    {
        group.alpha = fadeInOnStart ? 1f : 0f;
        group.blocksRaycasts = false;
        if (fadeInOnStart) StartCoroutine(Fade(1f, 0f));
    }

    public void LoadScene(string sceneName)
    {
        StartCoroutine(FadeAndLoad(sceneName));
    }

    private IEnumerator FadeAndLoad(string sceneName)
    {
        group.blocksRaycasts = true;
        yield return Fade(0f, 1f);
        SceneManager.LoadScene(sceneName);
    }

    private IEnumerator Fade(float from, float to)
    {
        float t = 0f;
        while (t < duration)
        {
            t += Time.deltaTime;
            group.alpha = Mathf.Lerp(from, to, t / duration);
            yield return null;
        }
        group.alpha = to;
    }
}