using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HoverMoveInfo : MonoBehaviour
{
    public List<GameObject> toolTips;
    public List<GameObject> toolTipsPanel;
    

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


    private void Update()
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
                if(result.gameObject == toolTips[0])
                {
                    CheckActivity(toolTipsPanel[0]);
                }
                if (result.gameObject == toolTips[1])
                {
                    CheckActivity(toolTipsPanel[1]);
                }
                if (result.gameObject == toolTips[2])
                {
                    CheckActivity(toolTipsPanel[2]);
                }
                if (result.gameObject == toolTips[3])
                {
                    CheckActivity(toolTipsPanel[3]);
                }
                if (result.gameObject == toolTips[4])
                {
                    CheckActivity(toolTipsPanel[4]);
                }
                if (result.gameObject == toolTips[5])
                {
                    CheckActivity(toolTipsPanel[5]);
                }

            }
        }
    }
}
