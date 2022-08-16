using UnityEngine;
//using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
//using UnityEngine.UI;
//using UnityEngine.UIElements;
//using Slider = UnityEngine.UIElements.Slider;

public class GameSet : MonoBehaviour
{
    GameObject and, win;
    private void Start()
    {
        Debug.Log("Hello from GameSet...");
        and = GameObject.Find("SphereIsAndroid");
        win = GameObject.Find("CubeIsWindows");
        and.SetActive(false);
        win.SetActive(false);
        if (Application.platform == RuntimePlatform.Android)
        {
            and.SetActive(true);
            Debug.Log("Android detected.");
        }

        else
        {
            Debug.Log("Android NOT detected.  " + Application.platform);
            win.SetActive(true);
        }
     //   Debug.Log(" ScenesLoaded = " + SceneManager.sceneCount);
     //   Input.backButtonLeavesApp = true;  //doesnt work?
    }

    public void OnButtonSwipePress()
    {
        SceneManager.LoadScene("Mobile1Swipe");
    }
    public void OnButtonZoomPress()
    {
        SceneManager.LoadScene("Mobile2Zoom");
    }
    public void OnButtonPinballPress()
    {
        SceneManager.LoadScene("Mobile3Pinball");
    }
    public void OnButtonTestLabPress()
    {
        SceneManager.LoadScene("TestLab");
    }
}
