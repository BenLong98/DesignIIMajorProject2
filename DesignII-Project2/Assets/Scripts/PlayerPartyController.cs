using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPartyController : MonoBehaviour {

    [SerializeField] private List<GenericPlayerChar> _characters = new List<GenericPlayerChar>();
    private List<GenericPlayerChar> _party = new List<GenericPlayerChar>();

    public List<GenericPlayerChar> party
    {
        get { return _party; }
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
