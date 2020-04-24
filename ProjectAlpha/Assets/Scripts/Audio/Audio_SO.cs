using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///////////////
/// <summary>
///     
/// TM_Audio_SO creates the Scriptable Objects for audio files used in both SFX and Music.
/// 
/// </summary>
///////////////

[CreateAssetMenu(fileName = "Audio", menuName = "Scriptables/New Audio")]
public class Audio_SO : ScriptableObject
{
    ////////////////////////////////

    [Header("Name")]
    [Tooltip("Audio Clip Name used to identify the audio as a gameobject (Not Required)")]
    public string audioName;

    [Header("Clip")]
    [Tooltip("Audio Clip being used for this sound (Required)")]
    public AudioClip audioClip;

    ////////////////////////////////

    [Header("Settngs - Volume")]
    [Tooltip("Base 'Max' Audio voulme this clip will play at")]
    public float volume;

    [Header("Settngs - Pitch")]
    [Tooltip("Default pitch the clip plays at")]
    public float pitch;
    [Range(0, 5)]
    [Tooltip("Pitch range is added to the pitch as a randomized +/- value use for varing sound pitch. Add no range for deafult pitch")]
    public float pitchRange;

    [Header("Settngs - spatialAudio")]
    [Range(0, 1)]
    [Tooltip("Spatial Audio sets if the audio is positional in 3d space or from all directions. 0 = 2D / 1 = 3D")]
    public float spatialAudioRange;

    ////////////////////////////////

    [Header("Settngs - Looping")]
    [Tooltip("Check if the sound will infinitly loop or auto-destroy on finsh")]
    public bool canLoop;

    [Header("Settngs - Fade In")]
    [Tooltip("Allows Audio clips to fade in when created")]
    public bool canFadeIn;
    [Range(0, 3)]
    [Tooltip("How quickly audio clips fade in when created (Measured in seconds from 0 -> 100)")]
    public float fadeInSpeed;

    [Header("Settngs - Fade Out")]
    [Tooltip("Allows Audio clips to fade out when called for destruction")]
    public bool canFadeOut;
    [Range(0, 3)]
    [Tooltip("How quickly audio clips fade out when called for destruction (Measured in seconds from 100 -> 0)")]
    public float fadeOutSpeed;

    /////////////////////////////////////////////////////////////////

    private void Reset()
    {
        //Sets Default Values into the Scriptable Object when created
        volume = 1;
        pitch = 1;
        pitchRange = 0;
        spatialAudioRange = 0;
    }

    /////////////////////////////////////////////////////////////////
}
