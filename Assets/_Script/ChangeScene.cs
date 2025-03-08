using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Lifeness
{
    public class ChangeScene : MonoBehaviour
    {
        [SerializeField] string _scene;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
        
        }

        private void OnTriggerEnter(UnityEngine.Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                if(_scene == "Office")
                {
                    if(other.gameObject.GetComponent<StateGame>().IsFired == false)
                    {
                        SceneManager.LoadScene(_scene);
                    }
                }
                else
                {
                    SceneManager.LoadScene(_scene);
                }
                
            }
        }
    }
}
