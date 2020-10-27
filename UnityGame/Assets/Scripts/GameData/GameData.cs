using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using state;

namespace Gamedata
{
    [System.Serializable]
    public class GameData
    {
        History hist;

        public GameData(History history)
        {
            this.hist = history;
        }

        public History history
        {
            get { return hist; }
        }
    }
}
