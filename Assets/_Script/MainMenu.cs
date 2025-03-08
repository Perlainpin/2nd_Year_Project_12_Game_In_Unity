using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Lifeness
{
    public class MainMenu : MonoBehaviour
    {
        public GameObject settingWindow;
        public void StartGame()
        {
            SceneManager.LoadScene("Home");
        }
        public void Setting()
        {
            settingWindow.SetActive(true);
        }
        public void QuitGame()
        {
            Application.Quit();
        }
    }
}
