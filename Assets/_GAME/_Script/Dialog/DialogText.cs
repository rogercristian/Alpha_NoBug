using System.Collections;
using TMPro;
using UnityEngine;
[RequireComponent(typeof(TMP_Text))]
public class DialogText : MonoBehaviour
{
    [SerializeField] float intervalBetweenChars = .2f;
    TMP_Text text;

    private void Awake() => text = GetComponent<TMP_Text>();

    public IEnumerator ShowText(string content)
    {
        text.maxVisibleCharacters = 0;
        text.SetText(content);
        yield return RevealChars();
    }
    public void HideText()
    {
        text.SetText("");
        text.maxVisibleCharacters = 0;
    }

    public void SkipAnimation() => text.maxVisibleCharacters = text.textInfo.characterCount;
    IEnumerator RevealChars()
    {
        while (text.maxVisibleCharacters <= text.textInfo.characterCount)
        {
            yield return new WaitForSeconds(intervalBetweenChars);
            text.maxVisibleCharacters++;
        }
    }

}
