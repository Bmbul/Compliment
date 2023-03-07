using Photon.Pun;

public class MultiplayerController : MonoBehaviourPunCallbacks
{
    public static MultiplayerController Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedRoom()
    {
        if(PhotonNetwork.IsMasterClient)
            PhotonNetwork.LoadLevel(1);
    }
    internal async void OnLeave()
    {
        await NotDestroyableController.Instance.BeforeLeavingRoom();
        PhotonNetwork.LeaveRoom();
    }

    public override void OnLeftRoom()
    {
        PhotonNetwork.LoadLevel("Lobby");
    }
}
