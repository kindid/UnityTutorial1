using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ImageWebCam : MonoBehaviour
{
    // This is bound in the editor. Note also the "unlit/textured" shader/material
    public RawImage rawimage;
    // todo;basically private except it isn't.
    // this one is set from within. be cautious of 
    public WebCamTexture webcamTexture;
    //
    void Start()
    {
        var devices = WebCamTexture.devices;
        var camName = "";
        if (devices.Length > 0) camName = devices[0].name;
        for (int i = 0; i < devices.Length; i++)
        {
            // just so you know
            Debug.Log(i.ToString() + " name = " + devices[i].name + " isFrontFacing = " + devices[i].isFrontFacing.ToString());
            // yeah, this was fun. not really a very good test TBH
            if (devices[i].isFrontFacing || devices[i].name.EndsWith("(Built-in)"))
            {
                camName = devices[i].name;
                break;
            }
        }
        // PLZ make sure you pass a decent framerate. The default on my machine was 5fps.
        webcamTexture = new WebCamTexture(camName, 640, 480, 30);
        rawimage.texture = webcamTexture;
        rawimage.material.mainTexture = webcamTexture;
        // Start capturing. You'll find out how slow camera open/close is too! (Switch scenes)
        webcamTexture.Play();
    }
}

