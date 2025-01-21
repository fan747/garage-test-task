using Assets.Scripts.Other;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Garage
{
    public class GarageTriggerDetector : MonoBehaviour
    {
        [SerializeField] private float _garageDoorOpeningTime;
        [SerializeField] private float _garageDoorOpeningAngle;

        private bool _isDoorsOpen = false;

        private GarageDoorsOpener _garageDoorsOpener;

        [Inject]
        private void Construct(GarageDoorsOpener opener)
        {
            _garageDoorsOpener = opener;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(GameConstants.PlayerTag) && !_isDoorsOpen)
            {
                _garageDoorsOpener.OpenDoors(_garageDoorOpeningTime, _garageDoorOpeningAngle);
                _isDoorsOpen=true;
            }
        }
    }
}
