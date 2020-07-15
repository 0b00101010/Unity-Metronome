using UnityEngine;

[CreateAssetMenu(fileName = "SongData", menuName = "SongData", order = 0)]
public class SongData : ScriptableObject {
    public double offset;
    public double bpm;
    public AudioClip audioClip;
}