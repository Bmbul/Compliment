using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;
using Photon.Realtime;

public class CreateOrJoinToRoom : MonoBehaviour
{
    [SerializeField] TMP_InputField createInput;
    [SerializeField] TMP_InputField joinInput;
    RoomOptions roomOptions;

    private void Awake()
    {
        roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 2;
    }

    public void CreateServer()
    {
        if (createInput.text == string.Empty)
            PhotonNetwork.CreateRoom("abc", roomOptions);
        else PhotonNetwork.CreateRoom(createInput.text, roomOptions);
        GamePersistentData.Instance.index = PlayerIndex.first;
    }

    public void JoinServer()
    {
        if (joinInput.text == string.Empty)
            PhotonNetwork.JoinRoom("abc");
        else
            PhotonNetwork.JoinRoom(joinInput.text);
        GamePersistentData.Instance.index = PlayerIndex.second;
    }
}
