using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private GameObject player;
    public int health = 150;
    private int speed = 1;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        destroy();
    }
    void Movement()
    {
        if(player)
        {
            Vector3 direction = (player.transform.position - transform.position).normalized;
            transform.Translate(direction * speed * Time.deltaTime);
        }
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet1"))
        {
            health = health - 40;
            Destroy(collision.gameObject);
        }
        if(collision.gameObject.CompareTag("Bullet2"))
        {
            health = health - 80;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Bullet3"))
        {
            health = health - 120;
            Destroy(collision.gameObject);
        }
        if(collision.gameObject.CompareTag("Wall"))
        {
            health = 0;
        }
    }
    void destroy()
    {
        if (health <= 0)
        {
            Debug.Log("EnemyKilled");
            Destroy(gameObject);
        }
            
    }
}
