using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

///////////////
/// <summary>
///     
/// AudioSFXController controls the SFX audio of the game. Find the Audio ReadMe for more info on audio setup / workflow
/// 
/// CONTROLLER CLASS
/// This Controller class is used as a manager of an entire system. 
/// This Controller is assigned a singleton for easy access.
/// 
/// - Written By Cazac.
/// 
/// </summary>
///////////////

public class AudioSFXController : MonoBehaviour
{
    //////////////////////////////// - Singleton Refference

    public static AudioSFXController Instance;

    ////////////////////////////////

    [Header("Audio Track Prefab")]
    public GameObject audioTrack_Prefab;

    [Header("Container")]
    public GameObject sfxTrack_Container;

    /////////////////////////////////////////////////////////////////

    private void Awake()
    {
        //Self Refference Singleton
        Instance = this;
    }

    /////////////////////////////////////////////////////////////////

    public GameObject PlayTrackSFX_SpatialLocation_SingleTrack(Audio_SO audioSO, GameObject locationalParent)
    {
        //Instantiate New Audio Source At Location
        GameObject newAudioTrack = Instantiate(audioTrack_Prefab, locationalParent.transform);
        newAudioTrack.name = "SFX Track (" + audioSO.audioName + ")";

        ///////////////
        /// <TODO>
        /// 
        /// Send Database value for sliders
        /// 
        /// </TODO>
        ///////////////

        //SFX Setup
        newAudioTrack.GetComponent<AudioTab>().SetupAudioTrack(audioSO, 1, false);

        return newAudioTrack;
    }

    public GameObject PlayTrackSFX_NoLocation_SingleTrack(Audio_SO audioSO)
    {
        //Instantiate New Audio Source Unser Container
        GameObject newAudioTrack = Instantiate(audioTrack_Prefab, sfxTrack_Container.transform);
        newAudioTrack.name = "SFX Track (" + audioSO.audioName + ")";

        ///////////////
        /// <TODO>
        /// 
        /// Send Database value for sliders
        /// 
        /// </TODO>
        ///////////////

        //SFX Setup
        newAudioTrack.GetComponent<AudioTab>().SetupAudioTrack(audioSO, 1, false);

        return newAudioTrack;
    }

    /////////////////////////////////////////////////////////////////

    public GameObject PlayTrackSFX_SpatialLocation_TrackList(List<Audio_SO> audioSO_List, GameObject locationalParent)
    {
        //Random Choice
        int randomChoice = Random.Range(0, audioSO_List.Count);

        //Instantiate New Audio Source At Location
        GameObject newAudioTrack = Instantiate(audioTrack_Prefab, locationalParent.transform);
        newAudioTrack.name = "SFX Track (" + audioSO_List[randomChoice].audioName + ")";

        ///////////////
        /// <TODO>
        /// 
        /// Send Database value for sliders
        /// 
        /// </TODO>
        ///////////////

        //SFX Setup
        newAudioTrack.GetComponent<AudioTab>().SetupAudioTrack(audioSO_List[randomChoice], 1, false);

        return newAudioTrack;
    }

    public GameObject PlayTrackSFX_NoLocation_TrackList(List<Audio_SO> audioSO_List)
    {
        //Random Choice
        int randomChoice = Random.Range(0, audioSO_List.Count);

        //Instantiate New Audio Source Unser Container
        GameObject newAudioTrack = Instantiate(audioTrack_Prefab, sfxTrack_Container.transform);
        newAudioTrack.name = "SFX Track (" + audioSO_List[randomChoice].audioName + ")";

        ///////////////
        /// <TODO>
        /// 
        /// Send Database value for sliders
        /// 
        /// </TODO>
        ///////////////

        //SFX Setup
        newAudioTrack.GetComponent<AudioTab>().SetupAudioTrack(audioSO_List[randomChoice], 1, false);

        return newAudioTrack;
    }

    /////////////////////////////////////////////////////////////////

    public void StopTrackSFX_Single(GameObject audioTrack)
    {
        ///////////////
        /// <TODO>
        /// 
        /// How to stucture list of currenctly playing audio tracks?
        /// 
        /// </TODO>
        ///////////////
    }

    public void StopTrackSFX_All()
    {
        //Loop all Tabs
        foreach (Transform child in sfxTrack_Container.transform)
        {
            //Get Tab
            AudioTab audioTab = child.gameObject.GetComponent<AudioTab>();

            //Fade Out Or Destory
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
        //Loop All Current SFX Tracks
        foreach (Transform child in sfxTrack_Container.transform)
        {
            //Get Tab
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
