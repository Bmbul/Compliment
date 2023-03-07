using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.Threading.Tasks;

public class GameManager : MonoBehaviourSingleton<GameManager>
{
    internal bool meFinished;
    internal bool friendFinished;
    int currentLevelIndex = 1;
    private void Start()
    {
        meFinished = friendFinished = false;
        PublicEvents.Instance.WinEvent.AddListener(() => OnLevelWin());
    }

    async void OnLevelWin()
    {
        meFinished = friendFinished = false;
        if (PhotonNetwork.IsMasterClient)
        {
            await Task.Delay(3000);
            PhotonNetwork.LoadLevel(++currentLevelIndex);
        }
    }
}
