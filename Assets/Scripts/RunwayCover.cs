using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunwayCover : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("RunwayCover Hit... " + collision.GetContact(0).point);
        collision.rigidbody.constraints = RigidbodyConstraints.FreezeAll;    
            
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
