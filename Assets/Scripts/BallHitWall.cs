using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallHitWall : MonoBehaviour
    {
    public AudioSource wallSound;
    // Start is called before the first frame update
    void Start()
    {
        wallSound = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("TheBall"))
        {
            wallSound.Play();

        }
    }
}
