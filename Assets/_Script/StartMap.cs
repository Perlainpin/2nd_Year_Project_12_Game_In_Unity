using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace Lifeness
{
    public class StartMap : MonoBehaviour
    {
        
        // Start is called before the first frame update

        private void Awake()
        {
            GameObject.Find("Walking 1").transform.position = transform.position;
        }


        // Update is called once per frame
        void Update()
        {
            if (GameObject.Find("Walking 1").transform.position.y < -2)
            {
                GameObject.Find("Walking 1").transform.position = transform.position;
            };
        }


    }

    
    
}
