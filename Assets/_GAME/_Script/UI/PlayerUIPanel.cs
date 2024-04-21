using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIPanel : MonoBehaviour
{
    [SerializeField] TMP_Text playerName;
    // [SerializeField] CharacterData playerData;
    PlayerStats playerStats;
    [SerializeField] TMP_Text level;
    [SerializeField] Image photo;
    [SerializeField] HpManager hpManager;
    [SerializeField] Transform barTransform;
    [SerializeField] GameObject root;
    MovingPlayer movingPlayer;

    public void AssignPlayer(int index)
    {
        StartCoroutine(AssignPlayerDelay(index));
    }

    IEnumerator AssignPlayerDelay(int index)
    {
        yield return new WaitForSeconds(0.01f);
        movingPlayer = ManualPlayerJoin.instance.playerList[index].GetComponent<PlayerInputHandler>().GetMovingPlayer();
        playerStats = ManualPlayerJoin.instance.playerList[index].GetComponent<PlayerInputHandler>().GetComponentInChildren<PlayerStats>();
        hpManager = ManualPlayerJoin.instance.playerList[index].GetComponent<PlayerInputHandler>().GetComponentInChildren<HpManager>();
        //print(movingPlayer.name);
        SetUpInfoPanel();
    }

    private void SetUpInfoPanel()
    {
        if (movingPlayer != null)
        {
            //score
            // level
            level.text = playerStats.Level().ToString();
            //name
            playerName.text = playerStats.PlayerName();
            //foto
            photo.sprite = playerStats.Sprite();

            hpManager.OnLifeChanged += HandlerOnLifeChanged;

        }
    }
    private void HandlerOnLifeChanged(int obj)
    {
        barTransform.localScale = new Vector3(hpManager.GetLifeNormalized(), 1, 1);
        root.SetActive(!hpManager.IsFullHP());
    }
}
