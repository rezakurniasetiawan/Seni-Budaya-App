using System.Collections;
using System.IO;
using UnityEngine;

public class ScreenshotHandler : MonoBehaviour
{
    public GameObject alertSuccess;
    private string screenshotPath;
    

    public void CaptureScreenshot()
    {
        StartCoroutine(TakeScreenshotAndSave());
    }

    private IEnumerator TakeScreenshotAndSave()
    {
        yield return new WaitForEndOfFrame();

        // Buat screenshot sebagai Texture2D
        Texture2D screenImage = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        screenImage.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        screenImage.Apply();

        // Konversi ke format PNG
        byte[] imageBytes = screenImage.EncodeToPNG();
        Destroy(screenImage);

        // Tentukan folder penyimpanan di Android (Galeri)
        string fileName = "Screenshot_" + System.DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".png";
        string directory = Application.persistentDataPath; // Default Unity

        if (Application.platform == RuntimePlatform.Android)
        {
            directory = Path.Combine("/storage/emulated/0/Pictures/", "MyGameScreenshots"); // Folder di Galeri Android
        }

        // Buat folder jika belum ada
        if (!Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
        }

        // Tentukan path lengkap
        screenshotPath = Path.Combine(directory, fileName);

        // Simpan file
        File.WriteAllBytes(screenshotPath, imageBytes);
        Debug.Log("Screenshot saved to: " + screenshotPath);

        // Tambahkan ke galeri Android
        if (Application.platform == RuntimePlatform.Android)
        {
            SaveToGallery(screenshotPath);
        }
    }

    private void SaveToGallery(string filePath)
    {
#if UNITY_ANDROID
        AndroidJavaClass mediaScanner = new AndroidJavaClass("android.media.MediaScannerConnection");
        AndroidJavaClass unityActivity = new AndroidJavaClass("com.unity3d.player.UnityPlayer");

        AndroidJavaObject activity = unityActivity.GetStatic<AndroidJavaObject>("currentActivity");
        mediaScanner.CallStatic("scanFile", activity, new string[] { filePath }, null, null);
        Debug.Log("MediaScanner: File added to gallery.");

        alertSuccess.SetActive(true);
#endif
    }
}
