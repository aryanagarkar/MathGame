using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace Screens
{
    public class InputScreen : MonoBehaviour
    {
        [SerializeField]
        GameObject DirectionCanvasPrefab;


        [SerializeField]
        InputField GameNameInput;

        [SerializeField]
        InputField CharacterInput;

        string gameName;
        string character;

        void Start()
        {
            GameNameInput.GetComponent<InputField>().onEndEdit.AddListener(delegate { saveName(); });
            CharacterInput.GetComponent<InputField>().onEndEdit.AddListener(delegate { saveCharacter(); });
        }


        void Update()
        {

        }

        public void saveName()
        {
            gameName = GameNameInput.text;
        }
        public void saveCharacter()
        {
            character = CharacterInput.text;
        }

        public void handleNextButtonClickedEvent()
        {
            Destroy(GameObject.FindWithTag("InputCanvas"));
            GameObject.Instantiate(DirectionCanvasPrefab);
            string directions = "";
            if(character.ToLower().Equals("princess")){
                directions = "You just recieve a notice that your brother, "
                            + "the prince of your kingdom, has been locked in a tower. " 
                            + "You decide to journey to the tower to save your brother.";
            }
            if(character.ToLower().Equals("Prince")){
                directions = "You just recieve a notice that your sister, "
                            + "the princess of your kingdom, has been locked in a tower. " 
                            + "You decide to journey to the tower to save your sister.";
            }
            DirectionCanvasPrefab.transform.GetChild(0).gameObject.GetComponent<Text>().text = directions;
        }
    }
}
