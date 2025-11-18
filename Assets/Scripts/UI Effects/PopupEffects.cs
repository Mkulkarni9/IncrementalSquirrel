using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PopupEffects : MonoBehaviour
{
    

    [SerializeField] float fadeOutDuration;
    [SerializeField] float moveSpeed;
    [SerializeField] float maxScale;

    float elapsedTime = 0f;
    TextMeshPro text;

    void Awake()
    {
        text = GetComponent<TextMeshPro>();
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;

        MovePopup();

        FadeOutPopup();

        ScaleupPopup();



    }

    void MovePopup()
    {
        this.transform.position += new Vector3(0, Time.deltaTime * moveSpeed, 0);
    }

    void FadeOutPopup()
    {
        float t = Mathf.Clamp01(elapsedTime / fadeOutDuration);
        Color color = text.color;
        color.a = Mathf.Lerp(1f, 0f, t);
        text.color = color;

        if (t >= 1f)
        {
            Destroy(gameObject);
        }
    }


    void ScaleupPopup()
    {
        float t = Mathf.Clamp01(elapsedTime / fadeOutDuration);
        this.transform.localScale = Vector3.Lerp(Vector3.one, Vector3.one * maxScale, t);
    }
}


