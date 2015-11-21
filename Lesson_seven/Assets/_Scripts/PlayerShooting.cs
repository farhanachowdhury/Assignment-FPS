using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Utility;


public class PlayerShooting : MonoBehaviour {

    // PUBLIC INSTANCE VARIABLES - ACCESSIBLE ON INSPECTOR
    public ParticleSystem muzzleflash;
    public GameObject impact;
    public Animator rifleAnimator;
    public AudioSource bulletFireSound;

    // PRIVATE INSTANCE VARIABLES
    private GameObject[] _impacts;
    private int _currentImpact = 0;
    private int _maxImpacts = 5;

    private bool _shooting = false;

	// Use this for initialization
	void Start () {
        // object pool for the impact particle system
        this._impacts = new GameObject[this._maxImpacts];
        for (int impactCount = 0; impactCount < this._maxImpacts; impactCount++)
        {
            this._impacts[impactCount] = (GameObject)Instantiate(this.impact);
        }
	
	}
	
	// Update is called once per frame
	void Update () {
        if (CrossPlatformInputManager.GetButtonDown("Fire1"))
        {
            this.muzzleflash.Play();
            this.bulletFireSound.Play();
            rifleAnimator.SetTrigger("Fire");
            this._shooting = true;
        }
        if (CrossPlatformInputManager.GetButtonUp("Fire1"))
        {
            this._shooting = false;
        }
	
	}
}
