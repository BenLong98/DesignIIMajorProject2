using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour {

    [SerializeField] int levelNumber;
    [SerializeField] GameObject playOption;

    public int GetLevel() {
        return levelNumber;
    }

    public void SetPlayOption(bool isOn) {
        playOption.SetActive(isOn);
    }


}
