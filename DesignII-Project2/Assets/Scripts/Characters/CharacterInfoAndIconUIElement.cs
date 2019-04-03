using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterInfoAndIconUIElement : MonoBehaviour
{
    private Image characterImage;
    public static string iconName;
    public Text classNameText;
    public List<Sprite> characterIcons;
    public static Sprite characterIcon;

	void Start ()
    {
        characterImage = this.GetComponent<Image>();
        //characterIcon = characterIcons[0];
        characterImage.sprite = characterIcon;
    }

    private void CheckIconName()
    {
        if(iconName == "Barbarian")
        {
            characterIcon = characterIcons[0];
        }
        if (iconName == "Cleric")
        {
            characterIcon = characterIcons[1];
        }
        if (iconName == "Knight")
        {
            characterIcon = characterIcons[2];
        }
        if (iconName == "Ranger")
        {
            characterIcon = characterIcons[3];
        }
        if (iconName == "Rogue")
        {
            characterIcon = characterIcons[4];
        }
        if (iconName == "Wizard")
        {
            characterIcon = characterIcons[5];
        }
        if (iconName == "Goblin")
        {
            characterIcon = characterIcons[6];
        }
        if (iconName == "Orc")
        {
            characterIcon = characterIcons[7];
        }
        if (iconName == "Sorcerer")
        {
            characterIcon = characterIcons[8];
        }
    }
	
	void Update ()
    {
        CheckIconName();
        characterImage.sprite = characterIcon;
        classNameText.text = iconName;
	}
}
