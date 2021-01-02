using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Questions;
using Story;

namespace Rendering
{
    public class Renderers : MonoBehaviour
    {
        Dictionary<string, string> characterToRendererMap;

        void Awake()
        {
            characterToRendererMap = new Dictionary<string, string>();
            characterToRendererMap.Add("farmer", "farmerRenderer");
            characterToRendererMap.Add("troll", "trollRenderer");
            characterToRendererMap.Add("wizard", "wizardRenderer");
            characterToRendererMap.Add("ogre", "ogreRenderer");
        }

        public void displayUsingCorrectRenderer(Question question, StoryElement element)
        {
            string displayRenderer = characterToRendererMap[element.Character];
            if (displayRenderer.Equals("farmerRenderer"))
            {
                Camera.main.GetComponent<FarmerRenderer>().display(
                question, element);
            }
            if (displayRenderer.Equals("trollRenderer"))
            {
                Camera.main.GetComponent<TrollRenderer>().display(
                question, element);
            }
            if (displayRenderer.Equals("wizardRenderer"))
            {
                Camera.main.GetComponent<WizardRenderer>().display(
                question, element);
            }
            if (displayRenderer.Equals("ogreRenderer"))
            {
                Camera.main.GetComponent<OgreRenderer>().display(
                question, element);
            }
        }
    }
}
