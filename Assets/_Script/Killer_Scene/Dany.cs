using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.VFX;

namespace Lifeness
{
    public class Dany : MonoBehaviour
    {
        [SerializeField] Animator _DanyAnimator;
        [SerializeField] VisualEffect _visualEffect;
        [SerializeField] TriggerArea _triggerArea;
        [SerializeField] MeshRenderer _meshRenderer;

        GameObject _canvaQuest;
        PlayerMadness playerMadness;
        float timeSinceAnimationStarted;
        bool _playAnimation =false;

        void Start()
        {
            playerMadness = GameObject.Find("Walking 1").GetComponent<PlayerMadness>();

            _canvaQuest = GameObject.Find("Quest");
        }

        void Update()
        {
            float currentTime = Time.time - timeSinceAnimationStarted;

            setAnimationTrue(currentTime);
            setAnimationFalse(currentTime);
           
            //_visualEffect.enabled = _playAnimation ? true : false;

            if (_playAnimation)
            {
                _visualEffect.enabled = true;
            }
            else
            {
                _visualEffect.enabled = false;
            }

            if (currentTime >= 4.0f && _triggerArea.IsTrigger)
            {
                playerMadness.ChangeMadness(100);
            }
        }

        public void startAnimation()
        {
            //_visualEffect.Stop();
            _DanyAnimator.Play("idle");
            timeSinceAnimationStarted = Time.time;
        }

        void setAnimationTrue(float currentTime)
        {
            if(currentTime >=1.0f && currentTime <=3.0f && _triggerArea.IsTrigger)
            {
                _playAnimation = true;
                _canvaQuest.GetComponent<TextMeshProUGUI>().text = "Ramasser le couteau";
            }
        }
        
        void setAnimationFalse(float currentTime)
        {
            if (currentTime >= 2.6f && _triggerArea.IsTrigger)
            {
                _playAnimation = false;
                _meshRenderer.enabled = true;

            }
        }
    }
}
