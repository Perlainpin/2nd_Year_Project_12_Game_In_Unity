using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Lifeness
{
    public class LooseJob : MonoBehaviour
    {
        // Start is called before the first frame update
        [SerializeField] GameObject boss;
        GameObject _player;
        Dialogue dialogue;
        [SerializeField] Material newSkyboxMaterial;
        [SerializeField] Light lightComponent;

        GameObject _canvaQuest;

        void Start()
        {
            dialogue = boss.GetComponent<Dialogue>();
            _player = GameObject.Find("Walking 1");//GetComponent<StateGame>();

            _canvaQuest = GameObject.Find("Quest");
        }

        // Update is called once per frame
        void Update()
        {
            if(dialogue.IsDialogue == true)
            {
                RenderSettings.skybox = newSkyboxMaterial;
                RenderSettings.fogDensity = 0.2f;
                lightComponent.color = Color.gray;
                _player.GetComponent<StateGame>().IsFired = true;
                _canvaQuest.GetComponent<TextMeshProUGUI>().text = " Quest : \n Trouver un nouveau job";
            }
        }
    }
}
