using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPipe : MonoBehaviour
{
    // Start is called before the first frame update
    
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider c)
    {

        GameObject gameManager = GameObject.Find("GameManager");

        gameManager.GetComponent<GameManager>().DetectPipe();
       
    }
  
    
   
}
