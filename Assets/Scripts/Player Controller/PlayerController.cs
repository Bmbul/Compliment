using UnityEngine;
using Photon.Pun;

public class PlayerController : MonoBehaviourPun
{
    [SerializeField] CharacterController2D controller;
    [SerializeField] GameObject bullet;
    [SerializeField] float runSpeed;
    Camera mainCamera;

    float horizontalMove = 0;
    bool jump = false;

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        if(!photonView.IsMine) return;

        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        if (Input.GetButtonDown("Jump"))
            jump = true;
        if (Input.GetMouseButtonDown(0))
            Shoot(mainCamera.ScreenToWorldPoint(Input.mousePosition));
    }

    private void FixedUpdate()
    {
        if(!photonView.IsMine) return;

        controller.Move(horizontalMove * Time.fixedDeltaTime, jump);
        jump = false;
    }

    [PunRPC]
    public void Shoot(Vector2 position)
    {
        PhotonNetwork.Instantiate("bullet", position, Quaternion.identity);
    }
}
