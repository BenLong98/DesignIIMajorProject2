using Assets.HeroEditor.Common.CharacterScripts;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class CustomizableCharacter : MonoBehaviour {

    public Sprite[] helmPickable;
    public Sprite[] headPickable;
    public Sprite[] bodyPickable;
    public Sprite[] legsPickable;
    public Sprite[] weaponPickable;

    [SerializeField] int helmCount = 0;
    [SerializeField] int headCount = 0;
    [SerializeField] int bodyCount = 0;
    [SerializeField] int legsCount = 0;
    [SerializeField] int weaponCount = 0;

    [SerializeField] Text helmText;
    [SerializeField] Text headText;
    [SerializeField] Text bodyText;
    [SerializeField] Text legsText;
    [SerializeField] Text weaponText;


    [SerializeField] SpriteRenderer helmRenderer;
    [SerializeField] SpriteRenderer headRenderer;
    [SerializeField] SpriteRenderer bodyRenderer;
    [SerializeField] SpriteRenderer legsRenderer;
    [SerializeField] SpriteRenderer weaponRenderer;

    [SerializeField] GameObject player;

    [SerializeField] GameObject characterCustomizePanel;


    public void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void Update()
    {
        helmText.text = "Helmet: " + helmCount;
        headText.text = "Hair: " + headCount;
        bodyText.text = "Body: " + bodyCount;
        legsText.text = "Legs: " + legsCount;
        weaponText.text = "Weapons: " + weaponCount;
    }


    // Helm, Head, Body, Legs, Weapon

    public void ClickedHelmUp() {
 
        helmCount++;

        if (helmCount > helmPickable.Length - 1)
        {
            helmCount = 0;
            player.GetComponent<Character>().HelmetRenderer.sprite = player.GetComponent<CustomizableCharacter>().helmPickable[helmCount];
        }else {
            player.GetComponent<Character>().HelmetRenderer.sprite = player.GetComponent<CustomizableCharacter>().helmPickable[helmCount];
        }  
    }
    public void ClickedHelmDown()
    {
        helmCount--;

        if (helmCount < 0){
            helmCount = helmPickable.Length - 1;
            player.GetComponent<Character>().HelmetRenderer.sprite = helmPickable[helmCount];
        }else{
            player.GetComponent<Character>().HelmetRenderer.sprite = helmPickable[helmCount];
        }
    }

    // Helm, Head, Body, Legs, Weapon

    public void ClickedHeadUp()
    {
        headCount++;

        if (headCount > headPickable.Length - 1)
        {
            headCount = 0;
            player.GetComponent<Character>().HairRenderer.sprite = headPickable[headCount];
        } else{ 
            player.GetComponent<Character>().HairRenderer.sprite = headPickable[headCount];
        }
    }
    public void ClickedHeadDown()
    {
        headCount--;

        if (headCount < 0){
            headCount = headPickable.Length - 1;
            player.GetComponent<Character>().HairRenderer.sprite = headPickable[headCount];
        }else{
            player.GetComponent<Character>().HairRenderer.sprite = headPickable[headCount];
        }
    }


    // Helm, Head, Body, Legs, Weapon 25

    public void ClickedBodyUp()
    {
        bodyCount++;

        if (bodyCount > bodyPickable.Length - 1)
        {
            bodyCount = 0;
            player.GetComponent<Character>().ArmorRenderers[25].sprite = bodyPickable[bodyCount];
        }else{
            player.GetComponent<Character>().ArmorRenderers[25].sprite = bodyPickable[bodyCount];
        }
    }
    public void ClickedBodyDown()
    {
        bodyCount--;

        if (bodyCount < 0){
            bodyCount = bodyPickable.Length - 1;
            player.GetComponent<Character>().ArmorRenderers[25].sprite = bodyPickable[bodyCount];
        }else{
            
            player.GetComponent<Character>().ArmorRenderers[25].sprite = bodyPickable[bodyCount];
        }
    }


    // Helm, Head, Body, Legs, Weapon

    public void ClickedLegsUp()
    {
        legsCount++;

        if (legsCount > legsPickable.Length - 1)
        {
            legsCount = 0;
            player.GetComponent<Character>().ArmorRenderers[20].sprite = legsPickable[legsCount];
        }
        else {
            player.GetComponent<Character>().ArmorRenderers[20].sprite = legsPickable[legsCount];
        }
    }
    public void ClickedLegsDown()
    {
        legsCount--;

        if (legsCount < 0)
        {
            legsCount = legsPickable.Length - 1;
            player.GetComponent<Character>().ArmorRenderers[20].sprite = legsPickable[legsCount];
        }else{
            player.GetComponent<Character>().ArmorRenderers[20].sprite = legsPickable[legsCount];
        }
    }


    // Helm, Head, Body, Legs, Weapon

    public void ClickedWeaponUp()
    {
        weaponCount++;

        if (weaponCount > weaponPickable.Length - 1)
        {
            weaponCount = 0;
            player.GetComponent<Character>().PrimaryMeleeWeaponRenderer.sprite = weaponPickable[weaponCount];
        }else{
            player.GetComponent<Character>().PrimaryMeleeWeaponRenderer.sprite = weaponPickable[weaponCount];
        }
    }
    public void ClickedWeaponDown()
    {
        weaponCount--;

        if (weaponCount < 0)
        {
            weaponCount = weaponPickable.Length - 1;
            player.GetComponent<Character>().PrimaryMeleeWeaponRenderer.sprite = weaponPickable[weaponCount];
        }else{
            player.GetComponent<Character>().PrimaryMeleeWeaponRenderer.sprite = weaponPickable[weaponCount];
        }
    }



    public void CreateCharacter() {

        characterCustomizePanel.SetActive(false);

        player.gameObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        player.gameObject.transform.localPosition = new Vector3(-4f, -3f, 0);
    }



}
