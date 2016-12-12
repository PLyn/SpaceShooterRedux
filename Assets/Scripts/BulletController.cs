using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {
    private Rigidbody2D body;
    public bool EnemyBullet = false; 
    // Use this for initialization
    void Start () {
        body = this.GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        if (EnemyBullet)
        {
            body.velocity = new Vector3(0f, -3.0f, 0f);
        }
        else
        {
            body.velocity = new Vector3(0f, 3.0f, 0f);
        }
        
    }
    public void SetBulletDirection(bool FireDirection)
    {
        EnemyBullet = FireDirection;
    }
}
