using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lifeness
{
    public class Settings : MonoBehaviour
    {
        public GameObject settingWindow;
        public void SetFullScreen(bool isFullScreen)
        {
            Screen.fullScreen = isFullScreen;
        }
        public void Quit()
        {
            settingWindow.SetActive(false);
        }
    }
}
