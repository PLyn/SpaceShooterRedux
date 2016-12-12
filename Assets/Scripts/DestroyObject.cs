using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour {

    void OnTriggerExit2D(Collider2D trigger)
    {
        Destroy(trigger.transform.root.gameObject);
        //Debug.Log("Bullet Killed");
    }
}
