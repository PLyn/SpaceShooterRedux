using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyA : MonoBehaviour {
    private float ShootCooldown;
    public float fireRate;
    private Rigidbody2D body;
    public GameObject Bullet;
    private BulletController BulletController;
    private SpriteRenderer sprite;
    private GameObject BulletClone;

    // Use this for initialization
    void Start () {
        body = this.GetComponent<Rigidbody2D>();
        sprite = this.GetComponent<SpriteRenderer>();

        ShootCooldown = Time.time;
        ShootCooldown += fireRate;
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time > ShootCooldown)
        {
            BulletClone = GameObject.Instantiate(Bullet, new Vector3(body.position.x, body.position.y - (sprite.bounds.size.y / 2), (sprite.bounds.size.z)), Quaternion.identity);
            BulletController = (BulletController)BulletClone.GetComponent(typeof(BulletController));
            BulletController.SetBulletDirection(true);

            ShootCooldown += fireRate;
        }
	}
    void OnTriggerEnter2D(Collider2D col)
    {
        BulletController = (BulletController)col.gameObject.GetComponent(typeof(BulletController));
        if (!BulletController.EnemyBullet)
        {
            Debug.Log("Enemy Killed");
            Destroy(col.transform.root.gameObject);
            Destroy(this.transform.root.gameObject);
        }
        
    }
}
