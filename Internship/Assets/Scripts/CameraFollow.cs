using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;

    [SerializeField] private Vector3 offset;

    private void Start()
    {
        offset = transform.position - playerTransform.position;
    }

    private void Update()
    {
        Vector3 position = playerTransform.position + offset;
        position.x = 0;
        transform.position = position;
    }
}
