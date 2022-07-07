using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script to control Background music in all the scenes depending on if music is activated or deactivated in the Start Menu
public class SoundPlayer : MonoBehaviour
{
    //The background music
    [SerializeField] private AudioSource backgroundSound;
    
    void Start()
    {
        if (VolumeManager.isOn) {
            backgroundSound.Play();
        }
    }
}
