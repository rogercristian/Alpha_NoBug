using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] Image actorPhoto;
    [SerializeField] TMP_Text nameText;
    [SerializeField] DialogBar dialogBar;
    [SerializeField] DialogText dialogText;

    [Header("Settings")]
    [SerializeField] float intervalBetweenSentences = 1f;
    [SerializeField] internal InputManager inputManager;
    void Start()
    {
        GameEvents.Instance.OnStartDialog += HandleOnStartDialog;
    }

    private void HandleOnStartDialog(DialogData dialogData)
    {
        inputManager = FindAnyObjectByType<InputManager>();
        StartCoroutine(StartDialog(dialogData));
    }

    IEnumerator StartDialog(DialogData dialogData)
    {
        actorPhoto.enabled = false;
        nameText.SetText("");
        yield return dialogBar.ShowBar();
        actorPhoto.enabled = true;

        foreach (var sentence in dialogData.Sentences)
        {
            nameText.SetText(sentence.ActorData.characterName);
            actorPhoto.sprite = sentence.ActorData.characterPhoto;
            yield return dialogText.ShowText(sentence.Content);
            yield return new WaitForSeconds(intervalBetweenSentences);
        }
        dialogText.HideText();
        yield return dialogBar.HideBar();
        GameEvents.Instance.FinishDialog();
    }
    private void OnDestroy()
    {
        GameEvents.Instance.OnStartDialog -= HandleOnStartDialog;

    }
    // Update is called once per frame
    void Update()
    {
        if (inputManager == null) return;
        if (inputManager.GetButtonX())
        {
            dialogText.SkipAnimation();
        }
    }
}
