using UnityEngine;
using System.Collections;

public class HeartScript : MonoBehaviour {

    private AudioSource coinSound;
    private Renderer _renderer;
    private BoxCollider boxCollider;

    public GameController gameController;

    // Use this for initialization
    void Start()
    {
        this.coinSound = gameObject.GetComponent<AudioSource>();
        this._renderer = gameObject.GetComponent<Renderer>();
        this.boxCollider = gameObject.GetComponent<BoxCollider>();

    }

    // Update is called once per frame

    void OnTriggerEnter(Collider other)
    {
      
        this.gameController.Score += 200;
        this.coinSound.Play();
        this._renderer.enabled = false;
        this.boxCollider.enabled = false;
        Destroy(gameObject, 1);

    }
}
