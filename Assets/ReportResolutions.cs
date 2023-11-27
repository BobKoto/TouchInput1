using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReportResolutions : MonoBehaviour
{
    [System.Obsolete]
    void Start()
    {
        Resolution[] resolutions = Screen.resolutions;

        // Print the resolutions
        foreach (var res in resolutions)
        {
            Debug.Log(message: $"{res.width}x{res.height} : {res.refreshRate}");
        }
    }
}
