using Assets.Scripts.Services.InputService;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Player
{
    public class PlayerMovement
    {
        private Rigidbody _rb;

        public PlayerMovement(Rigidbody rigidbody)
        {
            _rb = rigidbody;
        }

        public void Move(Vector2 moveInput, float speed)
        {
            Vector3 moveDirection = _rb.transform.right * moveInput.x + _rb.transform.forward * moveInput.y;

            _rb.velocity = new Vector3(moveDirection.x * speed * Time.deltaTime, _rb.velocity.y, moveDirection.z * speed * Time.deltaTime);
        }

        public void RotateToDelta(Vector2 delta, float speed)
        {
            {
                Vector3 rotation = _rb.rotation.eulerAngles - new Vector3(-delta.y, delta.x) * speed * Time.deltaTime;
                _rb.rotation = Quaternion.Euler(rotation);
            }
        }
    }
} 