using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody enemyRB;
    private GameObject player;
    public float speed;
    public float lifeSpan;
    public ParticleSystem particleEffect;
    public AudioClip crashSound;
    public AudioClip spawnSound;
    
    void Start()
    {
        player = GameObject.Find("Player");
        particleEffect.Play();
        StartCoroutine(SelfDestruct());
    }
    void Update()
    {
        moveToPlayer();
    }

    void OnCollisionEnter(Collision other) {
        if (other.gameObject.CompareTag("Player"))
        {
            onDestroy();
        }
    }

    IEnumerator SelfDestruct(){
        yield return new WaitForSeconds(lifeSpan);  
        onDestroy();
    }

    private void onDestroy(){ 
        Destroy(gameObject);        
    }
    private void moveToPlayer(){
        float step = speed*Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);
        transform.rotation = Quaternion.Inverse(player.transform.rotation);
    }
}
