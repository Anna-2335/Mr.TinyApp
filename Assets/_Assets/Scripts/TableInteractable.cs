using UnityEngine;

public class TableInteractable : MonoBehaviour
{

    private CameraManager cameraManager;
    //referenced GPT

    private void Start()
    {
        cameraManager = FindFirstObjectByType<CameraManager>();
    }

    public void OnClick()
    {
        Debug.Log("Table clicked!");
        if (cameraManager != null)
        {
            cameraManager.SwitchToTable();
        }
    }
    }
