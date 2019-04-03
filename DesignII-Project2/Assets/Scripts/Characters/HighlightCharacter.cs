using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighlightCharacter : MonoBehaviour
{
    private Image highlightImage;
    [SerializeField] Image imagePrefab;
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
        highlightImage = Instantiate(imagePrefab);
        highlightImage.transform.parent = GameObject.Find("Canvas").transform;
        highlightImage.gameObject.transform.position = this.gameObject.transform.position + offset;
        highlightImage.enabled = false;

    }
	
}
