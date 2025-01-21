using Assets.Scripts.Services.InputService;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed;
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private float _rotationSpeed;

        private PlayerMovement _playerMovement;
        private IInput _input;


        [Inject]
        private void Construct(IInput input)
        {
            _playerMovement = new(_rigidbody);
            _input = input;
        }

        private void Update()
        {
            _playerMovement.Move(_input.GetMovementInput(), _moveSpeed);
            _playerMovement.RotateToDelta(_input.GetLookInput(), _rotationSpeed);
        }
    }
}