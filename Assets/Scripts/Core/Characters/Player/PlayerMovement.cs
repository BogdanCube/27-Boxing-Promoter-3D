using System;
using Core.Characters._Base;
using Core.Components;
using Core.Environment.UpgraderPlayer;
using NaughtyAttributes;
using UnityEngine;

namespace Core.Characters.Player
{
    public class PlayerMovement : UpdaterPosition, IUpgrader
    {
        [SerializeField] private Joystick _joystick;
      
        public override bool IsMove => GetMoveVector() != Vector3.zero;
        
        protected override void MoveLogic()
        {
            Rotation(GetMoveVector());
            _navMeshAgent.Move(GetMoveVector() * (_speed * Time.deltaTime));
        }
        private void Rotation(Vector3 moveVector)
        {
            if (!(Vector3.Angle(Vector3.forward, moveVector) > 1f) && Vector3.Angle(Vector3.forward, moveVector) != 0)
            {
                return;
            }
            
            var direct = Vector3.RotateTowards(transform.forward, moveVector, _speed, 0.0f);
            transform.rotation = Quaternion.LookRotation(direct);
        }

        private Vector3 GetMoveVector()
        {
            var moveVector = Vector3.zero;
            moveVector.x = _joystick.Horizontal + Input.GetAxis("Horizontal");
            moveVector.z = _joystick.Vertical + Input.GetAxis("Vertical");

            return moveVector;
        }

        public void SetUpgrades(int upgradeSpeed)
        {
            _speed = upgradeSpeed;
            _navMeshAgent.speed = _speed;
        }
    }
}
