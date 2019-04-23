using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSfx : MonoBehaviour
{

    public AudioClip win, lose;

    AudioSource asource;
    // Start is called before the first frame update
    void Start()
    {
        asource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play(string clipname) {
        switch(clipname){
            case "win":
                asource.PlayOneShot(win);
                break;
            case "lose":
                asource.PlayOneShot(lose);
                break;
        }
    }
}
