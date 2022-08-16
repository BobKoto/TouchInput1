using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinchDetection : MonoBehaviour
{
    [SerializeField]
    float camSpeed = 4f;

    private TouchControls controls;
    private Transform cameraTransform;
    private Coroutine zoomCoroutine;

    private void Awake()
    {
        controls = new TouchControls();
        cameraTransform = Camera.main.transform;
    }
    private void OnEnable()
    {
        controls.Enable();
    }
    private void OnDisable()
    {
        controls.Disable();
    }
    private void Start()
    {
        controls.Touch.SecondaryTouchContact.started += _ => ZoomStart();
        controls.Touch.SecondaryTouchContact.canceled += _ => ZoomEnd();
    }
    private void ZoomStart()
    {
        zoomCoroutine = StartCoroutine(ZoomDetection());
    }
    private void ZoomEnd()
    {
        StopCoroutine(zoomCoroutine); 
    }

    IEnumerator ZoomDetection()
    {
        float previousDistance = 0f, distance = 0f;
        float camPositionY = cameraTransform.position.y;
        while (true)
        {
            distance = Vector2.Distance(controls.Touch.PrimaryFingerPosition.ReadValue <Vector2>(),
                                        controls.Touch.SecondaryFingerPosition.ReadValue<Vector2>());


            if (distance > previousDistance)
            {
                Vector3 targetPosition = cameraTransform.position;
                targetPosition.z += 1;
                cameraTransform.position = Vector3.Lerp(cameraTransform.position,
                                                          targetPosition,
                                                          Time.deltaTime * camSpeed);  

                
            }
            else if (distance < previousDistance)
            {
                Vector3 targetPosition = cameraTransform.position;
                targetPosition.z -= 1;
                cameraTransform.position = Vector3.Lerp(cameraTransform.position,
                                                           targetPosition,
                                                           Time.deltaTime * camSpeed);  
            }
            previousDistance = distance;
            yield return null;
        }
    }
}
