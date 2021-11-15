using UnityEngine;

namespace MG
{
    public class CameraControllerNonCinemachine : MonoBehaviour
    {
        public static CameraControllerNonCinemachine instance = null;
        [SerializeField] private DroneInputs input;
        float lookAngle;
        [SerializeField] float lookSpeed;
        [SerializeField] float cameraFollowSpeed;
        Vector3 currentVelocity = Vector3.zero;
        [SerializeField] private Vector3 offset;

        Transform mainCamera;
        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(this);
            }

            mainCamera = Camera.main.transform;
        }

        private void Start()
        {
            
        }

        public void RotateCamera(Transform target)
        {
            /*lookAngle += input.Look * lookSpeed;
            Vector3 rotation = Vector3.zero;
            rotation.y = lookAngle;
            Quaternion targetRotation = Quaternion.Euler(rotation);
            mainCamera.rotation = targetRotation;*/
        }

        public void FollowTarget(Vector3 targetPosition)
        {
            /*Vector3 target = Vector3.SmoothDamp(mainCamera.position, targetPosition+offset, ref currentVelocity, cameraFollowSpeed);
            mainCamera.position = target;*/
            Vector3 desiredPosition = targetPosition + offset;
            Vector3 smoothedPosition = Vector3.Lerp(mainCamera.position, desiredPosition, cameraFollowSpeed * Time.deltaTime);
            mainCamera.position = smoothedPosition;

            mainCamera.LookAt(targetPosition);
        }
    }
}