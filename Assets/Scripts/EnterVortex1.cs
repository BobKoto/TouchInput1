using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnterVortex1 : MonoBehaviour
{
    public int scoreThisItem = 45;
    private Transform transformTheBall;
    private Rigidbody rb;
    private AudioSource longSuction;
    private IEnumerator coroutine, vortexTogglingLoop, vortexSliderLoop;
    private Vector3 initPos, initScale;
    private bool vortexActive;
    private int stretchTime = 10;
    private MeshRenderer meshRenderer;
    private GameObject vortexLabel;
    private Slider newVortexSlider;
    // Start is called before the first frame update
    void Start()
    {
        longSuction = GetComponent<AudioSource>();
        transformTheBall = GameObject.Find("TheBall").GetComponent<Transform>();
        rb = GameObject.Find("TheBall").GetComponent<Rigidbody>();
        initScale = transformTheBall.transform.localScale;
       // initPos = transform.position; //For centering the ball and prevent repetitive triggering  //MOVED TO OnTriggerEnter
        meshRenderer = GameObject.Find("CylinderWhite").GetComponent<MeshRenderer>();
        meshRenderer.material.DisableKeyword("_EMISSION");
      //  vortexSlider = GameObject.Find("VortexSlider").GetComponent<Slider>();
        newVortexSlider = GameObject.Find("VortexTimer").GetComponent<Slider>();
        vortexLabel = GameObject.Find("VortexLabel");
        vortexSliderLoop = VortexSliderLoop(1f);
        StartCoroutine(vortexSliderLoop);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("TheBall")  && vortexActive)
        {
            ScoreKeeper.UpdateScore(scoreThisItem);
            initPos = transform.position;
            transformTheBall.transform.position = initPos;
            rb.constraints = RigidbodyConstraints.FreezeAll;
            coroutine = HandleTheBall(2f);
            StartCoroutine(coroutine);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("TheBall"))
        {
            transformTheBall.transform.localScale = new Vector3(.32f, .32f, .32f);   //maybe duplicating/redundant with HandleTheBall
        }
    }
    IEnumerator HandleTheBall(float waitTime)  //waitTime = 2 secs
    {
        float stretch = 1f;
        transformTheBall.transform.SetPositionAndRotation(initPos, new Quaternion(0, 0, 0, 0)); //freeze to where ball entered, zero out rotation for stretch on y axis
        longSuction.Play();
      //  transformTheBall.transform.position = new Vector3(transformTheBall.position.x, transformTheBall.position.y + .3f, transformTheBall.position.z); //Raise ball
        while (stretch < 4.9f )
        {
           transformTheBall.transform.localScale = new Vector3(.32f, (.32f +  stretch) * Time.fixedDeltaTime * stretchTime, .32f); //stretch on y axis
           stretch += transformTheBall.transform.localScale.y - Time.fixedDeltaTime * stretchTime;
        //    Debug.Log("Stretch = " +stretch + "  " + Time.fixedDeltaTime);
           yield return null;
        }

        while (stretch >= .32f)  //redo this based on POSITION not scale
        {
            transformTheBall.transform.localScale = new Vector3(.32f, (.32f - stretch) * Time.fixedDeltaTime * stretchTime, .32f); //shrink on y axis
            stretch += transformTheBall.transform.localScale.y - Time.fixedDeltaTime * stretchTime;
          //  Debug.Log("Stretch(shrink) = " + stretch + "  " + Time.fixedDeltaTime);
            yield return null;
        }


        //   transformTheBall.transform.position = new Vector3(transformTheBall.position.x, transformTheBall.position.y + .2f, transformTheBall.position.z); //raise ball

        yield return new WaitForSeconds(waitTime);
        rb.constraints = RigidbodyConstraints.None;

        
        transformTheBall.transform.localScale = initScale;
        transformTheBall.transform.position = initPos;  //put it all back for now,  later teleport somewhere random? free shot?
    }
    IEnumerator VortexSliderLoop(float seconds)  //seconds = 1
    {
        bool countingDown = false;
        bool gameJustEnded = false;
        int secondsWaited = 0;
        vortexActive = false;  //Used in OnTriggerEnter

        while (true)
        {
            if (!ScoreKeeper.gameOver)
            {
                gameJustEnded = false;
                if (!countingDown) secondsWaited ++;  //secondsWaited and vortex slider should always be in synch, right?
                else secondsWaited--;
              //  vortexSlider.value = secondsWaited;
                newVortexSlider.value = secondsWaited;

                if (secondsWaited >= 10)
                {
                    countingDown = true;
                    vortexActive = true;
                    vortexLabel.SetActive(true);
                    meshRenderer.material.EnableKeyword("_EMISSION"); //The visible sliver of the WhiteCylinder in the Vortex
                }
                   
                if (secondsWaited <= 0)  //OR 
                {
                    countingDown = false;
                    vortexActive = false;
                    meshRenderer.material.DisableKeyword("_EMISSION");
                    vortexLabel.SetActive(false);
                }
            }
            if (ScoreKeeper.gameOver)
            {
                if (!gameJustEnded)
                { 
                    vortexActive = false;
                    secondsWaited = 0;
                 //   vortexSlider.value = secondsWaited;
                    newVortexSlider.value = secondsWaited;
                    vortexLabel.SetActive(false);
                    gameJustEnded = true;  //so we just do this block once
                    countingDown = false;
                }
            }
            yield return new WaitForSeconds(seconds);
        }//wtru
    }//ie
    private void OnDisable()
    {
        {
            StopAllCoroutines();
        }
    }
}
//IEnumerator VortexSliderLoop(float seconds)  //seconds = 1
//{
//    bool reverseSlider = false;
//    bool gameJustEnded = false;
//    int secondsWaited = 0;

//    vortexActive = false;
//    //assume we start with slider left-to-right and waited for 0 seconds

//    while (true)
//    {
//        if (!ScoreKeeper.gameOver)
//        {
//            gameJustEnded = false;
//            secondsWaited += 1;  //secondsWaited and vortex slider should always be in synch, right?
//            vortexSlider.value = secondsWaited;

//            if (secondsWaited >= 10)
//            {
//                reverseSlider = !reverseSlider;
//                secondsWaited = 0;
//                vortexSlider.value = secondsWaited;

//                if (!reverseSlider)  //OR 
//                {
//                    vortexActive = true;
//                    vortexSlider.direction = Slider.Direction.RightToLeft; //vortex is active &so start counting down
//                    vortexLabel.SetActive(true);
//                    meshRenderer.material.EnableKeyword("_EMISSION");
//                }
//                else
//                {
//                    vortexActive = false;
//                    vortexSlider.direction = Slider.Direction.LeftToRight;
//                    meshRenderer.material.DisableKeyword("_EMISSION");
//                    vortexLabel.SetActive(false);
//                }
//            }
//        }
//        if (ScoreKeeper.gameOver)
//        {
//            if (!gameJustEnded)
//            {
//                vortexActive = false;
//                secondsWaited = 0;
//                vortexSlider.value = secondsWaited;
//                vortexSlider.direction = Slider.Direction.LeftToRight;
//                vortexLabel.SetActive(false);
//                gameJustEnded = true;  //so we just do this block once
//                reverseSlider = !reverseSlider;
//            }
//        }
//        yield return new WaitForSeconds(seconds);
//    }//wtru
//}//ie