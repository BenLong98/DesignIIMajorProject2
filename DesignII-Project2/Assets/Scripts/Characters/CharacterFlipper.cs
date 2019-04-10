using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterFlipper : MonoBehaviour {

    public void FlipBack() {
        this.gameObject.transform.localRotation = Quaternion.Euler(0, 180, 0);
    }

    public void FlipFoward()
    {
        this.gameObject.transform.localRotation = Quaternion.Euler(0, 0, 0);
    }
}
