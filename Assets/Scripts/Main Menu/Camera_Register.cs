using UnityEngine;
using Cinemachine;
using System.Collections.Generic;

public class Camera_Register : MonoBehaviour
{
    private void OnEnable()
    {
        Camera_Manager.Register(GetComponent<CinemachineVirtualCamera>());
    }
    private void OnDisable()
    {
        Camera_Manager.Unregister(GetComponent<CinemachineVirtualCamera>());
    }
}
