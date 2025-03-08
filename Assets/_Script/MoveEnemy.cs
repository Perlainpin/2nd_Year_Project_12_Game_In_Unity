using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Lifeness
{
    public class MoveEnemy : MonoBehaviour
    {
        [SerializeField] GameObject _player;
        [SerializeField] float _speed;
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            Vector3 vect = _player.transform.position - transform.position;
            Vector3 vectNormalize = vect.normalized;
            transform.position += vectNormalize * Time.deltaTime * _speed;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                SceneManager.LoadScene("Prison");
            }
            
            

        }
    }
}
