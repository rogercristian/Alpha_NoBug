using System;
using UnityEngine;
[DefaultExecutionOrder(-1)]
public class GameEvents : MonoBehaviour
{
    public static GameEvents Instance { get; private set; }
    private void Awake() => Instance = this;

    public event Action<int> OnReposition;
    public void Reposition(int id) => OnReposition?.Invoke(id);
    //
    public event Action OnSeekPlayer;
    public void SeekPlayer() => OnSeekPlayer?.Invoke();
    //
    public event Action OnSelectSkin;
    public void SelectSkin() => OnSelectSkin?.Invoke();
    //
    public event Action<DialogData> OnStartDialog;
    public void StartDialog(DialogData dialogData) => OnStartDialog?.Invoke(dialogData);

   // public event Action<DialogData> OnCancelDialog;
    public event Action OnFinishDialog;
    public void FinishDialog() => OnFinishDialog?.Invoke();

    public event Action<string> OnAnimationChange;
    public void AnimationChange(string newstate) => OnAnimationChange?.Invoke(newstate);

    public event Action CanChangeAnimation;
    public void CanChangeAnim() => CanChangeAnimation?.Invoke();
}
