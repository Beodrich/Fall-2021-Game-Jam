using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class AudioManager : MonoBehaviour
{
    public static AudioManager instance=null;
    public AudioSource EffectsSource;
	public AudioSource MusicSource;

    private void Awake() {
        if(instance==null){
            instance=this;
        }
        else if(instance!=null){
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
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

}
