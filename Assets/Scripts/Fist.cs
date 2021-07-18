using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fist : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        //TODO: Eventually put exploding animations instead
        if (other.tag == "Sentence") Destroy(other.gameObject);
    }
}