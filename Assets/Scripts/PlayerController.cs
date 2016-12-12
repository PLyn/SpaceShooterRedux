using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float speed;
    private SpriteRenderer sprite;
    private Rigidbody2D body;
    private BulletController BulletController;
    public GameObject Bullet;
    private GameObject BulletClone;

    // Use this for initialization
    void Start () {
        body = this.GetComponent<Rigidbody2D>();
        sprite = this.GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            body.position = new Vector2(body.position.x, body.position.y + speed);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            body.position = new Vector2(body.position.x, body.position.y + -speed);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            body.position = new Vector2(body.position.x + -speed, body.position.y);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            body.position = new Vector2(body.position.x + speed, body.position.y);
        }

        if (Input.GetButtonDown("Fire1"))
        {
            Fire();
        }
    }
    void FixedUpdate(){
        
    }

    void Fire()
    {
        BulletClone = GameObject.Instantiate(Bullet, new Vector3(body.position.x, body.position.y + (sprite.bounds.size.y / 2), (sprite.bounds.size.z)), Quaternion.identity);
        BulletController = (BulletController)BulletClone.GetComponent(typeof(BulletController));
        //BulletController.SetBulletDirection(false);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        BulletController = (BulletController)col.gameObject.GetComponent(typeof(BulletController));
        if (BulletController.EnemyBullet)
        {
            Debug.Log("Game Over!");
            Destroy(col.transform.root.gameObject);
        }
        
    }
}
