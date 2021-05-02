using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    public float lifeSpan = 5;
    public float expandSize = 3;
    public float timeToExpansion = 2.5f;
    void Start()
    {
        StartCoroutine(ExpandObject());
         Destroy(gameObject, lifeSpan);
    }

    // Update is called once per frame
    IEnumerator ExpandObject(){
        yield return new WaitForSeconds(timeToExpansion);
        transform.localScale += new Vector3(expandSize,expandSize,expandSize);        
    }
}
