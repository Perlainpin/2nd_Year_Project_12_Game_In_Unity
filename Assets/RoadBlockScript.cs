using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lifeness
{
    public class RoadBlockScript : MonoBehaviour
    {
        public bool WorkIsDone;
        // Start is called before the first frame update
        void Start()
        {
            WorkIsDone = true;
        }

        // Update is called once per frame
        void Update()
        {
            if (WorkIsDone)
            {
                Object.Destroy(gameObject);
            }
        }
    }
}
