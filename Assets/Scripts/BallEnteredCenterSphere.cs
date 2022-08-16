using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallEnteredCenterSphere : MonoBehaviour
{
    public int scoreThisItem = 45;
    private Transform transformTheBall;
    private GameObject[] splashBalls;
    private AudioSource splash;
    // Start is called before the first frame update
    void Start()
    {
        splash = GetComponent<AudioSource>();
        transformTheBall = GameObject.Find("TheBall").GetComponent<Transform>();
        splashBalls = GameObject.FindGameObjectsWithTag("SplashBall");
        //int i; //= splashBalls.Length;
        for ( int i=0; i < splashBalls.Length; i++) 
        {
            splashBalls[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("TheBall"))
        {
            splash.Play();
            ScoreKeeper.UpdateScore(scoreThisItem);
            transformTheBall.transform.localScale = new Vector3(.5f, .5f, .5f);
            for (int i = 0; i < splashBalls.Length; i++)
            {
                splashBalls[i].SetActive(true);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.CompareTag("TheBall"))
        {
            ScoreKeeper.UpdateScore(scoreThisItem);
            transformTheBall.transform.localScale = new Vector3(.32f, .32f, .32f);
            for (int i = 0; i < splashBalls.Length; i++)
            {
                splashBalls[i].SetActive(false);
            }
        }
    }
}
