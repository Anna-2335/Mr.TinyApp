using UnityEngine;

public class TableInteractable : MonoBehaviour
{
    [SerializeField] private Transform focusPoint;

    private CameraManager cameraManager;
    //referenced GPT

    private void Start()
    {
        cameraManager = FindFirstObjectByType<CameraManager>();
    }

    public void OnClick()
    {
        if (cameraManager != null && focusPoint != null)
        {
            cameraManager.SwitchToTable(focusPoint);
        }
    }
    }
