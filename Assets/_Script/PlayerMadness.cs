using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lifeness
{
    public class PlayerMadness : MonoBehaviour
    {
        [SerializeField] int maxMadness;
        [SerializeField] int currentMadness;
        [SerializeField] madnessBar madnessBar;

        public int CurrentMadness { get => currentMadness; set => currentMadness = value; }

        void Start()
        {
            // currentMadness = maxMadness;
            madnessBar.SetMaxMadness(maxMadness);
            madnessBar.SetMadness(CurrentMadness);
        }
        void Update()
        {
            if(Input.GetKeyDown(KeyCode.H)){
                ChangeMadness(10);
            }
            else if(Input.GetKeyDown(KeyCode.J)){
                ChangeMadness(-10);
            }
        }

        public void ChangeMadness(int madness){
            CurrentMadness += madness;
            if(CurrentMadness > maxMadness || CurrentMadness < 0){
                CurrentMadness -= madness;
            }
            madnessBar.SetMadness(CurrentMadness);
        }
    }
}
