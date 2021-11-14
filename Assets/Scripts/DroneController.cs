using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MG
{
    [RequireComponent(typeof(DroneInputs))]
    public class DroneController : DroneRigidBody
    {
        [Header("Control Properties")]
        [SerializeField] private float minMaxPitch = 30f;
        [SerializeField] private float minMaxRoll = 30f;
        [SerializeField] private float yawPower = 4f;
        [SerializeField] private float lerpSpeed = 2f;
        private DroneInputs input;
        private List<IEngine> engines = new List<IEngine>();

        private float finalPitch;
        private float finalRoll;
        private float yaw;
        private float finalYaw;

        [Header("GroundCheck")]
        [SerializeField] Transform groundCheck;
        [SerializeField] float groundCheckRadius;
        [SerializeField] LayerMask WhatIsGround;
        bool isGrounded;
        private void Awake()//Here
        {
            input = GetComponent<DroneInputs>();
            engines = GetComponentsInChildren<IEngine>().ToList<IEngine>();
        }
        protected override void HandlePhysics()
        {
            HandleEngines();
            HandleControls();
            CheckGround();
        }

       void CheckGround()
        {
            isGrounded= Physics.CheckSphere(groundCheck.position, groundCheckRadius, WhatIsGround);
        }

        protected virtual void HandleEngines() 
        {
            //rb.AddForce(Vector3.up * rb.mass * Physics.gravity.magnitude);
            foreach(IEngine engine in engines)
            {
                engine.UpdateEngine(rb,input,isGrounded);
            }
        }
        protected virtual void HandleControls() 
        {
            float pitch = input.Cyclic.y * minMaxPitch;
            float roll = -input.Cyclic.x * minMaxRoll;
            yaw += input.Pedals *yawPower;

            finalPitch = Mathf.Lerp(finalPitch, pitch, Time.deltaTime*lerpSpeed);
            finalRoll = Mathf.Lerp(finalRoll, roll, Time.deltaTime * lerpSpeed);
            finalYaw = Mathf.Lerp(finalYaw, yaw, Time.deltaTime * lerpSpeed);

            Quaternion rot = Quaternion.Euler(finalPitch, finalYaw, finalRoll);
            rb.MoveRotation(rot);
        }
    }
}
