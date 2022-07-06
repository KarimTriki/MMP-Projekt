using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource backgroundSound;
    // Start is called before the first frame update
    void Start()
    {
        if (VolumeManager.isOn) {
            backgroundSound.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
