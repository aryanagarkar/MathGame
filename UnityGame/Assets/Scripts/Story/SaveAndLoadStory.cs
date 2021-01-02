using System;
using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Json;
using System.IO;

namespace Story
{
    public static class SaveAndLoadStory
    {
        public static Graph loadStory(String path)
        {
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Graph));
            //FileStream stream = File.Open(path, FileMode.Open);
            //StreamReader streamReader = new StreamReader(path);
            FileStream fs = new FileStream(path, FileMode.Open);
            //stream.Position = 0;
            //stream.
           // String line = streamReader.ReadToEnd();
            Graph graph = ser.ReadObject(fs) as Graph;
            fs.Close();
            // String jsonString = File.ReadAllText(path);
            // Graph graph = JsonUtility.FromJson<Graph>(jsonString);

            return graph;
        }
    }
}
