using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravitySet : MonoBehaviour
{
    [SerializeField]
    private float sceneGravity = -9.81f;
    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity = new Vector3(0, sceneGravity, 0);
    }
}
