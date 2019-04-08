using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CharacterSelection : MonoBehaviour
{
    [Header("HighlightPanels")]
    public GameObject[] spotPanels = new GameObject[6];

    public GameObject sceneController;

    public static bool[] highlightIsActive = new bool[6];

    public bool isActive;
    public bool run;

    [SerializeField] GraphicRaycaster m_Raycaster;
    PointerEventData m_PointerEventData;
    [SerializeField] EventSystem m_EventSystem;

    [SerializeField] private AudioClip[] _sound;
    [SerializeField] private AudioSource _soundSource;

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
                    _soundSource.clip = _sound[0];
                    _soundSource.Play();
                }
                if (result.gameObject.transform.tag == "Spot2")
                {
                    OnClick(spotPanels[1], 1, highlightIsActive[1]);
                    _soundSource.clip = _sound[1];
                    _soundSource.Play();
                }
                if (result.gameObject.transform.tag == "Spot3")
                {
                    OnClick(spotPanels[2], 2, highlightIsActive[2]);
                    _soundSource.clip = _sound[2];
                    _soundSource.Play();
                }
                if (result.gameObject.transform.tag == "Spot4")
                {
                    OnClick(spotPanels[3], 3, highlightIsActive[3]);
                    _soundSource.clip = _sound[3];
                    _soundSource.Play();
                }
                if (result.gameObject.transform.tag == "Spot5")
                {
                    OnClick(spotPanels[4], 4, highlightIsActive[4]);
                    _soundSource.clip = _sound[4];
                    _soundSource.Play();
                }
                if (result.gameObject.transform.tag == "Spot6")
                {
                    OnClick(spotPanels[5], 5, highlightIsActive[5]);
                    _soundSource.clip = _sound[5];
                    _soundSource.Play();
                }

            }
        }

        if (sceneController.GetComponent<SceneController>().publicCurrentScene == "CharacterSelectionScene")
        {
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
}
