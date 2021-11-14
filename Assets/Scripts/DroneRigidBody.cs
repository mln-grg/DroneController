using UnityEngine;

namespace MG
{
    [RequireComponent(typeof(Rigidbody))]
    public class DroneRigidBody : MonoBehaviour
    {
        [Header("RigidBody Properties")]
        [SerializeField] private float droneWeight = .5f;

        protected Rigidbody rb;
        protected float startDrag;
        protected float startAngularDrag;
        private void Start()//Here
        {
            rb = GetComponent<Rigidbody>();
            rb.mass = droneWeight;
            startDrag = rb.drag;
            startAngularDrag = rb.angularDrag;
        }

        private void FixedUpdate()
        {
            HandlePhysics();
        }

        protected virtual void HandlePhysics() { }
    }
}
