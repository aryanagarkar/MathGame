using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveAndLoadSystem
{
    public static void saveData(History history){  
        BinaryFormatter formatter = new BinaryFormatter();
        string path = "/tmp/GameData.data";

        if(File.Exists(path)){
            File.Delete(path);
        }

        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, history);
        stream.Close();
    }

    public static History loadData(){
        string path = "/tmp/GameData.data";

        if(File.Exists(path)){
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            History data = formatter.Deserialize(stream) as History;
            stream.Close();

            return data;
        }
        else{
            return new History();
        }
    }
}