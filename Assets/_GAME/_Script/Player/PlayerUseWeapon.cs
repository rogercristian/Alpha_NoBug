using System.Collections;
using UnityEngine;

public class PlayerUseWeapon : MonoBehaviour
{
    private Weapon weapon;
    private InputManager inputManager;
    Animator animator;
    bool canShoot = true;    
    private void Start()
    {
        weapon = GetComponentInChildren<Weapon>();
        if (inputManager != null) return;
        inputManager = GetComponentInParent<InputManager>();
        GameEvents.Instance.OnStartDialog += HandleOnStartDialog;
        GameEvents.Instance.OnFinishDialog += HandlerOnFinishDialog;
        animator = GetComponentInParent<Animator>();
    }

    private void OnDestroy()
    {
        GameEvents.Instance.OnStartDialog -= HandleOnStartDialog;
        GameEvents.Instance.OnFinishDialog -= HandlerOnFinishDialog;
    }
    private void HandleOnStartDialog(DialogData dialogData) => canShoot = false;

    private void HandlerOnFinishDialog() => canShoot = true;
    void Update()
    {       
        if (!canShoot) return;

        float buttonRt = inputManager.GetButtonRtPressed();

        if (buttonRt > 0.1f || inputManager.GetInteractPressed())
        {
            StartCoroutine(DelayFrame());
            weapon.Shoot();
        }
    }
    IEnumerator DelayFrame()
    {
        yield return new WaitForEndOfFrame();
    }
}
