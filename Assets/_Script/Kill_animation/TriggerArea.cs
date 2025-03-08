using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lifeness
{
    public class TriggerArea : MonoBehaviour
    {
        [SerializeField] Animator _knifeAnimator;
        [SerializeField] Dany _dany;
        bool _isTrigger = false;

        public bool IsTrigger { get => _isTrigger; }

        private void OnTriggerEnter(Collider collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                if(!_isTrigger)
                {
                    _knifeAnimator.Play("knifing");
                    _dany.startAnimation();
                    _isTrigger = true;
                }
                
            }
        }
        
}
}
