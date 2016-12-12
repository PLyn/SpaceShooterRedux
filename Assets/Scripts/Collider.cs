using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collider : MonoBehaviour {


    void OnCollisionEnter(Collision col)
    {
        Debug.Log("I'm working!");
    }
}
