using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Lifeness
{
    public class RainController : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            GameObject player = GameObject.Find("Walking 1");
            if (SceneManager.GetActiveScene().name == "Map" && player.GetComponent<StateGame>().IsFired == true)
            {
                GetComponent<AudioSource>().enabled = true;
            }
            else
            {
                GetComponent<AudioSource>().enabled = false;
            }
            


        }
    }
}
