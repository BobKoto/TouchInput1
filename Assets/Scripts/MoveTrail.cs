using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTrail : MonoBehaviour
{
    private Coroutine coroutine;
    private bool moveTrail2Started;
    [SerializeField]
    private GameObject t2;

    // Start is called before the first frame update
    void Start()
    {
        

        transform.position = Vector3.zero;
        //coroutine = StartCoroutine("MoveTrail2");
    }

    // Update is called once per frame
   /*
    void FixedUpdate()
    {
        if (!moveTrail2Started)
        {
           // t2.SetActive(true);
            transform.position = Vector3.zero;
            coroutine = StartCoroutine("MoveTrail2");
            moveTrail2Started = true;

        }
        if (transform.position.x > 5f)
        { 
           // transform.position = Vector3.zero;  //takes Trail with it
            StopCoroutine(coroutine);
           // t2.SetActive(false);
           // moveTrail2Started = false;
            
           //Debug.Log("UPDATE transPos  " + transform.position);
           // StartCoroutine("MoveTrail2");
        }
    }


    private IEnumerator MoveTrail2()
    {
        while (true)
        {
            transform.position =  new Vector3 (transform.position.x + 1f, transform.position.y , 0);
        
       
            Debug.Log("COR transPos  " + transform.position );
           yield return null;
           // yield return new WaitForSeconds(.6f);

        }
    } */
}
