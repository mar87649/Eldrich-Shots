using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody enemyRB;
    private GameObject player;
    public float speed;
    public float lifeSpan;
    
    void Start()
    {
        //enemyRB = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        StartCoroutine(SelfDestruct());
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed*Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);
    }

    void OnCollisionEnter(Collision other) {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

    IEnumerator SelfDestruct(){
        yield return new WaitForSeconds(lifeSpan);
        Destroy(gameObject);
    }
}
