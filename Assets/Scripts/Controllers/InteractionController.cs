using UnityEngine;
using Photon.Pun;

public class InteractionController : MonoBehaviour
{
    bool viewisMine;

    private void Awake()
    {
        viewisMine = gameObject.GetComponent<PhotonView>().IsMine;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "WinArea")
        {
            if (viewisMine)
                GameManager.Instance.meFinished = true;
            else
                GameManager.Instance.friendFinished = true;

            if (GameManager.Instance.meFinished && GameManager.Instance.friendFinished)
                PublicEvents.Instance.WinEvent.Invoke();
        }
        if (!viewisMine) return;

        if (collision.tag == "LoseArea" || collision.tag == "Enamy")
            PublicEvents.Instance.LoseEvent.Invoke();
    }


}
