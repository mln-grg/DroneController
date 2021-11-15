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
        float yaw;
        float finalYaw;
        [SerializeField] float yawPower;

        private void Awake()
        {
            cinemachineCamera = GetComponent<CinemachineFreeLook>();
        }

        private void Update()
        {
            yaw+= input.Look*yawPower;
            finalYaw = Mathf.Lerp(finalYaw, yaw, Time.deltaTime * lookSpeed);
            cinemachineCamera.m_XAxis.Value = finalYaw;
        }
    }
}