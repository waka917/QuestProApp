using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuplex.WebView;
using UnityEngine.UI;

public class WebViewController : MonoBehaviour
{
    public WebViewPrefab WebViewPrefab;
    public CanvasWebViewPrefab CanvasWebViewPrefab;
    string URL;


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


        // amazon_domain
        // 1 : JP
        // 2 : US

        if (PlayerPrefs.HasKey("amazon_domain"))
        {
            URL = PlayerPrefs.GetString("amazon_domain");
        }
        else
        {
            PlayerPrefs.SetString("amazon_domain", "https://read.amazon.co.jp/kindle-library");
            URL = PlayerPrefs.GetString("amazon_domain");
            URL = "https://www.google.com";
            //https://www.google.com
        }

        Debug.Log("Debug09" + URL);
        CanvasWebViewPrefab.WebView.LoadUrl(URL);
    }

    async void Awake() 
    {
        await CanvasWebViewPrefab.WaitUntilInitialized();
        //await CanvasWebViewPrefab.WebView.WaitForNextPageLoadToFinish();

        //Webロード終了トリガー
        CanvasWebViewPrefab.WebView.LoadProgressChanged += (sender, eventArgs) => {
            Debug.Log($"Load progress changed: {eventArgs.Type}, {eventArgs.Progress}");
            if (eventArgs.Type == ProgressChangeType.Finished) {
                Debug.Log("The page finished loading");
                //html改変
                //Invoke("deletehtml", 7f);
            }
        };
    }

    // Update is called once per frame
    void Update()
    {
        ReadCounter();
        Debug.Log("Debug10-4 " + CanvasWebViewPrefab.Resolution);
    }

    public void Input_ArrowRight()
    {
        CanvasWebViewPrefab.WebView.Click(new Vector2(0.875f, 0.5f));
        //CanvasWebViewPrefab.WebView.SendKey("ArrowRight");
        Debug.Log("ページ送り_右");
    }

    public void Input_ArrowLeft()
    {
        CanvasWebViewPrefab.WebView.Click(new Vector2(0.125f, 0.5f));
        //CanvasWebViewPrefab.WebView.SendKey("ArrowLeft");
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

    public void load_amazonUS()
    {
        float resolution = 2.95f;
        Debug.Log("Debug10-1 " + resolution);

        CanvasWebViewPrefab.WebView.LoadUrl("https://read.amazon.com/kindle-library");
        PlayerPrefs.SetString("amazon_domain", "https://read.amazon.com/kindle-library");

        CanvasWebViewPrefab.Resolution = resolution;
        Debug.Log("Debug10-2 " + CanvasWebViewPrefab.Resolution);
    }

    public void load_amazonJP()
    {
        float resolution = 2.95f;
        Debug.Log("Debug10-1 " + resolution);

        CanvasWebViewPrefab.WebView.LoadUrl("https://read.amazon.co.jp/kindle-library");
        PlayerPrefs.SetString("amazon_domain", "https://read.amazon.co.jp/kindle-library");

        CanvasWebViewPrefab.Resolution = resolution;
        Debug.Log("Debug10-2 " + CanvasWebViewPrefab.Resolution);
    }

    void deletehtml()
    {
        Debug.Log("Debug11");
        CanvasWebViewPrefab.WebView.ExecuteJavaScript("document.getElementById('kr-chevron-left').remove()");
        //CanvasWebViewPrefab.WebView.ExecuteJavaScript("document.getElementById('kr-chevron-left').parentNode.remove()");
        //CanvasWebViewPrefab.WebView.ExecuteJavaScript("document.getElementById('kr-chevron-left').classList.add('hidden')");
        //CanvasWebViewPrefab.WebView.ExecuteJavaScript("document.getElementsByClassName('chevron block right').classList.add('hidden')");
        //CanvasWebViewPrefab.WebView.ExecuteJavaScript("document.getElementsByClassName('kw-overlay-fade-enter-done').style.display='none'");
    }

    
}
