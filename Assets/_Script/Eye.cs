using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Lifeness
{
    public class Eye : MonoBehaviour
    {
        [SerializeField] Image img;
        enum State { IsInvisible, IsResearch, IsDetected};
        State _currentState;

        

        void Start ()
        {
            _currentState = State.IsInvisible;
        }
        void Update () { 
            switch (_currentState) 
            { 
                case State.IsInvisible:
                    SetPctEye(0);
                    break;
                case State.IsResearch:
                    SetPctEye(50);
                    break;
                case State.IsDetected:
                    SetPctEye(100);
                    break;

            }
        }

        public void SetPctEye(int pct){
            img.color = new Color(img.color.r, img.color.g, img.color.b, pct / 100f);
        }

        public void ChangeState(int state)
        {
            switch (state)
            {
                case 0:
                    _currentState = State.IsInvisible;
                    break;
                case 1:
                    _currentState = State.IsResearch;
                    break;
                case 2:
                    _currentState = State.IsDetected;
                    break;
            }
        }
    }
}
