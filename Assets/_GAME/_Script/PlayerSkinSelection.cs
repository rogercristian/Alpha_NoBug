using System.Collections.Generic;
using UnityEngine;

public class PlayerSkinSelection : MonoBehaviour
{
    [SerializeField] List<PlayerStats> stats = new List<PlayerStats>();

    private void OnEnable()
    {
        GameEvents.Instance.OnReposition += Handle_OnReposition;

    }
    private void OnDestroy()
    {
        GameEvents.Instance.OnReposition -= Handle_OnReposition;

    }
    private void Handle_OnReposition(int id)
    {
        var skinStats = stats.Find(skin => !skin.gameObject.activeSelf);
        if (skinStats != null)
        {
            // skinStats.gameObject.SetActive(false);

            foreach (var playerStats in stats)
            {
                stats[id].gameObject.SetActive(true);

            }
        }
    }
}
