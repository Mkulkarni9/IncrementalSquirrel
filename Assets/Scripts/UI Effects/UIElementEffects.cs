using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIElementEffects : MonoBehaviour
{

    public static event Action OnUIElementPositionChangeStarted;

    RectTransform rectTransform;
    Button button;
    Image image;

    Coroutine moveUIRoutine;
    Coroutine imageScalePulseRoutine;
    Coroutine imagColorPulseRoutine;



    [Header("Position Change Settings")]
    [SerializeField] Vector3 position1;
    [SerializeField] Vector3 position2;
    [SerializeField] float positionChangeDuration;
    [SerializeField] AnimationCurve positionChangeAnimationCurve;
    [SerializeField] float intervalBetweenElements;
    [SerializeField] int index;

    [Header("Image Scale Pulse Settings")]
    [SerializeField] float increaseTimeScalePulse;
    [SerializeField] float decreaseTimeScalePulse;
    [SerializeField] float targetScale;
    [SerializeField] AnimationCurve scalePulseUpAnimationCurve;
    [SerializeField] AnimationCurve scalePulseDownAnimationCurve;
    [SerializeField] bool isInfiniteScalePulse;
    [SerializeField] float intervalBetweenScalePulses;
    bool isImageScalePulsing;
    

    [Header("Image Color Pulse Settings")]
    [SerializeField] Color endColor;
    [SerializeField] float increaseTimeColorPulse;
    [SerializeField] float decreaseTimeColorPulse;
    [SerializeField] bool isInfiniteColorPulse;
    [SerializeField] float intervalBetweenColorPulses;
    bool isImageColorPulsing;


    Vector3 originalScale;
    Color startColor;



    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        button = GetComponent<Button>();
        image = GetComponent<Image>();

        if (button != null)
        {
            button.interactable = false;
        }

    }

    void Start()
    {
        rectTransform.anchoredPosition = position1;
        originalScale = transform.localScale;
        startColor = image.color;
    }

    #region Change Position of UI Element
    public void DisplayElement()
    {
        ChangePosition(position1, position2);
    }

    public void HideElement()
    {
        ChangePosition(position2, position1);
    }

    public void ChangePosition(Vector3 startPosition, Vector3 targetPosition)
    {
        if (moveUIRoutine != null)
        {
            StopCoroutine(moveUIRoutine);
        }
        moveUIRoutine = StartCoroutine(MoveUIRoutine(startPosition, targetPosition));
    }

    private IEnumerator MoveUIRoutine(Vector3 startPosition, Vector3 targetPosition)
    {
        yield return new WaitForSeconds(intervalBetweenElements * index);

        OnUIElementPositionChangeStarted?.Invoke();

        float timePassed = 0f;

        while (timePassed < positionChangeDuration)
        {
            float t = timePassed / positionChangeDuration;
            float curveT = positionChangeAnimationCurve.Evaluate(t);
            rectTransform.anchoredPosition = Vector3.Lerp(startPosition, targetPosition, curveT);
            timePassed += Time.unscaledDeltaTime;
            yield return null;
        }
        rectTransform.anchoredPosition = targetPosition;

        if (button != null)
        {
            button.interactable = true;
        }


    }

    #endregion

    #region Image scale effects

    public void ImageScalePulse(int numberOfPulses)
    {
        isImageScalePulsing = true;

        if (imageScalePulseRoutine != null)
        {
            StopCoroutine(imageScalePulseRoutine);
        }

        imageScalePulseRoutine = StartCoroutine(ImageScalePulseRoutine(numberOfPulses));
    }

    IEnumerator ImageScalePulseRoutine(int numberOfPulses)
    {
        float t = 0f;
        int pulseCount = 0;

        while(isImageScalePulsing)
        {
            while (t < increaseTimeScalePulse)
            {
                t += Time.deltaTime;
                float normalized = Mathf.Clamp01(t / increaseTimeScalePulse);
                //float scale = Mathf.Lerp(originalScale.x, targetScale, normalized);
                float curveT = scalePulseUpAnimationCurve.Evaluate(normalized);
                transform.localScale = new Vector3(curveT, curveT, originalScale.z);
                yield return null;
            }
            transform.localScale = new Vector3(targetScale, targetScale, originalScale.z);

            t = 0f;
            while (t < decreaseTimeScalePulse)
            {
                t += Time.deltaTime;
                float normalized = Mathf.Clamp01(t / decreaseTimeScalePulse);
                //float scale = Mathf.Lerp(targetScale, originalScale.x, normalized);
                float curveT = scalePulseDownAnimationCurve.Evaluate(normalized);
                transform.localScale = new Vector3(curveT, curveT, originalScale.z);
                yield return null;
            }
            transform.localScale = originalScale;
            
            t = 0f;

            if(!isInfiniteScalePulse)
            {
                pulseCount++;

                if(pulseCount == numberOfPulses)
                {
                    isImageScalePulsing = false;
                }
            }

            yield return new WaitForSeconds(intervalBetweenScalePulses);
        }

    }

    public void StopImageScalePulse()
    {
        isImageScalePulsing = false;

        if (imageScalePulseRoutine != null)
        {
            StopCoroutine(imageScalePulseRoutine);
        }

        transform.localScale = originalScale;
    }

    #endregion

    #region Image color effects

    public void ImageColorPulse(int numberOfPulses)
    {
        isImageColorPulsing = true;

        if (imagColorPulseRoutine != null)
        {
            StopCoroutine(imagColorPulseRoutine);
        }

        imagColorPulseRoutine = StartCoroutine(ImageColorPulseRoutine(numberOfPulses));
    }

    IEnumerator ImageColorPulseRoutine(int numberOfPulses)
    {
        float time = 0f;
        Color newColor;
        int pulseCount = 0;

        while (isImageColorPulsing)
        {
            while (time < increaseTimeColorPulse)
            {
                time += Time.deltaTime;
                float normalizedTime = time / increaseTimeColorPulse;
                newColor = Color.Lerp(startColor, endColor, normalizedTime);
                image.color = newColor;
                yield return null;
            }

            image.color = endColor;

            while (time < decreaseTimeColorPulse)
            {
                time += Time.deltaTime;
                float normalizedTime = time / decreaseTimeColorPulse;
                newColor = Color.Lerp(endColor, startColor, normalizedTime);
                image.color = newColor;
                //Debug.Log("Font size decreasing: " + textMeshPro.fontSize);
                yield return null;
            }

            image.color = startColor;
            time = 0f;

            if (!isInfiniteColorPulse)
            {
                pulseCount++;

                if (pulseCount == numberOfPulses)
                {
                    isImageColorPulsing = false;
                }
            }

            yield return new WaitForSeconds(intervalBetweenColorPulses);
        }
        

    }

    public void StopImageColorPulse()
    {
        isImageColorPulsing = false;

        if (imagColorPulseRoutine != null)
        {
            StopCoroutine(imagColorPulseRoutine);
        }

        image.color = startColor;
    }

    #endregion
}
