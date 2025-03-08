using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Lifeness
{
    public class bottle : MonoBehaviour
    {
        PlayerInteract interact;
        TMP_Text Feedback;
        public Item item;

        void Start()
        {
            interact = GameObject.Find("Walking 1").GetComponent<PlayerInteract>();
            Feedback = GameObject.Find("TakeFeedBack").GetComponent<TMP_Text>();
        }

        void OnTriggerEnter(Collider other){
            if (other.gameObject.tag == "Player"){
                interact.CanTake = true;
                interact.ObjectTrigger = this.gameObject;
                Feedback.text = "Appuyé sur E pour ramassé";
            }
        }

        void OnTriggerExit(Collider other){
            if (other.gameObject.tag == "Player"){
                interact.CanTake = false;
                Feedback.text = "";
            }
        }
    }
}
