using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameInit : MonoBehaviour
{
    private void Awake()
    {
        StartCoroutine(Load());
    }
    IEnumerator Load()
    {

#if UNITY_ANDROID
        Handheld.SetActivityIndicatorStyle(AndroidActivityIndicatorStyle.Large);  //Not sure the #if works here.
        Handheld.StartActivityIndicator();  //11//26/23 moved here where it belongs - 

#endif

        yield return new WaitForSeconds(0);
        SceneManager.LoadScene("TestLab");
    }

}
