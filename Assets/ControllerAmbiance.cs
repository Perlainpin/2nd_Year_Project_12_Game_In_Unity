using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lifeness
{
    public class ControllerAmbiance : MonoBehaviour
    {
        [SerializeField] ParticleSystem systemeParticules;
        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            GameObject player = GameObject.Find("Walking 1");
            if (player.GetComponent<StateGame>().IsFired == true)
            {
                systemeParticules.Play();
            }
            else
            {
                systemeParticules.Pause();
            }
            
        }
    }
}
