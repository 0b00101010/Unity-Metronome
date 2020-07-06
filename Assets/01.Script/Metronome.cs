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

    [Header("Values")]
    [SerializeField]
    private double offset;

    [SerializeField]
    private double bpm;

    [SerializeField]
    private int split;

    private double oneBeatTime;
    private double nextSample;

    private void Awake(){
        double offsetForSample = offset * audioSource.clip.frequency;
        oneBeatTime = (60.0 / bpm);

        nextSample = offsetForSample;

        audioSource.clip.frequency.Log();
        audioSource.clip.samples.Log();
        
        (audioSource.clip.samples / audioSource.clip.frequency).Log();
    }

    private void Update(){
        (audioSource.timeSamples / audioSource.clip.frequency).Log();
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
