using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Blink1 : MonoBehaviour
{
    public float blinkRate = 1f;
    private MeshRenderer meshRenderer;
    //private Color dimColor = Color.HSVToRGB(0.68f, 0.688f, 0.2f);
    //private Color brightColor = Color.HSVToRGB(0.94f, 0.95f, 0.031f);
    //private Color dimColor = Color.HSVToRGB(61,70, 69);
    //private Color brightColor = Color.HSVToRGB(61, 95, 95);
    //private Color dimColor = Color.HSVToRGB(174,176, 62);
    //private Color brightColor = Color.HSVToRGB(237, 241, 18);//NONE of above seem to work
    private Color myColor;
    private IEnumerator coroutine;
    private int iColor;

    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
              // myColor = meshRenderer.material.EnableKeyword("_EmisColor");
      //  iColor = Shader.PropertyToID("_EmisColor");
      //  myColor = meshRenderer.material.GetColor(iColor);
                                                           // iColor.//myColor = meshRenderer.material.GetColor()
        //Debug.Log("icolor value..." + meshRenderer.material.GetColor(iColor) );
       // Debug.Log("brightColor value..." + brightColor + "   dimColor value..." + dimColor);
        //meshRenderer.material.SetColor(iColor, Color.HSVToRGB(0.68f,0.688f,0.2f,true));                        //R(0.940, 0.953, 0.031, 0.0);
        //meshRenderer.material.SetColor(iColor, RG
        coroutine = BlinkBumper(blinkRate);
        StartCoroutine(coroutine);
    }
    IEnumerator BlinkBumper(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
           // meshRenderer.material.SetColor(iColor, Color.yellow);                                           
                                                      // meshRenderer.material.color = Color.yellow;
           
                   //   Debug.Log("Set Yellow Bright...  "  + Color.yellow);
             meshRenderer.material.EnableKeyword("_EMISSION");
            yield return new WaitForSeconds(waitTime);
            //meshRenderer.material.SetColor(iColor, myColor);
                    //  Debug.Log("Set myColor Dim... " + myColor);
                                                           // meshRenderer.material.color = Color.white;
             meshRenderer.material.DisableKeyword("_EMISSION");
        }
    }  
    void OnDisable()
    {
       if (coroutine != null)
        StopCoroutine(coroutine);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
