using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Screens
{
    public static class ScreenManager
    {
        public static void goToScreen(ScreenNameEnum name)
        {
            switch (name)
            {
                case ScreenNameEnum.TitleScreen:
                    SceneManager.LoadScene("TitleScreen");
                    break;
                case ScreenNameEnum.UserInputScreen:
                    SceneManager.LoadScene("UserInputScreen");
                    break;
                case ScreenNameEnum.GamePlay:
                    SceneManager.LoadScene("GamePlay");
                    break;
            }
        }
    }
}
