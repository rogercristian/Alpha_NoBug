using UnityEngine;

public class HPBar : MonoBehaviour
{
    [SerializeField] HpManager hpManager;
    [SerializeField] Transform barTransform;
    [SerializeField] GameObject root;

    private void Awake()
    {
        hpManager.OnLifeChanged += HandlerOnLifeChanged;
    }
    private void OnDestroy()
    {
        hpManager.OnLifeChanged -= HandlerOnLifeChanged;
        root.SetActive(false);
    }
    private void HandlerOnLifeChanged(int obj)
    {
        barTransform.localScale = new Vector3(hpManager.GetLifeNormalized(), 1, 1);
        root.SetActive(!hpManager.IsFullHP());
    }

}
