using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighlightCharacter : MonoBehaviour
{
    public Image highlightImage;
    private Vector3 offset;
    private string classStringName;

    private void OnMouseEnter()
    {
        highlightImage.enabled = true;
        highlightImage.gameObject.transform.position = this.gameObject.transform.position + offset;
        CheckClassOfCharacter();
        SetIconBasedOffClass();
    }

    private void OnMouseExit()
    {
        highlightImage.enabled = false;
    }

    private void CheckClassOfCharacter()
    {
        classStringName = this.gameObject.GetComponent<GenericPlayerChar>().classType.ToString();
    }

    private void SetIconBasedOffClass()
    {
          CharacterInfoAndIconUIElement.iconName = classStringName;
    }

    void Start ()
    {
        offset.Set(0, 1, 0);
        highlightImage.gameObject.transform.position = this.gameObject.transform.position + offset;
        highlightImage.enabled = false;

    }
	
}
