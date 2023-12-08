using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateUIObject : MonoBehaviour
{
    public float rotateSpeed = 100;
    public bool showDebug = false;

    void OnEnable()   //12/7/23 changed from start cuz we get disabled SetActive(false) when a game ends, then reenabled 
    {
        StartCoroutine(WiggleUIObject());
    }

    IEnumerator WiggleUIObject()
    {
        var rotateAmount = 0f;
        while (true)
        {
            if (ScoreKeeper.gameOver)
            {
                while (rotateAmount < .2f && ScoreKeeper.gameOver)    //.2f is brute forced cuz I don't know the value of rotation.z is determined 
                {
                    transform.Rotate(0f, 0f, rotateSpeed * Time.deltaTime);
                    rotateAmount = transform.rotation.z;
                    if (showDebug) Debug.Log("rotateAmount = " + rotateAmount + "  t.rotation.z = " + transform.rotation.z);
                    yield return null;
                }
                rotateAmount = 0;
                if (showDebug) Debug.Log(" 1st rotate done now the other way?");
                while (rotateAmount >= -.2f && ScoreKeeper.gameOver)
                {
                    transform.Rotate(0f, 0f, - (rotateSpeed * Time.deltaTime));
                    rotateAmount = transform.rotation.z;
                    yield return null;
                }
            }
            yield return null;
        }

    }
    void OnDisable()
    {
        StopAllCoroutines();
    }
}
