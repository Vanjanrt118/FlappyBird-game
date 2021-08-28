using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
  
   [SerializeField] float jump=6;
    public  GameManager gm;
    public GameObject ptica;
    public GameObject desnoKrilo;
    public GameObject levoKrilo;
    public AudioScript audioWings;
    public AudioScript audioGameOver;
    Animator a;
    Animator a2;
    Animator a3;
    Rigidbody rb;
    UnityEngine.Vector3 pocetnaPoz;
   
   
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        pocetnaPoz = this.transform.position;
        // ptica.GetComponent<Animator>().enabled = true;
        GetComponent<Rigidbody>().useGravity = false;
        a = ptica.GetComponent<Animator>();
       a2= desnoKrilo.GetComponent<Animator>();
        a3 = levoKrilo.GetComponent<Animator>();


    }

    // Update is called once per frame
    void Update()
    {

        if(GameManager.gameState == GameManager.GameState.running)
        {
           
            Move();
            GetComponent<Rigidbody>().useGravity = true;
          
           
           

        }
        else if (GameManager.gameState == GameManager.GameState.gameover)
        {

          

        }
       
        else if(GameManager.gameState == GameManager.GameState.start)
        {

            GetComponent<Rigidbody>().useGravity = false;
            
           



        }



    }
    public void AnimationStart()
    {
       a.enabled = true;
    }
    public void AnimationStop()
    {
       a.enabled = false;
    }
    public void AnimationWingStart()
    {
        a2.enabled = true;
        a3.enabled = true;
    }
    public void AnimationWingStop()
    {
        a2.enabled = false;
        a3.enabled = false;
    }
    void Move()
    {
        
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {

            rb.velocity = UnityEngine.Vector3.up * jump;
            audioWings.Play();
           


        }
    }
    public void Reset()
    {
        transform.position = pocetnaPoz;
    }
    void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.name == "Bottom" || c.gameObject.name == "Top" || c.gameObject.name == "Cup" || c.gameObject.name=="Ground")
        {
            if(GameManager.gameState==GameManager.GameState.running)
            gm.GameOver();
           
            
            


        }
    }

}
