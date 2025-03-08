using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lifeness
{
    public class PlayerDetection : MonoBehaviour
    {
        [SerializeField] int maxPctEye;
        int currentPctEye;
        [SerializeField] Eye eye;
        void Start()
        {
            currentPctEye = 0;
            eye.SetPctEye(currentPctEye);
        }
        void Update()
        {
            if(Input.GetKeyDown(KeyCode.P)){
                ChangePctEye(10);
            }
            else if(Input.GetKeyDown(KeyCode.L)){
                ChangePctEye(-10);
            }
        }
        void ChangePctEye(int pctEye){
            currentPctEye += pctEye;
            if(currentPctEye > maxPctEye || currentPctEye < 0){
                currentPctEye -= pctEye;
            }
            eye.SetPctEye(currentPctEye);
        }
    }
}
