using System;
using Cinemachine;
using UnityEngine;

[RequireComponent(typeof(CinemachineBrain))]
[RequireComponent(typeof(Camera))]
public class CameraSystem : MonoBehaviour
{
    private CinemachineBrain _cinemachineBrain;
    private Camera _mainCamera;

    public CinemachineBrain CinemachineBrain => _cinemachineBrain != null
        ? _cinemachineBrain
        : _cinemachineBrain = GetComponent<CinemachineBrain>();

    public Camera MainCamera => _mainCamera != null
        ? _mainCamera
        : _mainCamera = GetComponent<Camera>();

    public void OnDisable()
    {
        _mainCamera = null;
        _cinemachineBrain = null;
    }
}
