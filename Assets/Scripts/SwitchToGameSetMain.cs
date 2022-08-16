using UnityEngine;
//using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
//using UnityEngine.UI;
//using UnityEngine.UIElements;
//using Slider = UnityEngine.UIElements.Slider;

public class SwitchToGameSetMain : MonoBehaviour
{
    private void Start()
    {

    }

    public void OnButtonMainPress()
    {
        SceneManager.LoadScene("GameSetScene");
      //  Debug.Log("Main pressed....");
    }
    
}