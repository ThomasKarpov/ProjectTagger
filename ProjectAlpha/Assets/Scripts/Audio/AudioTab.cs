using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///////////////
/// <summary>
///     
/// TM_AudioTab
/// 
/// TAB CLASS 
/// 
/// 
/// </summary>
///////////////

public class AudioTab : MonoBehaviour
{
    ////////////////////////////////

    [Header("Connected Audio Source")]
    public AudioSource audioSource;

    [Header("Connected Audio Scriptable")]
    public Audio_SO currentAudio_SO;

    /////////////////////////////////////////////////////////////////

    public void SetupAudioTrack(Audio_SO audioSO, float audioTypeVolume, bool isMuted)
    {
        //Save Scriptable 
        currentAudio_SO = audioSO;

        //Settings
        audioSource.clip = audioSO.audioClip;
        audioSource.loop = audioSO.canLoop;
        audioSource.pitch = audioSO.pitch + (Random.Range(-audioSO.pitchRange, audioSO.pitchRange));
        audioSource.spatialBlend = audioSO.spatialAudioRange;
        audioSource.volume = currentAudio_SO.volume;



        ///////////////
        /// <TODO>
        ///     
        /// Add SOund Slider Settings
        /// 
        /// 
        // /Volume
        /// if (isMuted)
        /// {
        /// audioSource.volume = 0;
        /// }
        /// else
        /// {
        /// float volumeMutiplyer = TM_DatabaseController.Instance.settings_SaveData.volumeTotal * specficTypeVolume;
        /// print("Test Code: " + currentAudio_SO.volume * volumeMutiplyer);
        /// audioSource.volume = (currentAudio_SO.volume * volumeMutiplyer);
        /// }
        /// 
        /// 
        /// </TODO>
        ///////////////



        //Play Audio
        audioSource.Play();

        //Begin lerping volume of sound
        if (audioSO.canFadeIn == true)
        {
            //Begin lerping volume of sound
            StartCoroutine(IAudioVolumeDampeningOnLoad((audioSource.volume / 60), audioSource.volume, currentAudio_SO.fadeInSpeed));
        }

        //Set Fade Out Point For when to fade out the volume of the sound
        if (audioSO.canFadeIn == true)
        {
            //Begin lerping volume of sound
            StartCoroutine(IAudioVolumeDampeningOnLoad((audioSource.volume / 60), audioSource.volume, currentAudio_SO.fadeInSpeed));
        }

        //Begin Audio Destruction Countdown
        if (audioSO.canLoop == false)
        {
            //Begin Audio Destruction Countdown
            StartCoroutine(IAutoDestoryCountdown(currentAudio_SO.audioClip.length));
        }
    }

    /////////////////////////////////////////////////////////////////

    public IEnumerator IAudioVolumeDampeningOnLoad(float startVolume, float finalVolume, float volumeRampUpSpeed)
    {
        //Set Default Value
        audioSource.volume = startVolume;

        //Calculate Step Value Per Second
        float stepValue = audioSource.volume / volumeRampUpSpeed;

        //Loop Enum Til the max is hit
        while (audioSource.volume < finalVolume)
        {
            //Increase Volume Per Frame
            audioSource.volume += Time.deltaTime * stepValue;

            if (audioSource.volume >= finalVolume)
            {
                //Max Out Volume and Break Enum
                audioSource.volume = finalVolume;
                yield break;
            }

            //Wait For Next Frame
            yield return new WaitForEndOfFrame();
        }

        //Max Out Volume and Break Enum
        audioSource.volume = finalVolume;
        yield break;
    }

    public IEnumerator IAudioVolumeDampeningOnDestory(float volumeRampDownSpeed)
    {
        //Calculate Step Value Per Second
        float stepValue = audioSource.volume / volumeRampDownSpeed;

        //Loop Enum Til the max is hit
        while (audioSource.volume > 0)
        {
            //Increase Volume Per Frame
            audioSource.volume -= Time.deltaTime * stepValue;

            if (audioSource.volume <= 0)
            {
                //Max Out Volume and Break Enum
                audioSource.volume = 0;
                DestoryAudio_Instant();
                yield break;
            }

            //Wait For Next Frame
            yield return new WaitForEndOfFrame();
        }

        //Max Out Volume and Break Enum
        audioSource.volume = 0;
        DestoryAudio_Instant();
        yield break;
    }

    /////////////////////////////////////////////////////////////////

    private IEnumerator IAuto(float clipLength)
    {
        //Wait Till Clip is over + buffer room
        yield return new WaitForSeconds(clipLength + 0.1f);

        //Destory Clip
        DestoryAudio_Instant();

        //Break Out
        yield break;
    }


    private IEnumerator IAutoDestoryCountdown(float clipLength)
    {
        if (currentAudio_SO.canFadeOut)
        {
            //Caclualte Waiting Before Fade
            float waitLength = clipLength - currentAudio_SO.fadeOutSpeed;

            //Wait Till Clip is ready to fade out
            yield return new WaitForSeconds(waitLength);

            //Start Fading
            StartCoroutine(IAudioVolumeDampeningOnDestory(currentAudio_SO.fadeOutSpeed));

            //Break Out
            yield break;
        }
        else
        {
            //Wait Till Clip is over + buffer room
            yield return new WaitForSeconds(clipLength + 0.1f);

            //Destory Clip
            DestoryAudio_Instant();

            //Break Out
            yield break;
        }
    }

    /////////////////////////////////////////////////////////////////

    public void DestoryAudio_Instant()
    {
        //Destory Clip
        Destroy(gameObject);
    }

    /////////////////////////////////////////////////////////////////
}