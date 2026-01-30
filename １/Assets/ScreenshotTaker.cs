using UnityEngine;

public class ScreenshotTaker : MonoBehaviour
{
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            string fileName = "Screenshot_" + System.DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".png";
            ScreenCapture.CaptureScreenshot(fileName);

            Debug.Log("•Û‘¶‚µ‚Ü‚µ‚½:" + fileName);
        }
        
    }
}
