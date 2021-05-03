using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed = 1;
    public float sensitivity = 1;    
    public float jumpForce;
    private Rigidbody playerRB;
    private GameObject cameraView;
    private bool isOnGround;
    public GameObject projectile;  
    private GameObject bulletSpawner;  
    private AudioSource playerAudio;
    public AudioClip jumpSound;
    public AudioClip moveSound;
    public AudioClip injuredSound;
    public TextMeshProUGUI healthText;
    public int health = 10;

    void Start()
    {
        health = 10;
        healthText.text = "health: " + health;
        cameraView = GameObject.Find("Main Camera");
        playerRB = GetComponent<Rigidbody>();  
        isOnGround = true;    
        playerAudio = GetComponent<AudioSource>();  
    }

    // Update is called once per frame
    void Update()
    {
        movePlayer();        
        onJump();   
        playSoundFX(); 
        healthText.text = "health: " + health; 
    }

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.CompareTag("Ground")){            
            isOnGround = true; 
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            playerAudio.PlayOneShot(injuredSound);
            health -= 1;
        }
    } 

    private void movePlayer(){
        //play sounds
        //move player         
        if (Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0)
        {
        // move forward and backward along X znd Z axis
            Vector3 movementVertical = Vector3.Scale(cameraView.transform.forward*Input.GetAxis("Vertical"), new Vector3(1,0,1)); 
            transform.position +=  movementVertical * speed * Time.deltaTime;
        //move left or right according to look direction
            Vector3 movementHorizontal = Vector3.Scale(cameraView.transform.right*Input.GetAxis("Horizontal"), new Vector3(1,0,1));
            transform.position += movementHorizontal * speed * Time.deltaTime;
        }
               
        //look left / right
        Vector3 rotateHorizontal = new Vector3(0, Input.GetAxis("Mouse X"), 0);
        transform.Rotate(rotateHorizontal);
        //look up
        Vector3 rotateVertical = new Vector3(-Input.GetAxis("Mouse Y"), 0, 0);
        cameraView.transform.Rotate(rotateVertical); 
    }   

    void onJump(){
        if(Input.GetKeyDown(KeyCode.Space) && isOnGround){
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;    
            playerAudio.PlayOneShot(jumpSound, 1f);
        }
    }

    void playSoundFX(){

    }



}
