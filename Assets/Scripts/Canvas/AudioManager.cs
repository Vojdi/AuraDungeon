using UnityEngine;
using UnityEngine.Audio;
using System.Collections.Generic;
using UnityEngine.Rendering;
public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioResource[] possibleSongsToPlay;
    [SerializeField]
    List<AudioResource> musicQueue = new List<AudioResource>();

    static AudioManager instance;
    public static AudioManager Instance => instance;
    bool gameOver = false;
    private void Start()
    {
        instance = this;
    }
    void Update()
    {
        HandleMusic();
    }
    void HandleMusic()
    {
        if (!gameOver)
        {
            if (!musicSource.isPlaying)
            {
                AudioResource rescource = (possibleSongsToPlay[Random.Range(0, possibleSongsToPlay.Length)]);
                foreach (var r in musicQueue)
                {
                    if (rescource == r)
                    {
                        return;
                    }
                }
                musicSource.resource = rescource;
                musicQueue.Add(rescource);
                if (musicQueue.Count == possibleSongsToPlay.Length)
                {
                    musicQueue.Clear();
                }
                musicSource.Play();

            }
        }
       
    }
    public void GameOver()
    {
        gameOver = true;
        musicSource.Stop();
    }
}
