using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;

public enum PhotonEventCodes
{
    GameWin,
    GameLose
}

public class GameEventsHandler : MonoBehaviour, IOnEventCallback
{
    private void OnEnable()
    {
        PhotonNetwork.NetworkingClient.EventReceived += OnEvent;
    }

    private void OnDisable()
    {
        PhotonNetwork.NetworkingClient.EventReceived -= OnEvent;
    }

    public void OnEvent(EventData photonEvent)
    {
        switch (photonEvent.Code)
        {
            case (byte)PhotonEventCodes.GameWin:
                Debug.LogWarning("Win The Game Event Raised");
                break;
            case (byte)PhotonEventCodes.GameLose:
                // do something else
                break;
        }
    }
}
