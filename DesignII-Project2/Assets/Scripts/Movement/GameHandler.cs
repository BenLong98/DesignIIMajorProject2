﻿using Assets.HeroEditor.Common.CharacterScripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameHandler : MonoBehaviour {

    //Speed
    [SerializeField] float speed = 1f;

    //Current Level
    public int level = 0;

    //Current State of Menu
    public int menuCounter = 0;

    //Graphic Raycast Elements
    [SerializeField] GraphicRaycaster m_Raycaster;
    PointerEventData m_PointerEventData;
    [SerializeField] EventSystem m_EventSystem;

    //Player Reference
    public GameObject player;

    //Lerping info
    private float startTime;
    private float journeyLength;

    [SerializeField] GameObject currentTarget;
    [SerializeField] GameObject[] allWayPoints;

    [SerializeField] GameObject customizePanel;
    [SerializeField] Transform childObj;
    [SerializeField] GameObject camContents;
    [SerializeField] GameObject gearMain;
    [SerializeField] GameObject titleText;
    public GameObject uiController;

    [SerializeField] GameObject creditsPanel;
    [SerializeField] GameObject helpPanel;


    public bool isInMenu = true;
    public bool doneCreating = false;


    [SerializeField] Vector3 _originalPosition;

    public bool[] canGoTo = new bool[3];

    /// <summary>
    /// Don't destroy when loading scenes
    /// </summary>
    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        customizePanel = GameObject.FindGameObjectWithTag("CustomCharacter");
        gearMain = GameObject.FindGameObjectWithTag("GearMain");
        titleText = GameObject.FindGameObjectWithTag("TitleText");

        for (int i = 0; i < canGoTo.Length - 1; i++) {
            canGoTo[i] = false;
        }

        canGoTo[0] = true;

    }

    /// <summary>
    /// This is to handle the raycasting of the movement of the player based on a waypoint system
    /// </summary>
    void Update () {

        if (isInMenu)
        {
            

            m_EventSystem = GameObject.FindGameObjectWithTag("EventSystemMain").GetComponent<EventSystem>();
            m_Raycaster = GameObject.FindGameObjectWithTag("CanvasMain").GetComponent<GraphicRaycaster>();
            player.SetActive(true);
      

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            m_PointerEventData = new PointerEventData(m_EventSystem);
            m_PointerEventData.position = Input.mousePosition;

            //Create a list of Raycast Results
            List<RaycastResult> results = new List<RaycastResult>();
            m_Raycaster.Raycast(m_PointerEventData, results);

            foreach (RaycastResult result in results)
            {
                if (result.gameObject.transform.tag == "WayPoint") {
                    if (canGoTo[result.gameObject.GetComponent<WayPoint>().GetLevel() - 1] == true) {

                        Debug.Log("Hit " + result.gameObject.name);
                        currentTarget = result.gameObject;
                        StartCoroutine(WaitAndMove(0.05f, result.gameObject.transform.position));
                    }
                   
                }
                
            }
        }

        }
        else
        {
            m_EventSystem = null;
            m_Raycaster = null;
            player.SetActive(false);
        }
    }

    /// <summary>
    /// This function waits and moves...lerping the animation to the desired position.
    /// </summary>
    /// <param name="delayTime"></param>
    /// <param name="pos"></param>
    /// <returns></returns>
    IEnumerator WaitAndMove(float delayTime, Vector3 pos)
    {
        yield return new WaitForSeconds(delayTime);
        float startTime = Time.time; 
        while (Time.time - startTime <= 2)
        {
            player.GetComponent<Character>().Animator.SetBool("Movement", true);
            player.transform.position = Vector3.Lerp(player.transform.position, pos, (Time.time - startTime) * 0.1f);
            yield return 1; 
        }
        player.GetComponent<Character>().Animator.SetBool("Movement", false);
        yield return new WaitForSeconds(0.1f);

        OpenPlayDialog();

    }




    private void OpenPlayDialog() {
        if (level >= currentTarget.GetComponent<WayPoint>().GetLevel() - 1)
        {
            //Clear all play options
            for (int i = 0; i < allWayPoints.Length; i++) {
                allWayPoints[i].GetComponent<WayPoint>().SetPlayOption(false);
            }
            //Set play option on.
            currentTarget.GetComponent<WayPoint>().SetPlayOption(true);
        }
        
       
    }


    public void CheckMenus() {
        customizePanel = GameObject.FindGameObjectWithTag("CustomCharacter");
        childObj = customizePanel.transform.Find("Contents");

        if (menuCounter % 2 == 0)
        {
            if (doneCreating)
            {
                childObj.gameObject.SetActive(false);
                customizePanel.GetComponent<Image>().enabled = false;
            }
            else {
                childObj.gameObject.SetActive(true);
                customizePanel.GetComponent<Image>().enabled = true;
            }
            
            camContents.SetActive(true);
            gearMain.SetActive(true);
            titleText.SetActive(true);
            uiController.SetActive(true); 
        }
        else
        {
            uiController.SetActive(false);
            titleText.SetActive(false);
            camContents.SetActive(false);
            gearMain.SetActive(false);
            customizePanel.GetComponent<Image>().enabled = false;
            childObj.gameObject.SetActive(false);
        }
    }

    //Button Handlers


    public void DisplayCredits()
    {
        isInMenu = false;
        creditsPanel.SetActive(true);
    }
    public void HideCredits()
    {
        isInMenu = true;
        creditsPanel.SetActive(false);
    }

    public void DisplayHelp()
    {
        isInMenu = false;
        helpPanel.SetActive(true);
    }
    public void HideHelp()
    {
        isInMenu = true;
        helpPanel.SetActive(false);
    }

    public void MoveToFrame()
    {


        isInMenu = true;
        _originalPosition = player.transform.position;
        player.transform.position = new Vector3(-7.17f, 3.93f, 0);
        player.transform.localScale = new Vector3(.8f, .8f, .8f);
    }

    public void MoveToOriginalPosition()
    {
        isInMenu = true;
        player.transform.position = _originalPosition;
        player.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
    }
}
