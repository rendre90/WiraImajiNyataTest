using UnityEngine;
using UnityEngine.UI;

public class AspectUtility : MonoBehaviour {
     private readonly float newAspectRatio = 1600.0f / 900.0f;
    //private readonly float newAspectRatio = 900.0f / 1600.0f;
    public float variance;
    public float rawVariance;
    public float camAspectNow;
    public CanvasScaler mainCanvasScaler;

    void OnApplicationFocus(){
		SetTheCamera();
	}


    int currentWidth = Screen.width;
    int currentHeight = Screen.height;
    void Start()
    {
        currentWidth = Screen.width;
        currentHeight = Screen.height;
        SetTheCamera();
    }

    void Update()
    {
        if(Screen.width != currentWidth || currentHeight != Screen.height)
        {
            SetTheCamera();
        }
    }

    public void SetTheCamera(){
        SetTheCamera(new Vector2(Screen.width, Screen.height));
    }

    string x;
    string lastX;

    public void SetTheCamera(Vector2 forceResolution){
       Camera cam = GetComponent<Camera>();
        camAspectNow = (float)forceResolution.x / (float)forceResolution.y;
        rawVariance = newAspectRatio / camAspectNow;
        if(camAspectNow > 2.16667f){
            variance = 2.16667f/camAspectNow;   //force the resolution to be 19.5 : 9
        }else{
            variance = newAspectRatio / camAspectNow;   //force the resolution to be 16:9
        }
        if(camAspectNow < 2.16667f){
            if (variance < 1.0f){
                cam.rect = new Rect ((1.0f - variance) / 2.0f, 0 , variance, 1.0f);
                mainCanvasScaler.referenceResolution = new Vector2(1920 / variance, 1080 / variance);
                cam.rect = new Rect(0, 0, 1, 1);
            }
            else{
                variance = 1.0f / variance;
                cam.rect = new Rect (0, (1.0f - variance) / 2.0f , 1.0f, variance);
                mainCanvasScaler.referenceResolution = new Vector2(1920, 1080);
            }
        }
        else{
            cam.rect = new Rect ((1.0f - variance) / 2.0f, 0 , variance, 1.0f);
            mainCanvasScaler.referenceResolution = new Vector2(2340 / variance, 1080 / variance);
        }
        
/*
        if(camAspectNow < 2.16667f && variance > 1){
            cam.rect = new Rect(0, 0, 1, 1);
        }else{
            variance = newAspectRatio / camAspectNow;
            if(variance < 1){
                mainCanvasScaler.referenceResolution = new Vector2(1920 / variance, 1080 / variance);
            }
            else{
                mainCanvasScaler.referenceResolution = new Vector2(1920, 1080);
            }
        }
*/
        Canvas.ForceUpdateCanvases();
       
        
        currentWidth = Screen.width;
        currentHeight = Screen.height;
	}
}