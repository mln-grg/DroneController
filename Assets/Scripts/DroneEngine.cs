using UnityEngine;

namespace MG
{
    [RequireComponent(typeof(BoxCollider))]
    public class DroneEngine : MonoBehaviour, IEngine
    {

        [Header("Engine Properties")]
        [SerializeField] private float maxPower = 4f;

        [Header("Propeller Properties")]
        [SerializeField] private Transform propeller;
        [SerializeField] private float propRotSpeedMultiplier;
        private float propRotSpeed;
        public void InitEngine()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateEngine(Rigidbody rb,DroneInputs input,bool isGrounded)
        {
            Vector3 upVec = transform.up;
            upVec.x = 0f;
            upVec.z = 0f;
            float diff = 1 - upVec.magnitude;
            float finalDiff = Physics.gravity.magnitude * diff;
            Vector3 engineForce = Vector3.zero;
            engineForce = transform.up*((rb.mass*Physics.gravity.magnitude + finalDiff) + (input.Throttle*maxPower))/ 4f;

            if (!isGrounded)
                propRotSpeed = propRotSpeedMultiplier;
            else if(propRotSpeed>0)
            {
                propRotSpeed = Mathf.Lerp(propRotSpeed,0,Time.deltaTime*2.5f);
            }
            rb.AddForce(engineForce, ForceMode.Force);
            HandlePropellers();
        }

        void HandlePropellers()
        {
            if (!propeller)
                return;
            propeller.Rotate(Vector3.up, propRotSpeed);

        }
    }
}