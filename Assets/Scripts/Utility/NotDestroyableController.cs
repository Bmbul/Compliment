using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.Threading.Tasks;

public class NotDestroyableController : MonoBehaviourSingleton<NotDestroyableController>
{

    [SerializeField] GameObject canvas;

    protected override void Awake()
    {
        base.Awake();

        DontDestroyOnLoad(canvas);
        DontDestroyOnLoad(gameObject);
    }

    public async Task BeforeLeavingRoom()
    {
        Destroy(canvas);
        Destroy(gameObject);
        await Task.Yield();
    }
}
