using UnityEngine;

using UnityEngine.InputSystem;


namespace MG
{ 
    [RequireComponent(typeof(PlayerInput))]
    public class DroneInputs : MonoBehaviour
    {
        private Vector2 cyclic;
        private float throttle;
        private float pedals;
        private float look;

        #region getters
        public Vector2 Cyclic { get => cyclic;}
        public float Throttle { get => throttle;}
        public float Pedals { get => pedals;}
        public float Look { get => look;}
        #endregion

        private void Update()
        {
        }

        private void OnCyclic(InputValue value)
        {
            cyclic = value.Get<Vector2>();
        }
        private void OnThrottle(InputValue value)
        {
            throttle = value.Get<float>();
        }
        private void OnPedals(InputValue value)
        {
            pedals = value.Get<float>();
        }

        private void OnLook(InputValue value)
        {
            look = value.Get<float>();
        }
    }
}