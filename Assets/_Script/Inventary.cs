using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using System.Linq;
using NUnit.Framework.Constraints;
using UnityEngine.SceneManagement;

namespace Lifeness
{
    public class Inventary : MonoBehaviour
    {
        public Dictionary<int, Item> items = new Dictionary<int, Item>();
        public GameObject[] UIItems;
        public PlayerMadness playerMadness;
        public TMP_Text TakeFeedBack;

        public void ConsumeFirstItem(InputAction.CallbackContext ctx) {
            if(!ctx.performed) return;
            ConsumeItem(0);
        }
        public void ConsumeSecondItem(InputAction.CallbackContext ctx) {
            if(!ctx.performed) return;
            ConsumeItem(1);
        }
        public void ConsumeThirdItem(InputAction.CallbackContext ctx) {
            if(!ctx.performed) return;
            ConsumeItem(2);
        }
        public void ConsumeFourthItem(InputAction.CallbackContext ctx) {
            if(!ctx.performed) return;
            ConsumeItem(3);
        }

        private void ConsumeItem(int index){
            if(items.ContainsKey(index)){
                playerMadness.ChangeMadness(items[index].madnessGiven);
                UpdateInventary(index, true);
                items.Remove(index);
            }
        }
        public void UpdateInventary(int index, bool remove = false){
            if(remove){
                UIItems[index].GetComponentInChildren<Image>().sprite = null;
                UIItems[index].GetComponentInChildren<TMP_Text>().text = "";
            }else{
                UIItems[index].GetComponentInChildren<Image>().sprite = items[index].image;
                UIItems[index].GetComponentInChildren<TMP_Text>().text = items[index].name;
            }
        }      

        public void AddItem(Item item){
            if(items.Count != 4){
                items.Add(items.Count, item);
                UpdateInventary(items.Count - 1);
                TakeFeedBack.text = "Vous avez ramassé un " + item.name;
                StartCoroutine(HideMessageAfterDelay());
            }
        }

        IEnumerator HideMessageAfterDelay()
        {
            yield return new WaitForSeconds(1f);
            TakeFeedBack.text = "";
        }

    }
}
