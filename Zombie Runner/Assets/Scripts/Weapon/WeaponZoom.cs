using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using StarterAssets;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera fpsCamera;
    [SerializeField] float zoomedOutFOV = 60f;
    [SerializeField] float zoomedInFOV = 20f;
    [SerializeField] float zoomOutSensitivity = 2f;
    [SerializeField] float zoomInSensitivity = 0.5f;
    bool zoomedInToggle = false;

    private FirstPersonController fpsController;

    private void OnDisable()
    {
        ZoomOut();
    }

    private void Start()
    {
        fpsController = GetComponentInParent<FirstPersonController>();
    }
    public void ZoomCamera()
    {
        if (zoomedInToggle == false)
        {
            ZoomIn();
        }
        else
        {
            ZoomOut();
        }
    }

    private void ZoomOut()
    {
        zoomedInToggle = false;
        fpsController.RotationSpeed = zoomOutSensitivity;
        fpsCamera.m_Lens.FieldOfView = zoomedOutFOV;
    }

    private void ZoomIn()
    {
        zoomedInToggle = true;
        fpsController.RotationSpeed = zoomInSensitivity;
        fpsCamera.m_Lens.FieldOfView = zoomedInFOV;
    }
}
