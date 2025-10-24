using UnityEngine;

public class TableInteractable : MonoBehaviour
{

    public Transform FocusPoint;

    private void Awake()
    {
        if (FocusPoint == null)
            FocusPoint = transform.Find("FocusPoint");

    }

    public void OnClick()
    {
        if (FocusPoint != null)
            CameraManager.Instance.SetTarget(FocusPoint);
        Debug.Log("detecting");
    }
    }
