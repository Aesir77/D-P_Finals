using Cinemachine;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Manager : MonoBehaviour
{
    static List<CinemachineVirtualCamera> cameras = new List<CinemachineVirtualCamera>();
    public static CinemachineVirtualCamera ActiveCamera = null;
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public static bool IsActiveCamera(CinemachineVirtualCamera camera)
    {
        return ActiveCamera == camera;
    }
    public static void SwitchCamera(CinemachineVirtualCamera newCamera)
    {
        newCamera.Priority = 11;
        ActiveCamera = newCamera;

        foreach (CinemachineVirtualCamera cam in cameras)
        {
            if (cam != newCamera)
            {
                cam.Priority = 0;
            }
        }
    }
    public static void Register(CinemachineVirtualCamera camera)
    {
        cameras.Add(camera);
    }

    public static void Unregister(CinemachineVirtualCamera camera)
    {
        cameras.Remove(camera);
    }
}
