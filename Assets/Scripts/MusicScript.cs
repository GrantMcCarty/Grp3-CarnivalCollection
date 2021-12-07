using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicScript : MonoBehaviour
{
    //https://answers.unity.com/questions/1260393/make-music-continue-playing-through-scenes.html

    private AudioSource audioSource;
    public AudioClip[] songs;
    private int clipNumber;
    // Start is called before the first frame update
    private void Start()
    {
        if (GameObject.FindGameObjectsWithTag("Music").Length > 1) Destroy(gameObject);
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.volume = 0.3f;
        clipNumber = 0;
    }
    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        audioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (!audioSource.isPlaying) PlayMusic();
    }
    public void PlayMusic()
    {
        if (audioSource.isPlaying) return;
        audioSource.clip = songs[clipNumber];
        clipNumber++;
        audioSource.Play();
    }
    public void CancelMusic()
    {
        audioSource.Stop();
    }
}
