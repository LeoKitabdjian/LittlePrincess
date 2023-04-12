using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneFader : MonoBehaviour
{
    public Image fadeImage;
    public float fadeDuration = 1f;
    public float waitDuration = 3f;

    public IEnumerator FadeAndLoadScene(string sceneName)
    {
        // Fade to black
        float elapsedTime = 0f;
        Color color = fadeImage.color;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            color.a = Mathf.Lerp(0f, 1f, elapsedTime / fadeDuration);
            fadeImage.color = color;
            yield return null;
        }

        // Wait for a few seconds
        yield return new WaitForSeconds(waitDuration);

        // Load the target scene
        SceneManager.LoadScene(sceneName);
    }
}
