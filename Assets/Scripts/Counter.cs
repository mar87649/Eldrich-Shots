using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    public Text CounterText;

    public int Count = 0;
    private AudioSource audioSource;
    public AudioClip scoreSound;

    private void Start()
    {
        Count = 0;
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        audioSource.PlayOneShot(scoreSound);
        Count += 1;
        CounterText.text = "Score : " + Count;
    }
}
