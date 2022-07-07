using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Script to control the on and off value buttons in the Start Menu
public class VolumeManager : MonoBehaviour
{
    //Sound on Image
    private Sprite soundOnImage;

    //Sound off Image
    public Sprite soundOffImage;

    //Sound ON/OFF Button
    public Button button;

    //Sound On 
    public static bool isOn = true;

    //The Start Menu background music
    [SerializeField] private AudioSource audioSource;
    void Start()
    {
        //Sound is On by default
        soundOnImage = button.image.sprite;
    }

    public void ButtonClicked()
    {
        if (isOn) 
        {
            //Change the sprite and mute music
            button.image.sprite = soundOffImage;
            isOn = false;
            audioSource.mute = true;
        }
        else
        {
            //Change the sprite and unmute music
            button.image.sprite = soundOnImage;
            isOn = true;
            audioSource.mute = false;
        }
    }
}
