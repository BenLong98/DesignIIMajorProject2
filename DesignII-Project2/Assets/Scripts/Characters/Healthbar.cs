using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour {

    private GenericPlayerChar _character;
    private Text _healthText;

    // Use this for initialization
    void Start () {
        _character = gameObject.GetComponent<GenericPlayerChar>();
        _healthText.transform.position = transform.position + new Vector3(0, -10, 0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
