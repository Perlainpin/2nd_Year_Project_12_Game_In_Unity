using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lifeness
{
    public class Ennemy : MonoBehaviour
    {
        [SerializeField] float _speed;
        [SerializeField] Animator _myEnnemy;

        Rigidbody _myRigidbody;
        CapsuleCollider _myCapsuleCollider;

        bool _isDead = false;
        int _sign = 1;
        bool hasRotated = false;
        bool hasRotatedAgain = false;

        public bool IsDead
        {
            get => _isDead;
            set => _isDead = value;
        }
        
        void Awake()
        {
            _myRigidbody = GetComponent<Rigidbody>();
            _myCapsuleCollider = GetComponent<CapsuleCollider>();
        }

        void Update()
        {
            bool shouldRotate = !_isDead && transform.position.z >= 57.0f;
            bool shouldRotateAgain = !_isDead && transform.position.z <= -1.071f;
            if ((shouldRotate && !hasRotated) )
            {
                transform.Rotate(Vector3.up, 180f);

                hasRotated = true;
                hasRotatedAgain = false;
            }

            if(shouldRotateAgain && !hasRotatedAgain && hasRotated)
            {
                transform.Rotate(Vector3.up, 180f);

                hasRotatedAgain = true;
                hasRotated = false;
            }
            Dead();

        }

        void Dead()
        {
            if (_isDead == false)
            {
                Vector3 vect = _sign * transform.forward;
                Vector3 vectNormalize = vect.normalized;
                transform.position += vectNormalize * Time.deltaTime * _speed;

            }
            else {
                //_myEnnemy.SetBool("IsDead", false);
                _myCapsuleCollider.isTrigger = true;
                _myRigidbody.isKinematic = true;
            };
        }
    }
}
