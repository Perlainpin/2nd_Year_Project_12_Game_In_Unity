using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using TMPro;

namespace Lifeness
{
    public class PlayerInteract : MonoBehaviour
    {
        bool canKill = false;

        bool canTake;
        GameObject objectTrigger;
        public Inventary inventary;
        public PlayerMadness playerMadness;
        [SerializeField] Player _player;
        Ennemy _enemy;
        Animator _myEnnemy;
        Animator _myKiller;
        MeshRenderer _knife;
        TMP_Text TakeFeedBack;

        GameObject _canvaQuest;

        public bool CanTake { get => canTake; set => canTake = value; }
        public GameObject ObjectTrigger { get => objectTrigger; set => objectTrigger = value; }


        void Start()
        {
            _knife = GameObject.Find("Battle_Knife").GetComponent<MeshRenderer>();

            _canvaQuest = GameObject.Find("Quest");
        }

        private void OnTriggerEnter(Collider collision)
        {

            if (collision.gameObject.tag == "Ennemi")
            {
                TakeFeedBack.text = "Appuyer sur W pour Tuer";
                canKill = true;
            }
        }

        private void Update()
        {
            if(SceneManager.GetActiveScene().name == "Map")
            {
                _enemy = GameObject.Find("Remy").GetComponent<Ennemy>();
                _myEnnemy = GameObject.Find("Remy").GetComponent<Animator>();
                TakeFeedBack = GameObject.Find("TakeFeedBack").GetComponent<TMP_Text>();
                _myKiller = GameObject.Find("Stabbing").GetComponent<Animator>();
            }
            
        }

        public void Punch(InputAction.CallbackContext context)
        {

            if (!context.performed) return;
            if (_player.playerMadness.CurrentMadness >= 40)
            {
                _player.stateMachine.ChangeState(_player.playerAttackState);

                if (canKill)
                {
                    _canvaQuest.GetComponent<TextMeshProUGUI>().text = "Retourner voir votre collegue";
                    canKill = false;
                    _myEnnemy.SetBool("IsDead", true);
                    _enemy.IsDead = true;
                    _myKiller.Play("Dying");
                    _player.playerMadness.ChangeMadness(5);
                    TakeFeedBack.text = "";
                }
            }
            else
            {
                TakeFeedBack.text = "Vous n'avez pas assez de folie pour frapper";
                StartCoroutine(HideMessageAfterDelay());
            }
        }
        public void Take(InputAction.CallbackContext ctx)
        {

            if (!ctx.performed) return;
            if (CanTake)
            {
                ObjectTrigger.SetActive(false);
                if(ObjectTrigger.name == "knife")
                {
                    _knife.enabled = true;
                    _canvaQuest.GetComponent<TextMeshProUGUI>().text = "Venger Dany";
                }
                else
                {
                    inventary.AddItem(ObjectTrigger.GetComponent<bottle>().item);
                }
            }
        }
               
       

        IEnumerator HideMessageAfterDelay()
        {
            yield return new WaitForSeconds(1f);
            TakeFeedBack.text = "";
        }
    }
}
