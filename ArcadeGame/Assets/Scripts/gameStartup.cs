using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameStartup : MonoBehaviour
{
    private bool PressedStart;
    public Animation StartText;
    public Animation BlackBoxActive;
    // Update is called once per frame

    private string[] ANIMNAMES = {"StartButtonIdle","StartButtonActive"};


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && !PressedStart)
        {
            PressedStart = true;
            StartText.Play(ANIMNAMES[1]);
            BlackBoxActive.Play();
            Debug.Log("Enter key has been pressed.");
            //StartText.SetBool("StartButtonHasBeenPressed", true);
            //BlackBox.SetBool("StartFade", true) ;
        }

        if (PressedStart && !StartText.isPlaying)
        {
            StartText.Play(ANIMNAMES[1]);
        }


        if (!PressedStart && !StartText.isPlaying)
        {
            StartText.Play(ANIMNAMES[0]);
        }
    }

    
}
