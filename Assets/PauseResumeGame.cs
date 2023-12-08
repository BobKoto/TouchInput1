using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PauseResumeGame : MonoBehaviour
{
    private bool isPaused = false;
    private Button pauseButton;

    void Start()
    {
        // Assuming you have a button with this script attached
        pauseButton = GetComponent<Button>();

        // Attach the button click event
        pauseButton.onClick.AddListener(TogglePause);
    }

    void TogglePause()
    {
        // Toggle between paused and unpaused states
        isPaused = !isPaused;

        // Set time scale based on the state
        Time.timeScale = isPaused ? 0 : 1;

        // Update the button text based on the state
        pauseButton.GetComponentInChildren<TMP_Text>().text = isPaused ? "Resume" : "Pause";
    }
}
