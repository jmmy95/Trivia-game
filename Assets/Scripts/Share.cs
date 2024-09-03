
#if UNITY_STANDALONE || UNITY_EDITOR
using System.Collections;
using System.Diagnostics;
#endif
using System.IO;
using UnityEngine;

public class Share : MonoBehaviour
{
    private IEnumerator share()
    {
        yield return new WaitForEndOfFrame();

        Texture2D imageData = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        imageData.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        imageData.Apply();

        string filePath = Path.Combine(Application.persistentDataPath, "finalscore_patriots.png");
        File.WriteAllBytes(filePath, imageData.EncodeToPNG());

        #if UNITY_STANDALONE || UNITY_EDITOR
        // this opens the location where thd screensot is saved
        Process.Start(new ProcessStartInfo()
        {
            FileName = Application.persistentDataPath,
            UseShellExecute = true,
            Verb = "open"
        });
        #endif

        Destroy(imageData);
    }

    public void screenshotAndShare()
    {
        StartCoroutine(share());
    }
}
