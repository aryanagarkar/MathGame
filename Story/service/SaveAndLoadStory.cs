using System;
using System.IO;
using System.Text.Json;

namespace service
{
    public static class SaveAndLoadStory
    {
        public static void saveStory(Graph story, String path)
        {
            if(File.Exists(path)){
                File.Delete(path);
            }
            String jsonString = JsonSerializer.Serialize(story);
            File.WriteAllText(path, jsonString);
        }

        public static Graph loadStory(String path)
        {
            String jsonString = File.ReadAllText(path);
            Graph graph = JsonSerializer.Deserialize<Graph>(jsonString);

            return graph;
        }
    }
}
