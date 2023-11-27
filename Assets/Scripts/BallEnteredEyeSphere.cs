using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallEnteredEyeSphere : MonoBehaviour
{
    public int scoreThisItem = 45;
    private Transform transformTheBall, transformSurfaceEye, transformEye; //transformEye is the eye on the display panel
    private Rigidbody rb;
    private bool eyeIsFlipped;
    private Vector3 initPos, initScale;
    private IEnumerator putTheBallInTheEye;
    //private int stretchTime = 2;
    private AudioSource longSuction;
    // Start is called before the first frame update
    void Start()
    {
        transformTheBall = GameObject.Find("TheBall").GetComponent<Transform>();
        transformSurfaceEye = GameObject.Find("SurfaceEye").GetComponent<Transform>();
        transformEye = GameObject.Find("Eye").GetComponent<Transform>();
        initPos = transformEye.position;
        rb = GameObject.Find("TheBall").GetComponent<Rigidbody>();
        initScale = transformTheBall.transform.localScale;
        longSuction = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("TheBall"))
        {
         
            ScoreKeeper.UpdateScore(scoreThisItem);
           // transformTheBall.transform.localScale = new Vector3(.5f, .5f, .5f);
        }
    }
    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.CompareTag("TheBall"))
        {
            eyeIsFlipped = !eyeIsFlipped;
            if (eyeIsFlipped)
            {

                transformSurfaceEye.transform.localRotation = Quaternion.Euler(0f, -180f, 0f);
            }
            else
            {
                transformSurfaceEye.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
             //   Debug.Log("Handle the eye/ball here...");
                transformTheBall.transform.position = initPos;
                rb.constraints = RigidbodyConstraints.FreezeAll;
                putTheBallInTheEye = PutTheBallInTheEye(2f);
                StartCoroutine(putTheBallInTheEye);
              //  longSuction.Play();
            }    

           // Debug.Log("Exited Eye....");
            ScoreKeeper.UpdateScore(scoreThisItem);
          //  transformTheBall.transform.localScale = new Vector3(.32f, .32f, .32f);
        }
    }
    IEnumerator PutTheBallInTheEye(float waitTime)  //waitTime = 2 secs
    {
        float stretch = 0f;
        
        transformTheBall.transform.SetPositionAndRotation(initPos, new Quaternion(0, 0, 0, 0)); //freeze to where ball entered, zero out rotation for stretch on y axis
        longSuction.Play();

        while (stretch < .96f)
        {
            //Debug.Log( " Inside while < .96     " + "Stretch = " +stretch + "  " + Time.fixedDeltaTime);
            stretch += Time.fixedDeltaTime;// * stretchTime;
            transformTheBall.transform.localScale = new Vector3(stretch, stretch, stretch);  
            yield return null;
        }

        while (stretch >= .32f)  //redo this based on POSITION not scale
        {
            //  Debug.Log("Stretch(shrink) = " + stretch + "  " + Time.fixedDeltaTime);
            stretch -= Time.fixedDeltaTime;
            transformTheBall.transform.localScale = new Vector3(stretch, stretch, stretch);
            yield return null;
        }

        yield return new WaitForSeconds(waitTime);
        rb.constraints = RigidbodyConstraints.None;
        transformTheBall.transform.localScale = initScale;
        transformTheBall.transform.position = initPos;  //put it all back for now, and let it drop from the Eye
    }

}
