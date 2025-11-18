using System.Collections;
using TMPro;
using UnityEngine;

public class TextTransitions : MonoBehaviour
{
    TextMeshProUGUI textMeshPro;
    Coroutine textColorTransitionRoutine;
    Coroutine textColorTransitionPulseRoutine;

    [SerializeField] Color startColor;

    [SerializeField] float fadeInDuration;
    [SerializeField] float fadeOutDuration;
    [SerializeField] Color endColor;


    private void Awake()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();
    }



    public void TextColorTransition()
    {
        if (textColorTransitionRoutine != null)
        {
            StopCoroutine(textColorTransitionRoutine);
        }

        textColorTransitionRoutine = StartCoroutine(TextColorTransitionRoutine());
    }

    IEnumerator TextColorTransitionRoutine()
    {
        float time = 0f;
        Color newColor;

        while (time < fadeInDuration)
        {
            time += Time.deltaTime;
            float normalizedTime = time / fadeInDuration;
            newColor = Color.Lerp(startColor, endColor, normalizedTime);
            textMeshPro.color = newColor;
            yield return null;
        }

        textMeshPro.color = endColor;

    }

    public void TextColorTransitionPulse()
    {
        if (textColorTransitionPulseRoutine != null)
        {
            StopCoroutine(textColorTransitionPulseRoutine);
        }

        textColorTransitionPulseRoutine = StartCoroutine(TextColorTransitionPulseRoutine());
    }


    IEnumerator TextColorTransitionPulseRoutine()
    {
        float time = 0f;
        Color newColor;

        while (time < fadeInDuration)
        {
            time += Time.deltaTime;
            float normalizedTime = time / fadeInDuration;
            newColor = Color.Lerp(startColor, endColor, normalizedTime);
            textMeshPro.color = newColor;
            yield return null;
        }

        textMeshPro.color = endColor;

        while (time < fadeOutDuration)
        {
            time += Time.deltaTime;
            float normalizedTime = time / fadeOutDuration;
            newColor = Color.Lerp(endColor, startColor, normalizedTime);
            textMeshPro.color = newColor;
            yield return null;
        }

        textMeshPro.color = startColor;

    }



}
