using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallHitBumper : MonoBehaviour
{
    public AudioSource bumpBeep;
    private Light bumpLight;
    private IEnumerator coroutine;
    private GameObject bumpers;
    private Material startingMaterial, emissiveMaterial;
    private MeshRenderer meshRenderer;
    public int scoreThisItem = 45;
    public float bumperThrust = 5;
    private bool isASpinner, isABumper;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        // scoreKeeper = gameObject.AddComponent<ScoreKeeper>();  

      //  bumpers = GameObject.Find("Bumpers");
        bumpBeep = GetComponent<AudioSource>();
        bumpLight = GetComponent<Light>();
        meshRenderer = GetComponent<MeshRenderer>();
        isASpinner = gameObject.CompareTag("Spinner");
        isABumper = gameObject.CompareTag("Bumper");
        rb = GameObject.Find("TheBall").GetComponent<Rigidbody>(); 
              
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("TheBall"))
        {
            ScoreKeeper.UpdateScore(scoreThisItem);
            bumpBeep.Play();
            // bumpLight.enabled = true; //Looks like we can replace "lights" with "emission" shader option
            //  Debug.Log(" light on");
            meshRenderer.material.EnableKeyword("_EMISSION");
            if (isABumper)
            {
                rb.AddForceAtPosition(Vector3.forward * bumperThrust, rb.position, ForceMode.VelocityChange);
            }
            if (isASpinner)
            {
                //Debug.Log("Spinner hit...");
                meshRenderer.enabled = true;
            }
            coroutine = TurnOutLight(.5f);  //and make spinner invisible
            StartCoroutine(coroutine);
        }
      //  else Debug.Log("collided with something else?  " + collision.gameObject);  //reports the gate on shoot?? whatever...
    }

    IEnumerator TurnOutLight(float waitTime)   //AND reset visibility of spinner object
    {
        yield return new WaitForSeconds(waitTime);
        meshRenderer.material.DisableKeyword("_EMISSION");
        if (isASpinner)
        {
           meshRenderer.enabled = false;
        }
    }
}
