using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadAudioController : MonoBehaviour
{
	public AudioSource subMachineGunAudio;
	public AudioClip sound1;
	public AudioClip sound2;
	public AudioClip sound3;

	void SoundF()
	{
		subMachineGunAudio.clip = sound1;
		subMachineGunAudio.Play(); 
	}
	
	void SoundS()
	{
		subMachineGunAudio.clip = sound2;
		subMachineGunAudio.Play(); 
	}
	
	void SoundT()
	{
		subMachineGunAudio.clip = sound3;
		subMachineGunAudio.Play(); 
	}	
}