using System;
using System.IO;
using UnityEngine;

namespace Story
{
    public static class SaveAndLoadStory
    {
        public static void saveStory(Graph story, String path)
        {
            if(File.Exists(path)){
                File.Delete(path);
            }
            String jsonString = JsonUtility.ToJson(story);
            File.WriteAllText(path, jsonString);
        }

        public static Graph loadStory(String path)
        {
            String jsonString = File.ReadAllText(path);
            Graph graph = JsonUtility.FromJson<Graph>(jsonString);

            return graph;
        }
    }
}
