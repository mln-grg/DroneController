using UnityEngine;
namespace MG
{
    public interface IEngine
    {
        void InitEngine();
        void UpdateEngine(Rigidbody rb,DroneInputs input,bool isGrounded);
    }
}