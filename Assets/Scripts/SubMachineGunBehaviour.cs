using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubMachineGunBehaviour : MonoBehaviour 
{
	public int damage;
	public float range;  
	public Camera mainCamera; 

	public float fireRate;
	private float currentRateToFire;
	public float timeToReload;
	private float currentTimeToReload;
	public bool isReloading = false;
	public bool canShoot = true;
	public bool isDraw;

	public AudioSource subMachineGunAudio;
	public AudioClip shootSound;
	public AudioClip drawSound;

	public Animation subMachineGunAnimation; 
	public AnimationClip shootAnim;
	public AnimationClip drawAnim;
	public AnimationClip reloadAnim;

	void Start ()
	{
		currentRateToFire = fireRate;
		currentTimeToReload = timeToReload;
	}
 
	void Update ()
	{
		currentRateToFire += Time.deltaTime;
		currentTimeToReload += Time.deltaTime;

  		if(subMachineGunAnimation.IsPlaying(drawAnim.name))
		{
			isDraw = true;
   		}
			else
		{
			isDraw = false;
		}
		
		if(currentTimeToReload >= timeToReload)
		{
			canShoot = true;
		}
	}

    //função do Button de Reload. 
	public void ReloadButton()
	{ 
		Reload();
	}

    //função do Button de Atirar. 
	public void ShootButton()
	{ 
		if(currentRateToFire >= fireRate && canShoot && isDraw == false)
		{
			Shoot();
		} 
	}

 	void Shoot ()
 	{
		currentRateToFire = 0;
		subMachineGunAudio.clip = shootSound;
		subMachineGunAudio.Play();
		subMachineGunAnimation.clip = shootAnim;
		subMachineGunAnimation.Play();
		
		RaycastHit hit;
		if (Physics.Raycast (mainCamera.transform.position, mainCamera.transform.forward, out hit, range)) 
		{
			//Debug.Log ("Acertou" + hit.transform.name);
		}
	} 

	void Reload()
	{
		currentTimeToReload = 0;
		canShoot = false;
		subMachineGunAnimation.clip = reloadAnim;
		subMachineGunAnimation.Play(PlayMode.StopAll);
	}
	
	//isto so serve para quando quiser testar a mira com o sinal de "+"
	void OnGUI() 
	{
		GUI.Label (new Rect(Screen.width/2, Screen.height/2, 100, 20), "+");
	}
}