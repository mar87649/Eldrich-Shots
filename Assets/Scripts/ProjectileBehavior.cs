using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody projectileRB;
    private float maxDistance = 1000;
    void Start()
    {        
        projectileRB = GetComponent<Rigidbody>();
        hideAtDistance(maxDistance);

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision other) {
        if (!other.gameObject.CompareTag("Player"))
        {
            Rigidbody projectileRB = GetComponent<Rigidbody>();
            resetBullet();

        }
        
    }

    void resetBullet(){
        Rigidbody projectileRB = GetComponent<Rigidbody>();
        projectileRB.velocity = Vector3.zero;
        projectileRB.angularVelocity = Vector3.zero;
        gameObject.SetActive(false); 
    }

    void hideAtDistance(float maxDistance){
        if (transform.position.x > 1000 || transform.position.y > 1000 || transform.position.x > 1000 ||
            transform.position.x < -1000 || transform.position.y < -1000 || transform.position.x < -1000)
        {
            resetBullet();
        }
    }
}
