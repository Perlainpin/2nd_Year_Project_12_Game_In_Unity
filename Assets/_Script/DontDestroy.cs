using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lifeness
{
    public class DontDestroy : MonoBehaviour
    {
        public GameObject[] objects;
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        private void Awake()
        {
            foreach (var obj in objects)
            {
                DontDestroyOnLoad(obj);
            }
        }
    }
}
