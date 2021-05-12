using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSliderScript : MonoBehaviour
{
    public AudioSource audioSource;
    private float musicVolume = 1f;

    // Update is called once per frame
    void Update()
    {
        audioSource.volume = musicVolume;
    }

    public void updateVolume(float volume) {
        musicVolume = volume;
    }
}
