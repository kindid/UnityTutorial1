using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScriptIntro : MonoBehaviour
{
    // bound in editor
    public RawImage rawImage;
    // "bound" in "Start" via Find.
    ImageWebCam imageWebCam;

    void Start()
    {
        // Remember, already bound. Note the really sweet name binding with type. How cool is that?
        // We didn't even need to search with "DeviceCamera" or "ViewFinder" strings
        imageWebCam = rawImage.GetComponent<ImageWebCam>();
    }

    void Update()
    {
        // frame tick..nothing yet... Time.deltaTime
    }

    public void GotoMain()  
    {
        // switcharoo
        SceneManager.LoadScene(sceneName: "SceneMain");
    }

    public void GetImage()
    {
        // todo; sanity check imageWebCam
        Texture2D texture = new Texture2D(
            imageWebCam.webcamTexture.width,
            imageWebCam.webcamTexture.height,
            TextureFormat.ARGB32,
            false);
        // copy (note, this goes via CPU array of colors?)
        texture.SetPixels(imageWebCam.webcamTexture.GetPixels());
        // no idea
        texture.Apply();
        // 
        byte[] bytes = texture.EncodeToPNG();
        //
        G.g.connection.Insert(new FrameData { pic = bytes });
    }
}


#if false
        // write. plz use  "Application.dataPath + $path"
        // this is just testin'
        File.WriteAllBytes("/Users/kuiash/tmp/testimg.png", bytes);
#else
// write it to SQLite - naturally a good programmer hides this behind bizlogick

#endif
