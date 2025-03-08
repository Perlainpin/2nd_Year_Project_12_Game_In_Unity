using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Lifeness
{
    public class Dialogue : MonoBehaviour
    {
        TMP_Text textMeshPro;
        [SerializeField] string textToWrite;
        bool isDialogue;

        private void Start()
        {
            textMeshPro = GameObject.Find("Dialog").GetComponent<TMP_Text>();
            
        }
        public bool IsDialogue { get => isDialogue; set => isDialogue = value; }

        void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.tag == "Player") {
                textMeshPro.text = textToWrite;
                IsDialogue = true;
            }
            
        }

        void OnCollisionExit(Collision collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                textMeshPro.text = "";
            }

        }
    }
}
