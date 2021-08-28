using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioScript : MonoBehaviour
{
    // Start is called before the first frame update
    private AudioSource source;
    
    void Awake()
    {
        source = GetComponent<AudioSource>();
    }
    void Start()
    {
        
    }
    public void Play()
    {
        source.Play();
    }
   
    // Update is called once per frame
    void Update()
    {
        
    }
}
