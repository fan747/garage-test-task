using UnityEngine;

namespace Assets.Scripts.Services.InputService
{
    public interface IInput
    {
        public Vector3 GetMovementInput();
        public Vector3 GetLookInput();
    }
}