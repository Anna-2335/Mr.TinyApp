using UnityEngine;
using System.Collections.Generic;
using Unity.Cinemachine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager Instance;

    [SerializeField] private CinemachineCamera vcam;
    [SerializeField] private Transform playerTransform;

    private Transform currentTarget;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        // default follow/look to player
        SetTarget(playerTransform);
    }

    public void SetTarget(Transform target)
    {
        if (vcam == null || target == null) return;

        // Modern way: set Follow and LookAt
        vcam.Follow = target;
        vcam.LookAt = target;
    }

    public void ResetToPlayer()
    {
        SetTarget(playerTransform);
    }
}

