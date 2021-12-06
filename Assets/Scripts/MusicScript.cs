using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicScript : MonoBehaviour
{
    //https://answers.unity.com/questions/1260393/make-music-continue-playing-through-scenes.html

    private AudioSource audioSource;
    public AudioClip[] songs;
    // Start is called before the first frame update
    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        audioSource = GetComponent<AudioSource>();
    }
    public void PlayMusic()
    {
        if (audioSource.isPlaying) return;
        audioSource.Play();
    }
    public void CancelMusic()
    {
        audioSource.Stop();
    }
}
