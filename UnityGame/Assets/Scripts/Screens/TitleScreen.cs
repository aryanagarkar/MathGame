using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Screens
{
    public class TitleScreen : MonoBehaviour
    {
        public void handleStartButtonClickedEvent()
        {
            ScreenManager.goToScreen(ScreenNameEnum.UserInputScreen);
        }
    }
}
