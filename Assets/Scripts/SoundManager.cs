using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SoundManager : MonoBehaviour
{
	[Header("Sound Clips")]
	

	[Header("Audio player components")]
	public AudioSource EffectsSource;
	public AudioSource MusicSource;


	// Random pitch adjustment range.
	public float LowPitchRange = .95f;
	public float HighPitchRange = 1.05f;
	private float musicVolume = 1f;
	// Singleton instance.
	public static SoundManager Instance = null;

	// Initialize the singleton instance.
	private void Awake()
	{
		// If there is not already an instance of SoundManager, set it to this.
		if (Instance == null)
		{
			Instance = this;
		}
		//If an instance already exists, destroy whatever this object is to enforce the singleton.
		else if (Instance != this)
		{
			Destroy(gameObject);
		}

		//Set SoundManager to DontDestroyOnLoad so that it won't be destroyed when reloading our scene.
		DontDestroyOnLoad(gameObject);
	}
	/// <summary>
	// Needed to adjust slider volume
	/// </summary>
	void Update()
	{
		MusicSource.volume = musicVolume;
	}

	//Function used to update slider volume to audiosource
	public void updateVolume(float volume)
	{
		musicVolume = volume;
	}

// Play a single clip through the sound effects source.
public void Play(AudioClip clip)
	{
		EffectsSource.clip = clip;
		EffectsSource.Play();
	}

	// Play a single clip through the music source.
	public void PlayMusic(AudioClip clip)
	{
		MusicSource.clip = clip;
		MusicSource.Play();
	}

	public void StopMusic()
    {
		MusicSource.Stop();
    }
}
