using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuplex.WebView;
using UnityEngine.UI;

public class WebViewController : MonoBehaviour
{
    public WebViewPrefab WebViewPrefab;
    public CanvasWebViewPrefab CanvasWebViewPrefab;


    async void Start()
    {
        // Get a reference to the CanvasWebViewPrefab.
        // https://support.vuplex.com/articles/how-to-reference-a-webview
        // WebViewPrefab = GameObject.Find("WebViewPrefab").GetComponent<WebViewPrefab>();

        // Wait for the prefab to initialize because its WebView property is null until then.
        // https://developer.vuplex.com/webview/WebViewPrefab#WaitUntilInitialized
        
        //await WebViewPrefab.WaitUntilInitialized();
        await CanvasWebViewPrefab.WaitUntilInitialized();

        //WebViewPrefab.WebView.LoadUrl("https://twitter.com");

}

    // Update is called once per frame
    void Update()
    {
        ReadCounter();
    }


    public void Input_ArrowRight()
    {
        CanvasWebViewPrefab.WebView.SendKey("ArrowRight");
        Debug.Log("ページ送り_右");
    }

    public void Input_ArrowLeft()
    {
        CanvasWebViewPrefab.WebView.SendKey("ArrowLeft");
        Debug.Log("ページ送り_左");
    }

    public void Input_Key(string st)
    {
        if(st != ".com")
        {
            CanvasWebViewPrefab.WebView.SendKey(st);
        }
        else
        {
            CanvasWebViewPrefab.WebView.SendKey(".");
            CanvasWebViewPrefab.WebView.SendKey("c");
            CanvasWebViewPrefab.WebView.SendKey("o");
            CanvasWebViewPrefab.WebView.SendKey("m");
        }
        Debug.Log("Debug05" + st);
    }

    /*
    public void Click_L()
    {
        WebViewPrefab.WebView.Click(new Vector2(0.1f, 0.5f), false);
        Debug.Log("左クリック");
    }
    */

    public void InputKey()
    {
        CanvasWebViewPrefab.WebView.SendKey("S");
        Debug.Log("文字入力");
    }

    bool Read_L;
    bool Read_R;

    private float sec;
    public float sec_th;

    public Image ButtonL_Img;
    public Image ButtonR_Img;

    Color button_c = new Color32(197, 197, 197, 255);
    Color buttonpress_c = new Color32(155, 183, 197, 255);

    public void GazeReader(GameObject gameObject)
    {
        if (gameObject.name == "Button_L")
        {
            Read_L = true;
            ButtonL_Img.color = buttonpress_c;
        }
        else
        {
            Read_R = true;
            ButtonR_Img.color = buttonpress_c;
        }


        Debug.Log("test2");
    }

    public void GazeReaderOut()
    {
        Read_L = false;
        Read_R = false;

        ButtonL_Img.color = button_c;
        ButtonR_Img.color = button_c;
    }

    void ReadCounter()
    {
        Debug.Log("test3");
        if (Read_L | Read_R)
        {
            Debug.Log("test4");
            sec += Time.deltaTime;

            if (sec_th <= sec)
            {
                Debug.Log("test5");
                if (Read_L)
                {
                    Debug.Log("test6-1");
                    Input_ArrowLeft();
                }
                else
                {
                    Debug.Log("test6-2");
                    Input_ArrowRight();
                }

                sec = 0f;
                GazeReaderOut();
                Debug.Log("test7");
            }
        }
        
    }
}
