using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCursor : MonoBehaviour
{
    [SerializeField] Camera mainCamera;
    Transform _transform;
    Vector3 worldPosition;
    Vector3 newPosition;
    private void Awake()
    {
        _transform = transform;
    }

    void Update()
    {
        worldPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        newPosition = worldPosition + Vector3.forward * 10;
        _transform.position = newPosition;
    }
}
