HOW TO USE THE AUDIO SYSTEMS
By Cazac

- Grab the SFX or Music file you want and create a audio scriptable object.
- Add AudioMusicController to an empty GameObject.
- Add AudioSFXController to an empty GameObject.
- Attach Containers and the "AudioTrack" Prefab.

- To play Music audio call either,
	- "AudioMusicController.Instance.PlayTrackMusic_SpatialLocation();"
	- "AudioMusicController.Instance.PlayTrackMusic_NoLocation();"
- Music will auto remove all other instances of music when played.

- To play SFX audio call either,
	- "PlayTrackSFX_SpatialLocation_SingleTrack();"
	- "PlayTrackSFX_NoLocation_SingleTrack();"
	- "PlayTrackSFX_SpatialLocation_TrackList();"
	- "PlayTrackSFX_NoLocation_TrackList();"
- SFX will auto destory themselves when the audio is done and can play over eachother.



- Not sure where to store audio scriptable yet / sound slider settings ???

