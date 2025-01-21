using Assets.Scripts.Other;
using Lean.Touch;
using UnityEngine;
using static CW.Common.CwInputManager;

namespace Assets.Scripts.Services.InputService
{
    public class MobileInput : IInput
    {
        private FixedJoystick _joystick;
        public MobileInput(FixedJoystick variableJoystick) 
        { 
            _joystick = variableJoystick;
        }

        Vector3 IInput.GetLookInput()
        {
            var fingers = LeanTouch.Fingers;

            if (fingers.Count > 1)
            {
                var lastFinger = LeanTouch.Fingers[LeanTouch.Fingers.Count - 1];

                if ((lastFinger.IsOverGui || LeanSelectableByFinger.IsSelectedCount > 0))
                {
                    return Vector3.zero;
                }

                float deltaX = lastFinger.ScaledDelta.x;
                float deltaY = lastFinger.ScaledDelta.y;

                return new Vector3(deltaX, deltaY);
            }

            return Vector3.zero;
        }

        Vector3 IInput.GetMovementInput()
        {
            return new Vector3(_joystick.Direction.x, _joystick.Direction.y, 0);
        }
    }
}
