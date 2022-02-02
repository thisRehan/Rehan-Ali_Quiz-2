using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject[] bullet;
    [SerializeField] GameObject[] gun;
    private GameObject[] gunClone = new GameObject [3];
    private GameObject bulletClone;
    private int speed = 10;
    private int health = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        OutOfBound();
        GunShuffle();
        fireBullets();
        destroy();
    }
    void Movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * speed * Time.deltaTime * verticalInput);
        transform.Rotate(Vector3.up * speed * 5 * Time.deltaTime * horizontalInput);
    }
    void OutOfBound()
    {
        float xRange = 8;
        float zRange = 8;
        if (transform.position.x < -xRange)
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        if (transform.position.x > xRange)
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        if (transform.position.z < -zRange)
            transform.position = new Vector3(transform.position.x, transform.position.y, -zRange);
        if (transform.position.z > zRange)
            transform.position = new Vector3(transform.position.x, transform.position.y, zRange);
    }
    void GunShuffle()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1) && gunClone[0]==null)
        {
            gunClone[0] = Instantiate(gun[0], transform.position + new Vector3(0, 0.3f, 0.75f), gun[0].transform.rotation);
            gunClone[0].transform.parent = gameObject.transform;
            Destroy(gunClone[1]);
            Destroy(gunClone[2]);
        }
        if(Input.GetKeyDown(KeyCode.Alpha2) && gunClone[1] == null)
        {
            gunClone[1] = Instantiate(gun[1], transform.position + new Vector3(0, 0.3f, 0.75f), gun[1].transform.rotation);
            gunClone[1].transform.parent = gameObject.transform;
            Destroy(gunClone[0]);
            Destroy(gunClone[2]);
        }
        if(Input.GetKeyDown(KeyCode.Alpha3) && gunClone[2] == null)
        {
            gunClone[2] = Instantiate(gun[2], transform.position + new Vector3(0, 0.3f, 0.75f), gun[2].transform.rotation);
            gunClone[2].transform.parent = gameObject.transform;
            Destroy(gunClone[0]);
            Destroy(gunClone[1]);
        }
    }
    void fireBullets()
    {
        int speed = 500;
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(gunClone[0] !=null)
            {
                bulletClone = Instantiate(bullet[0], gunClone[0].transform.position, transform.rotation);
                bulletClone.GetComponent<Rigidbody>().AddForce(gunClone[0].transform.up * speed);
            }
            if(gunClone[1] != null)
            {
                bulletClone = Instantiate(bullet[1], gunClone[1].transform.position, transform.rotation);
                bulletClone.GetComponent<Rigidbody>().AddForce(gunClone[1].transform.up * speed);
            }
            if(gunClone[2] != null)
            {
                bulletClone = Instantiate(bullet[2], gunClone[2].transform.position, transform.rotation);
                bulletClone.GetComponent<Rigidbody>().AddForce(gunClone[2].transform.up * speed);
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
            health = health - 10;
    }
    void destroy()
    {
        if (health <= 0)
            Destroy(gameObject);
    }
}
