using UnityEngine;
using Cinemachine;

namespace MG
{
    [RequireComponent(typeof(CinemachineFreeLook))]
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private DroneInputs input;
        private CinemachineFreeLook cinemachineCamera;

        [SerializeField] float lookSpeed;

        private void Awake()
        {
            cinemachineCamera = GetComponent<CinemachineFreeLook>();
        }

        private void Update()
        {
            float delta = input.Look;
            cinemachineCamera.m_XAxis.Value += delta * lookSpeed * Time.deltaTime;
        }
    }
}