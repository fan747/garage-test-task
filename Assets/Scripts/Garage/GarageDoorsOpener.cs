using Assets.Scripts.Other;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Garage
{
    public class GarageDoorsOpener : MonoBehaviour
    {
        private Coroutine _doorsOpenerCoroutine;
        private Transform _doorLeftTransform;
        private Transform _doorRightTransform;

        [Inject]
        private void Construct([Inject(Id = GameConstants.DoorLeftId)]Transform doorLefttransform,
            [Inject(Id = GameConstants.DoorRightId)] Transform doorRightTransform)
        {
            _doorLeftTransform = doorLefttransform;
            _doorRightTransform = doorRightTransform;
        }

        public void OpenDoors(float openTime, float openAngle)
        {
            _doorsOpenerCoroutine = StartCoroutine(OpenDoorsCoroutine(openTime, openAngle));
        }

        private IEnumerator OpenDoorsCoroutine(float openTime, float openAngle)
        {
            float timer = 0;
            float leftDoorStartYAngle = _doorLeftTransform.rotation.eulerAngles.y;
            float rightDoorStartYAngle = _doorRightTransform.rotation.eulerAngles.y;

            while (timer < openTime)
            {
                timer += Time.deltaTime;
                float normalizeTimer = timer / openTime;

                float leftDoorYAngle = Mathf.Lerp(leftDoorStartYAngle, openAngle, normalizeTimer);
                _doorLeftTransform.rotation = Quaternion.Euler(_doorLeftTransform.rotation.eulerAngles.x, leftDoorYAngle, _doorLeftTransform.rotation.eulerAngles.z);

                float rightDoorYAngle = Mathf.Lerp(rightDoorStartYAngle, -openAngle, normalizeTimer);
                _doorRightTransform.rotation = Quaternion.Euler(_doorRightTransform.rotation.eulerAngles.x, rightDoorYAngle, _doorRightTransform.rotation.eulerAngles.z);

                yield return null;
            }
        }
    }
}