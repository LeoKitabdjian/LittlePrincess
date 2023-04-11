using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvertedFade : MonoBehaviour
{
    public Image bg;

    public float fadeSpeed;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FadeFromBlack());
    }

    public IEnumerator FadeFromBlack()
    {
        Color objectColor = bg.color;
        float fadeAmount;
        while (bg.color.a > 0)
        {
            //Screen fade to black
            fadeAmount = objectColor.a - (fadeSpeed * Time.deltaTime);
            objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
            bg.color = objectColor;
            yield return null;
        }
    }

}
