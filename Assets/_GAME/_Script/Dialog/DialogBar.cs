using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class DialogBar : MonoBehaviour
{
    Image barImage;
    private RectTransform rectTransform;

    Vector2 hiddenSize = new Vector2(0, 0);
    private Vector2 visibleSize = new Vector2(1, 1);

    private void Awake()
    {
        barImage = GetComponent<Image>();
        rectTransform = GetComponent<RectTransform>();
    }
    void Start()
    {
        rectTransform.localScale = hiddenSize;
    }

    public IEnumerator ShowBar()
    {
        while(rectTransform.localScale.x < visibleSize.x)
        {
            rectTransform.localScale = Vector2.right * 200 * Time.deltaTime;
            yield return null;
        }

        rectTransform.localScale = visibleSize;
    }

    public IEnumerator HideBar()
    {
        while (rectTransform.localScale.x > hiddenSize.x)
        {
            rectTransform.localScale = -Vector2.right * 200 * Time.deltaTime;
            yield return null;
        }

        rectTransform.localScale = hiddenSize;
    }
   
}
