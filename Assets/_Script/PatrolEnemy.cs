using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lifeness
{
    public class PatrolEnemy : MonoBehaviour
    {
        [SerializeField] float _time;
        [SerializeField] float _speed;
        float _currentTime;
        float _move;
        // Start is called before the first frame update
        void Start()
        {
            _currentTime = 0;
            _move = 0.1f;
        }

        // Update is called once per frame
        void Update()
        {
            
            _currentTime += Time.deltaTime;
            if ( _currentTime > _time)
            {
                _move = -_move;
                _currentTime = 0;
            }
            
            Vector3 vect = new Vector3(_move, 0f,0f);
            transform.position += vect * Time.deltaTime * _speed;
        }
    }
}
