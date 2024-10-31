using UnityEngine;
using TMPro;
using System.Collections;

public class BlinkingTextMeshPro : MonoBehaviour
{
    public TextMeshProUGUI textToBlink;  
    public float blinkDuration = 1f; 

    private Color originalColor;  
    private bool isBlinking = false;

    void Start()
    {
        if (textToBlink == null)
        {
            textToBlink = GetComponent<TextMeshProUGUI>();
        }
        originalColor = textToBlink.color;
        StartBlinking();
    }

    public void StartBlinking()
    {
        if (!isBlinking)
        {
            isBlinking = true;
            StartCoroutine(BlinkText());
        }
    }

    public void StopBlinking()
    {
        if (isBlinking)
        {
            isBlinking = false;
            StopCoroutine(BlinkText());
            textToBlink.color = originalColor;
        }
    }

    IEnumerator BlinkText()
    {
        while (isBlinking)
        {
            float elapsedTime = 0f;
            while (elapsedTime < blinkDuration)
            {
                elapsedTime += Time.deltaTime;
                float alpha = Mathf.PingPong(elapsedTime, blinkDuration / 2) / (blinkDuration / 2);
                Color newColor = originalColor;
                newColor.a = alpha;
                textToBlink.color = newColor;
                yield return null;
            }
        }
    }
}
