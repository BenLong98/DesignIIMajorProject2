using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CharacterSelection : MonoBehaviour
{
    [Header("HighlightPanels")]
    public GameObject spot1HPanel;
    public GameObject spot2HPanel;
    public GameObject spot3HPanel;
    public GameObject spot4HPanel;
    public GameObject spot5HPanel;
    public GameObject spot6HPanel;

    [SerializeField] GraphicRaycaster m_Raycaster;
    PointerEventData m_PointerEventData;
    [SerializeField] EventSystem m_EventSystem;


    void CheckActivity(GameObject panel)
    {
        if (panel.activeInHierarchy == true)
        {
            panel.SetActive(false);
        }
        else
        {
            panel.SetActive(true);
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            m_PointerEventData = new PointerEventData(m_EventSystem);
            m_PointerEventData.position = Input.mousePosition;

            //Create a list of Raycast Results
            List<RaycastResult> results = new List<RaycastResult>();
            //Debug.Log(results[0]);
            m_Raycaster.Raycast(m_PointerEventData, results);

            foreach (RaycastResult result in results)
            {
                if (result.gameObject.transform.tag == "Spot1")
                {
                    CheckActivity(spot1HPanel);
                }
                if (result.gameObject.transform.tag == "Spot2")
                {
                    CheckActivity(spot2HPanel);
                }
                if (result.gameObject.transform.tag == "Spot3")
                {
                    CheckActivity(spot3HPanel);
                }
                if (result.gameObject.transform.tag == "Spot4")
                {
                    CheckActivity(spot4HPanel);
                }
                if (result.gameObject.transform.tag == "Spot5")
                {
                    CheckActivity(spot5HPanel);
                }
                if (result.gameObject.transform.tag == "Spot6")
                {
                    CheckActivity(spot6HPanel);
                }

            }
        }
    }
}
