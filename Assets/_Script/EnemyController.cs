using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

namespace Lifeness
{
    public class EnemyController : MonoBehaviour
    {
        private enum State { Sleep, Patrol, Detected }
        private State _currentState;
        GameObject _player;
        [SerializeField] float _target;
        [SerializeField] int _nbMadness;

        [SerializeField] GameObject _animation;

        [SerializeField] float _time;
        [SerializeField] float _speed;
        float _currentTime;
        float _move;

        Animator _animator;
        Eye _eye;
        TMP_Text GameOver;

        [SerializeField] LayerMask _layerMask;
        // Start is called before the first frame update
        void Start()
        {
            _currentState = State.Sleep;

            _currentTime = 0;
            _move = -0.4f;
            _animator = _animation.GetComponent<Animator>();
            _animator.SetBool("IsIdle", true);
            _player = GameObject.Find("Walking 1");
            _eye = GameObject.Find("Eye").GetComponent<Eye>();
            GameOver = GameObject.Find("GameOver").GetComponent<TMP_Text>();
        }

        // Update is called once per frame
        void Update()
        {
            switch (_currentState)
            {
                case State.Sleep:

                    Sleep();
                    break;
                case State.Patrol:
                    Patrol();
                    break;
                case State.Detected:
                    Detected();
                    break;
            }
        }

        void Sleep()
        {
            Vector3 vect = _player.GetComponent<Transform>().position - transform.position;
            if (vect.sqrMagnitude < _target + 60 && _player.GetComponent<PlayerMadness>().CurrentMadness > _nbMadness)
            {
                _animator.SetBool("IsIdle", false);
                _animator.SetBool("IsPatrol", true);
                _eye.ChangeState(1);
                _currentState = State.Patrol;
            }
        }

        void Patrol()
        {
            _currentTime += Time.deltaTime;
            if (_currentTime > _time)
            {
                _move = -_move;
                _currentTime = 0;
                transform.Rotate(0f, 180f, 0f);
            }

            Vector3 vect = new Vector3(0f, 0f, _move);
            transform.position += vect * Time.deltaTime * _speed;

            Vector3 vectLength = _player.transform.position - transform.position;

            if (vectLength.sqrMagnitude < _target && _player.GetComponent<PlayerMadness>().CurrentMadness > _nbMadness)
            {
                Debug.DrawRay(transform.position, vectLength, Color.black);

                if (!Physics.Linecast(transform.position, _player.transform.position, _layerMask))
                {
                    //_text.SetActive(true);
                    _animator.SetBool("IsPatrol", false);
                    _animator.SetBool("IsDetected", true);
                    _eye.ChangeState(2);
                    _currentState = State.Detected;

                }

            }
            if (vectLength.sqrMagnitude > _target + 60)
            {
                _animator.SetBool("IsPatrol", false);
                _animator.SetBool("IsIdle", true);
                _eye.ChangeState(0);
                _currentState = State.Sleep;
            }
        }

        void Detected()
        {
            Vector3 vect = _player.transform.position - transform.position;
            Vector3 vectNormalize = vect.normalized;
            transform.position += vectNormalize * Time.deltaTime * _speed;
            Vector3 direction = vect;
            direction.y = 0;
            Quaternion targetRotation = Quaternion.LookRotation(-direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime);

            if (vect.sqrMagnitude > _target + 40)
            {
                //_text.SetActive(false);
                _animator.SetBool("IsDetected", false);
                _animator.SetBool("IsPatrol", true);
                _eye.ChangeState(1);

                _currentState = State.Patrol;
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                _animator.SetBool("IsDetected", false);
                _animator.SetBool("IsAtrapped", true);
                SceneManager.LoadScene("Prison");
                GameOver.text = "GameOver";
            }
        }

    }

}
