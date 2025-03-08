using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Lifeness
{
    public class CollegueScript : MonoBehaviour
    {
        //public GameObject player; // mettre en place la detection de est ce que le joueur est viré

        GameObject _canvaText;
        GameObject _canvaQuest;
        TMP_Text Feedback;

        int timer;

        public GameObject _box;
        private enum State { Idle, Talking}
        private State _currentState;

        private List<string> _dialogue = new List<string>();
        private int _dialogueIndex;

        // Start is called before the first frame update
        void Start()
        {
            _canvaText = GameObject.Find("Dialog");
            _canvaQuest = GameObject.Find("Quest");
            Feedback = GameObject.Find("TakeFeedBack").GetComponent<TMP_Text>();

            _box.gameObject.SetActive(false);

            timer = 25;

            _currentState = State.Idle;
            _dialogueIndex = 0;

            _dialogue.Add("Votre Collegue : Hey Julien, ça va ? ");
            _dialogue.Add("Vous : Oh salut, bah ecoute ça va pas super,\n je viens de me faire virer");
            _dialogue.Add("Votre Collegue  : Oui j'en ai entendu parler ");
            _dialogue.Add("Vous : Je sais vraiment pas ce que je vais faire,\n je dois payer mon loyer demain");
            _dialogue.Add("Votre Collegue  : Ah alors j'ai peut être quelque chose qui \n pourrait t'interesser");
            _dialogue.Add("Vous : Quoi ! Vraiment , dis moi !");
            _dialogue.Add("Votre Collegue  : J'aurai besoin que tu me donne un petit \n coup de main ... en echange d'argent biensur");
            _dialogue.Add("Vous : J'accepte qu'est ce que je dois faire ?");
            _dialogue.Add("Votre Collegue  : Parfais, Dany , une de mes connaisances \n a besoin d'aide et vite");
            _dialogue.Add("Votre Collegue  : Il m'a appelé pour me dire qu'une personne \n le suivait dans une petite allée non loin de là");
            _dialogue.Add("Votre Collegue  : avec sa géolocalisation snap \n j'ai pu voir que cette allée est accessible \n grâce a la rue derriere moi ");
            _dialogue.Add("Votre Collegue  : Dépêche toi ");

            _dialogue.Add("Votre Collegue : Ah te revoila, mais .... ou est dany ?");
            _dialogue.Add("Vous : Je .... Je suis desolé");
            _dialogue.Add("Vous : Quand je suis arrivé il était deja trop tard");
            _dialogue.Add("Votre Collegue : QUOI !!!");
            _dialogue.Add("Vous : Mais ne t'inquiète pas il est pas parti tout seul");
            _dialogue.Add("Votre Collegue : Euh ca va ? J'ai l'impression que tu perds la tête");
            _dialogue.Add("Votre Collegue : Si tu veux pouvoir te calmer, \n il faut que tu trouve de quoi te changer les idées \n comme de l'alcool");
            _dialogue.Add("Votre Collegue : Il y a un magasin derriere ton anciens job qui refais son stock");
            _dialogue.Add("Votre Collegue : Tu peux donc aller en chercher une la bas");

        }

        // Update is called once per frame
        void Update()
        {
            switch (_currentState)
            {
                case State.Idle:
                    Idle();
                    break;
                case State.Talking:
                    Talking();
                    break;
            }
        }

        void Idle()
        {

        }

        void Talking()
        {
            Feedback.text = "Appuyer sur ESPACE pour passer le texte";
            _canvaText.GetComponent<TextMeshProUGUI>().text = _dialogue[_dialogueIndex];
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _dialogueIndex++;
                if (_dialogueIndex >= _dialogue.Count)
                {
                    _canvaQuest.GetComponent<TextMeshProUGUI>().text = "Aller prendre de l'alcool au magasin";
                    _box.gameObject.SetActive(true);
                    _currentState = State.Idle;
                }
                if(_dialogueIndex == 12)
                {
                    _canvaQuest.GetComponent<TextMeshProUGUI>().text = " Quest : \n Sauver Dany \n" + timer.ToString() ;
                    _dialogueIndex++;
                    StartCoroutine(HideMessageAfterDelay());
                    _currentState = State.Idle;
                }
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                _currentState = State.Talking;
            }
        }

        IEnumerator HideMessageAfterDelay()
        {
            yield return new WaitForSeconds(1f);
            if (timer - 1 < 0) yield break ;
            timer = timer - 1 ;
            _canvaQuest.GetComponent<TextMeshProUGUI>().text = " Quest : \n Sauver Dany \n " + timer.ToString();
            StartCoroutine(HideMessageAfterDelay());
        }
    }
}
