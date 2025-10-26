using UnityEngine;
using System.Collections.Generic;
using Unity.Cinemachine;

public class CameraManager : MonoBehaviour
{
    //handles switching between interacting to tables

    public CinemachineCamera playerCam;
    public CinemachineCamera tableCam;
    public void SwitchToTable(Transform tableFocus)
    {

      //  tableCam.TrackingTarget = tableFocus;

        playerCam.Priority = 10;
        tableCam.Priority = 20;
        Debug.Log("Switched to Table Camera");
    }


    public void SwitchToPlayer()
    {
        playerCam.Priority = 20;
        tableCam.Priority = 10;
        Debug.Log("Switched back to Player Camera");
    }

}

