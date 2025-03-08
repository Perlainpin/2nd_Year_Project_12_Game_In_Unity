using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Lifeness
{
    public class StateGame : MonoBehaviour
    {
        bool isFired;
        [SerializeField] Material newSkyboxMaterial;

        public bool IsFired { get => isFired; set => isFired = value; }

        // Start is called before the first frame update
        void Start()
        {
            IsFired = false;
        }

        // Update is called once per frame
        void Update()
        {
            
            
            if (IsFired == true && SceneManager.GetActiveScene().name == "Map")
            {
                RenderSettings.skybox = newSkyboxMaterial;
                if(GameObject.Find("Road-Block") != null)
                {
                    GameObject.Find("Road-Block").GetComponent<RoadBlockScript>().enabled = true;
                }
                
                
            }
        }
    }
}
