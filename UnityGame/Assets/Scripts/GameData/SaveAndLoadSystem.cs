using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using state;


namespace Gamedata
{
    public static class SaveAndLoadSystem
    {
        public static void saveData(GameData data)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            string path = "/tmp/GameData.data";

            FileStream stream = new FileStream(path, FileMode.Create);

            formatter.Serialize(stream, data);
            stream.Close();
        }

        public static GameData loadData()
        {
            string path = "/tmp/GameData.data";

            if (File.Exists(path))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream stream = new FileStream(path, FileMode.Open);

                GameData data = formatter.Deserialize(stream) as GameData;

                stream.Close();
                return data;
            }
            else
            {
                return new GameData(new History());
            }
        }
    }
}