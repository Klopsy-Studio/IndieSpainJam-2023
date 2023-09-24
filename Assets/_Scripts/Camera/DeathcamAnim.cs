using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class DeathcamAnim : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera CMVirtualCamera;
    [SerializeField] private float rotationSpeed = 0.5f;

    private void OnEnable()
    {
        CMVirtualCamera.GetCinemachineComponent<CinemachineOrbitalTransposer>().m_XAxis.m_InputAxisValue = rotationSpeed;
    }

    private void Update()
    {
        CMVirtualCamera.GetCinemachineComponent<CinemachineOrbitalTransposer>().m_XAxis.m_InputAxisValue = rotationSpeed;
    }

}
