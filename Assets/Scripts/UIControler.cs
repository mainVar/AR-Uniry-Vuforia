using System.Collections;
using UnityEngine;
using System;


public class UIControler : MonoBehaviour
{
    [SerializeField] public GameObject PhotoButt;
    public GameObject ShareButt;
    public GameObject BackButt;
    public GameObject SettingButt;
    public GameObject SoundOffButt;
    public GameObject SoundOnButt;

    public void SettingsButt()
    {
        PhotoButt.SetActive(!PhotoButt.activeSelf);
    }

    public void SoundOFF()
    {
        AudioListener.pause = !AudioListener.pause;
        SoundOffButt.SetActive(false);
        SoundOnButt.SetActive(true);
    }

    public void SoundON()
    {
        AudioListener.pause = !AudioListener.pause;
        SoundOnButt.SetActive(false);
        SoundOffButt.SetActive(true);
    }

    public void OnClickScreenCaptureButton()
    {
        StartCoroutine(CaptureScreen());
        PhotoButt.SetActive(false);
        SettingButt.SetActive(false);
        ShareButt.SetActive(true);
        BackButt.SetActive(true);
    }

    public void OnClicBackButt()
    {
        PhotoButt.SetActive(true);
        SettingButt.SetActive(true);
        ShareButt.SetActive(false);
        BackButt.SetActive(false);
    }

    public void OnClicShareButt()
    {
        PhotoButt.SetActive(true);
        SettingButt.SetActive(true);
        ShareButt.SetActive(false);
        BackButt.SetActive(false);
    }

    public IEnumerator CaptureScreen()
    {
        // Wait till the last possible moment before screen rendering to hide the UI
        yield return null;
        GameObject.Find("Canvas").GetComponent<Canvas>().enabled = false;

        // Wait for screen rendering to complete
        yield return new WaitForEndOfFrame();

        ScreenCapture.CaptureScreenshot("screenshot.png");

        Texture2D ss = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        ss.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        ss.Apply();

        // NativeGallery.SaveImageToGallery(ss, "Screenshot", DateTime.Now.ToString().Replace("/", "-"));
        //  NativeGallery.SaveImageToGallery(ss, "Screenshot", "screenshot"+ ScreenCounter+".png");
        NativeGallery.SaveImageToGallery(ss, "Screenshot",
            "screenshot" + DateTime.Now.ToString().Replace("/", "-") + ".png");

        // To avoid memory leaks
        Destroy(ss);
        GameObject.Find("Canvas").GetComponent<Canvas>().enabled = true;
    }


    public void ExitGame()
    {
        Application.Quit();
    }
}