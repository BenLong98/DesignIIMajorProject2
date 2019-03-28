using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameHandler : MonoBehaviour {

    //Speed
    [SerializeField] float speed = 1f;

    //Current Level
    [SerializeField] int level = 0;

    //Graphic Raycast Elements
    [SerializeField] GraphicRaycaster m_Raycaster;
    PointerEventData m_PointerEventData;
    [SerializeField] EventSystem m_EventSystem;

    //Player Reference
    [SerializeField] GameObject player;

    //Lerping info
    private float startTime;
    private float journeyLength;

    [SerializeField] GameObject currentTarget;
    [SerializeField] GameObject[] allWayPoints;

    /// <summary>
    /// Don't destroy when loading scenes
    /// </summary>
    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    /// <summary>
    /// This is to handle the raycasting of the movement of the player based on a waypoint system
    /// </summary>
    void Update () {

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
                    if (level == result.gameObject.GetComponent<WayPoint>().GetLevel() - 1) {

                        Debug.Log("Hit " + result.gameObject.name);
                        currentTarget = result.gameObject;
                        StartCoroutine(WaitAndMove(0.05f, result.gameObject.transform.position));
                    }
                   
                }
                
            }
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
            player.transform.position = Vector3.Lerp(player.transform.position, pos, (Time.time - startTime) * 0.1f);
            yield return 1; 
        }
        yield return new WaitForSeconds(0.25f);

        OpenPlayDialog();

    }

    private void OpenPlayDialog() {
        if (level == currentTarget.GetComponent<WayPoint>().GetLevel() - 1)
        {
            //Clear all play options
            for (int i = 0; i < allWayPoints.Length; i++) {
                allWayPoints[i].GetComponent<WayPoint>().SetPlayOption(false);
            }
            //Set play option on.
            currentTarget.GetComponent<WayPoint>().SetPlayOption(true);
        }
        
       
    }

}
