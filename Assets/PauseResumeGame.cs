using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PauseResumeGame : MonoBehaviour
{
    private bool isPaused = false;
    private Button pauseButton;

    void Start()
    {
        pauseButton = GetComponent<Button>();
        pauseButton.onClick.AddListener(TogglePause);
    }

    void TogglePause()
    {
        // Toggle between paused and unpaused states
        isPaused = !isPaused;

        // Set time scale based on the state
        Time.timeScale = isPaused ? 0 : 1;

        DoPauseResume();
    }
    void DoPauseResume()
    {
        // Update the button text based on the state
        pauseButton.GetComponentInChildren<TMP_Text>().text = isPaused ? "Resume" : "Pause";

        if (isPaused)
        {
            //Pause the background audio
            ScoreKeeper.audioBackground.Pause();

            // Get the ColorBlock of the button
            ColorBlock colorBlock = pauseButton.colors;

            // Change the normal color to green when the button is clicked
            colorBlock.normalColor = Color.green;

            // Apply the modified ColorBlock back to the button
            pauseButton.colors = colorBlock;
        }
        else
        {
            //Resume the background audio
            ScoreKeeper.audioBackground.Play();

            // Get the ColorBlock of the button
            ColorBlock colorBlock = pauseButton.colors;

            // Change the normal color to red when the button is clicked
            colorBlock.normalColor = Color.red;

            // Apply the modified ColorBlock back to the button
            pauseButton.colors = colorBlock;
        }
    }
}
