using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CharacterSelection : MonoBehaviour
{
    [Header("HighlightPanels")]
    public GameObject[] spotPanels = new GameObject[6];

    public static bool[] highlightIsActive = new bool[6];

    public bool isActive;
    public bool run;

    [SerializeField] GraphicRaycaster m_Raycaster;
    PointerEventData m_PointerEventData;
    [SerializeField] EventSystem m_EventSystem;

    private void Start()
    {
        Debug.Log("isActive is " + isActive + " at Start");
    }

    void CheckActivity(GameObject panel)
    {
        if (panel.activeSelf == true)
        {
            Debug.Log("isActive is " + isActive + " at CheckActivity");
            isActive = false;
        }
        else
        {
            isActive = true;
        }
    }

    void OnClick(GameObject panel, int number, bool activity)
    {
        CheckActivity(spotPanels[number]);
        if (isActive == true)
        {
            Debug.Log("isActive is " + isActive + " at OnClick");
            PlayerPartyController.instance.AddCharacter(number);
            if (PlayerPartyController.notAcceptable == true)
            {
                PlayerPartyController.notAcceptable = false;
                Debug.Log("notAcceptable was true");
            }
            else if (PlayerPartyController.notAcceptable == false)
            {
                activity = true;
                highlightIsActive[number] = activity;
                Debug.Log(activity);
            }
        }
        if (isActive == false)
        {
            PlayerPartyController.instance.RemoveCharacter(number);
            activity = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            m_PointerEventData = new PointerEventData(m_EventSystem);
            m_PointerEventData.position = Input.mousePosition;

            //Create a list of Raycast Results
            List<RaycastResult> results = new List<RaycastResult>();

            m_Raycaster.Raycast(m_PointerEventData, results);

            foreach (RaycastResult result in results)
            {
                if (result.gameObject.transform.tag == "Spot1")
                {
                    OnClick(spotPanels[0], 0, highlightIsActive[0]);
                }
                if (result.gameObject.transform.tag == "Spot2")
                {
                    OnClick(spotPanels[1], 1, highlightIsActive[1]);
                }
                if (result.gameObject.transform.tag == "Spot3")
                {
                    OnClick(spotPanels[2], 2, highlightIsActive[2]);
                }
                if (result.gameObject.transform.tag == "Spot4")
                {
                    OnClick(spotPanels[3], 3, highlightIsActive[3]);
                }
                if (result.gameObject.transform.tag == "Spot5")
                {
                    OnClick(spotPanels[4], 4, highlightIsActive[4]);
                }
                if (result.gameObject.transform.tag == "Spot6")
                {
                    OnClick(spotPanels[5], 5, highlightIsActive[5]);
                }

            }
        }

        for (int x = 0; x < highlightIsActive.Length; x++)
        {
            if (highlightIsActive[x] == true)
            {
                spotPanels[x].SetActive(true);
            }
            else
            {
                spotPanels[x].SetActive(false);
            }
        }

    }
}
