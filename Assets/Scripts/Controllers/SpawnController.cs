using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.Tilemaps;

public class SpawnController : MonoBehaviour
{
    [SerializeField] GameObject playerPrefab;
    [SerializeField] Transform[] SpawnPositions;
    [SerializeField] GameObject[] gridObjects;
    [SerializeField] GameObject[] props;
    Transform playerTransform;

    int playerIndex;

    private void Awake()
    {
        playerIndex = (int)GamePersistentData.Instance.index;
    }

    private void Start()
    {
        SpawnPlayer();
        PublicEvents.Instance.ReplayEvent.AddListener(() => ResetPosition());
    }

    private void SpawnPlayer()
    {
        playerTransform = PhotonNetwork.Instantiate(playerPrefab.name, SpawnPositions[playerIndex].position, Quaternion.identity).transform;
        props[playerIndex].SetActive(true);
        gridObjects[playerIndex].GetComponent<Collider2D>().enabled = false;
        gridObjects[(playerIndex + 1) % 2].GetComponent<TilemapRenderer>().enabled = false;
    }

    private void ResetPosition()
    {
        playerTransform.position = SpawnPositions[playerIndex].position;
    }
}
