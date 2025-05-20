using UnityEngine;
using UnityEngine.Audio;
using System.Collections.Generic;
public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;

    [SerializeField] AudioResource[] possibleSongsToPlay;
    List<AudioResource> musicQueue = new List<AudioResource>();

    void Update()
    {
        HandleMusic();
    }
    void HandleMusic()
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
