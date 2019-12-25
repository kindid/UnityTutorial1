using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScriptMain : MonoBehaviour
{
    //
    public RawImage rawImage;

    // Start is called before the first frame update
    void Start()
    {
        var frameData = G.g.connection.Table<FrameData>().OrderByDescending(x => x.id).FirstOrDefault();
        //
        if (frameData != null && rawImage != null)
        {
            Texture2D texture = new Texture2D(2, 2);
            texture.LoadImage(frameData.pic);
            rawImage.GetComponent<RawImage>().texture = texture;
        }
    }

#if false
            // just for testing
            File.WriteAllBytes("/Users/kuiash/tmp/testimg_out.png", frameData.pic);
#endif


    void Update()
    {
        // notickyet        
    }

    public void GotoIntro()
    {
        // naturally it could be argued that this should be done in the global scripts.
        // It is possible, but hard, to layer various features on a GO and manage to communicate
        SceneManager.LoadScene(sceneName: "SceneIntro");
    }
}
