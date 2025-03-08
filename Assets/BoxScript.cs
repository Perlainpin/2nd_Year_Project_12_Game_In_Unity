using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Lifeness
{
    public class BoxScript : MonoBehaviour
    {

        public GameObject _canvaText;

        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                Object.Destroy(gameObject);
                _canvaText.GetComponent<TextMeshProUGUI>().text = "Vous avez ramaser une caisse d'alcool : +2 bouteille";
            }
        }
    }
}
