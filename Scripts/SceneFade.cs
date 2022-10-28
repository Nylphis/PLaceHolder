using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneFade : MonoBehaviour
{
    public Image fadeImage;
    public AnimationCurve fadeCurve;

    private void Start() 
    {
        StartCoroutine(FadeIn());    
    }

    public void FadeTo(string scene)
    {
        StartCoroutine(FadeOut(scene));
    }

    IEnumerator FadeIn()
    {
        float t = 1f;

        while(t > 0f)
        {
            t -= Time.deltaTime;
            float a = fadeCurve.Evaluate(t);
            fadeImage.color = new Color (0f, 0f, 0f, a);
            yield return 0; //skip a frame then repeat
        }
    }

    IEnumerator FadeOut(string scene)
    {
        float t = 0f;

        while(t < 1f)
        {
            t += Time.deltaTime;
            float a = fadeCurve.Evaluate(t);
            fadeImage.color = new Color (0f, 0f, 0f, a);
            yield return 0; //skip a frame then repeat
        }
        
        SceneManager.LoadScene(scene);
    }

}
