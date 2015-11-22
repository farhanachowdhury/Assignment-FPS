using UnityEngine;
using System.Collections;

public class SkullKill : MonoBehaviour {

    public GameController gameController;
    public GameObject skullExplosion;
   

    private Transform _transform;
    private AudioSource deathSound;
    


    // Use this for initialization
    void Start()
    {
        this.deathSound = gameObject.GetComponent<AudioSource>();
        this._transform = gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            this.deathSound.Play();
            gameController.DeductLife(1);
           

        }
    }
}
