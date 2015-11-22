using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Utility;


public class PlayerShooting : MonoBehaviour
{

    // PUBLIC INSTANCE VARIABLES - ACCESSIBLE ON INSPECTOR
    public ParticleSystem muzzleflash;
    public GameObject impact;
    public Animator rifleAnimator;
    public AudioSource bulletFireSound;
    public AudioSource bulletImpactSound;
    public GameObject explosion;
    public GameController gameController;

    // PRIVATE INSTANCE VARIABLES
    private GameObject[] _impacts;
    private int _currentImpact = 0;
    private int _maxImpacts = 5;

    private bool _shooting = false;
    private Transform _transform;

    // Use this for initialization
    void Start()
    {
        // object pool for the impact particle system
        this._impacts = new GameObject[this._maxImpacts];
        for (int impactCount = 0; impactCount < this._maxImpacts; impactCount++)
        {
            this._impacts[impactCount] = (GameObject)Instantiate(this.impact);
        }
        this._transform = gameObject.GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
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
    void FixedUpdate()
    {
        if (this._shooting)
        {
            this._shooting = false;

            RaycastHit hit; // stores information from the Ray

            if (Physics.Raycast(this._transform.position, this._transform.forward, out hit, 50f))
            {

                	if(hit.transform.CompareTag("cementBag")) {
                // Destroy Barrel object upon hit
                	Destroy (hit.transform.gameObject);
                		Instantiate(this.explosion, hit.point, Quaternion.identity);
                        this.gameController.Score += 100;
                	}
                    if (hit.transform.CompareTag("Skull"))
                    {
                        Destroy(hit.transform.gameObject);
                        Instantiate(this.explosion, hit.point, Quaternion.identity);
                      
                    }


                // reposition the impact particle from the object pool to the ray's hit location
                this._impacts[this._currentImpact].transform.position = hit.point;
                // play the particle system
                this._impacts[this._currentImpact].GetComponent<ParticleSystem>().Play();
               this.bulletImpactSound.Play();

                if (++this._currentImpact >= this._maxImpacts)
                {
                    this._currentImpact = 0;
                }
            }
        }
    }
}
