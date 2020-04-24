using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

///////////////
/// <summary>
///     
/// AudioMusicController controls the Music audio of the game. Find the Audio ReadMe for more info on audio setup / workflow
/// 
/// CONTROLLER CLASS
/// This Controller class is used as a manager of an entire system. 
/// This Controller is assigned a singleton for easy access.
/// 
/// - Written By Cazac.
/// 
/// </summary>
///////////////

public class AudioMusicController : MonoBehaviour
{
    ////////////////////////////////

    public static AudioMusicController Instance;

    ////////////////////////////////

    [Header("Audio Track Prefab")]
    public GameObject audioTrack_Prefab;

    [Header("Container")]
    public GameObject musicTrack_Container;

    ///////////////////////////////////////////////////////

    private void Awake()
    {
        //Set Static Singleton Self Refference
        Instance = this;
    }

    /////////////////////////////////////////////////////////////////

    public GameObject PlayTrackMusic_SpatialLocation(Audio_SO audioSO, GameObject locationalParent)
    {
        //Stop Other Music
        StopTrackMusic_All();

        //Instantiate New Audio Source At Location
        GameObject newAudioTrack = Instantiate(audioTrack_Prefab, locationalParent.transform);
        newAudioTrack.name = "Music Track (" + audioSO.audioName + ")";

        ///////////////
        /// <TODO>
        /// 
        /// Send Database value for sliders
        /// 
        /// </TODO>
        ///////////////

        //Music Setup
        newAudioTrack.GetComponent<AudioTab>().SetupAudioTrack(audioSO, 1, false);

        return newAudioTrack;
    }

    public GameObject PlayTrackMusic_NoLocation(Audio_SO audioSO)
    {
        //Stop Other Music
        StopTrackMusic_All();

        //Instantiate New Audio Source User Container
        GameObject newAudioTrack = Instantiate(audioTrack_Prefab, musicTrack_Container.transform);
        newAudioTrack.name = "Music Track (" + audioSO.audioName + ")";

        ///////////////
        /// <TODO>
        /// 
        /// Send Database value for sliders
        /// 
        /// </TODO>
        ///////////////

        //Music Setup
        newAudioTrack.GetComponent<AudioTab>().SetupAudioTrack(audioSO, 1, false);

        return newAudioTrack;
    }

    /////////////////////////////////////////////////////////////////

    public void StopTrackMusic_Single(GameObject audioTrack)
    {
        ///////////////
        /// <TODO>
        /// 
        /// How to stucture list of currenctly playing audio tracks?
        /// 
        /// </TODO>
        ///////////////
    }

    public void StopTrackMusic_All()
    {
        //Loop all Tabs
        foreach (Transform child in musicTrack_Container.transform)
        {
            //Get Tab
            AudioTab audioTab = child.gameObject.GetComponent<AudioTab>();

            //Fade Out Or Instant Destory
            if (audioTab.currentAudio_SO.canFadeOut)
            {
                StartCoroutine(audioTab.IAudioVolumeDampeningOnDestory(audioTab.currentAudio_SO.fadeOutSpeed));
            }
            else
            {
                audioTab.DestoryAudio_Instant();
            }
        }
    }

    /////////////////////////////////////////////////////////////////

    public void VolumeLevels_UpdateAll(float newAudioLevel, bool isMuted)
    {
        //Loop All Current Music Tracks
        foreach (Transform child in musicTrack_Container.transform)
        {
            //Get Music Tab
            AudioTab audioTab = child.gameObject.GetComponent<AudioTab>();

            //Set Volume
            if (isMuted)
            {
                //Mute
                audioTab.audioSource.volume = 0;
            }
            else
            {
                //Update Volume
                audioTab.audioSource.volume = audioTab.currentAudio_SO.volume * newAudioLevel;
            }
        }
    }

    /////////////////////////////////////////////////////////////////
}