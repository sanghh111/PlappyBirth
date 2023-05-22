using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public static SoundController instance;

    private void Awake() {
        instance = this;
    }
    public void PlayThisSound(string clipName, float volumeMultiplier){
        AudioSource audioSource = this.gameObject.AddComponent<AudioSource>();
        audioSource.volume *= volumeMultiplier;
        audioSource.PlayOneShot((AudioClip)Resources.Load("Sounds/" +  clipName, typeof(AudioClip)));
    }
}
