using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Lifeness
{
    public class madnessBar : MonoBehaviour
    {
        // Start is called before the first frame upd
        public Slider slider;

        public void SetMaxMadness(int madness){
            slider.maxValue = madness;
            slider.value = 0;
        }

        public void SetMadness(int madness){
            slider.value = madness;
        }
        void Start()
        {
        
        }
        void Update()
        {
        
        }
    }
}
