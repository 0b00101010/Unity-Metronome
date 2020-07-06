using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Metronome : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private AudioSource ticSource;

    [Header("Song")]
    [SerializeField]
    private SongData selectSong;

    private double offset;
    private double bpm;

    private int split;

    private double oneBeatTime;
    private double nextSample;

    private void Awake(){
        audioSource.clip = selectSong.audioClip;
        
        offset = selectSong.offset;
        bpm = selectSong.bpm;
        split = selectSong.split;

        double offsetForSample = offset * audioSource.clip.frequency;
        oneBeatTime = (60.0 / bpm);

        nextSample = offsetForSample;

        audioSource.clip.frequency.Log();
        audioSource.clip.samples.Log();
        
        (audioSource.clip.samples / audioSource.clip.frequency).Log();

        audioSource.Play();
    }

    private void Update(){
        ((float)audioSource.timeSamples / (float)audioSource.clip.frequency).Log();
        if(audioSource.timeSamples >= nextSample){
            StartCoroutine(TicSFX());
        }
    }

    private IEnumerator TicSFX(){
        ticSource.Play();
        nextSample += oneBeatTime * audioSource.clip.frequency;

        yield return null;
    }
}
