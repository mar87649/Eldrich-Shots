using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject player;
    public GameObject bullet;
    public float speed = 100;
    public float arc = 300;
    public int poolingAmount=20;
    public List<GameObject> pooledObjects;
    private AudioSource audioSource;
    public AudioClip bulletSpawnFX;


    void Start()
    {
        player = GameObject.Find("Player");
        audioSource = GetComponent<AudioSource>(); 
        PoolingSetup();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
        audioSource.PlayOneShot(bulletSpawnFX);
        bullet = GetInactivePooledObject();
        if (bullet  !=null)
            {
            bullet.transform.position = transform.position;
            bullet.transform.rotation = transform.rotation;
            Vector3 absZForward = new Vector3(player.transform.forward.x*speed, player.transform.forward.y+arc, player.transform.forward.z*speed);
            bullet.SetActive(true);               
            bullet.GetComponent<Rigidbody>().AddForce(absZForward);            
            }            
        }                             
    }

    private void PoolingSetup(){
        pooledObjects = new List<GameObject>();
        for (int i = 0; i < poolingAmount; i++)
        {
            GameObject temp = Instantiate(bullet);
            temp.SetActive(false);
            pooledObjects.Add(temp);
        }
    }

    private GameObject GetInactivePooledObject(){
        //for each pooled object, if object is not active, return the object
        for (int i = 0; i < poolingAmount; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        return null;
    }
    private GameObject GetActivePooledObject(){
        //for each pooled object, if object is active, return the object
        for (int i = 0; i < poolingAmount; i++)
        {
            if (pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        return null;
    }

    
}
