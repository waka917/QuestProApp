using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Keyboard_UI : MonoBehaviour
{
    Color key_c = new Color32(221, 221, 221, 255);
    Color hover_c = new Color32(144, 190, 213, 255);
    Color press_c = new Color32(101, 167, 201, 255);

    bool press = false;

    public GameObject Keyboard;
    public GameObject Keyboard_shift;

    public GameObject cacheKey;
    public WebViewController WebViewController;

    string st_bar;
    public TextMeshProUGUI st_bartext;

    public float Press_num;
    public float Press_time;
    public List<RectTransform> PressKey_list = new List<RectTransform>();
    public List<RectTransform> ReleaseKey_list = new List<RectTransform>();

    public GameObject q_key;

    // Start is called before the first frame update
    void Start()
    {
        PressKey_list.Add(q_key.GetComponent<RectTransform>());
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Debug00-0" + cacheKey);
        if (PressKey_list?.Count > 0)
        {
            Debug.Log("Debug05-2");
            if (PressKey_list[0].transform.localPosition.z <= Press_num)
            {
                Debug.Log("Debug05-3 " + PressKey_list[0].localPosition);
                PressKey_list[0].localPosition += new Vector3(PressKey_list[0].localPosition.x, PressKey_list[0].localPosition.y, Press_time) * Time.deltaTime;
            }
            else
            {
                Debug.Log("Debug05-4");
                PressKey_list[0].transform.localPosition = new Vector3(PressKey_list[0].localPosition.x, PressKey_list[0].localPosition.y, Press_num);
                //ReleaseKey_list.Add(q_key.GetComponent<RectTransform>());
                PressKey_list.RemoveAt(0);
                Debug.Log("Debug05-5");
            }
        }

        Debug.Log("Debug06-2" + ReleaseKey_list.Count);
        if (ReleaseKey_list?.Count > 0)
        {
            Debug.Log("Debug06-3");
            if (ReleaseKey_list[0].transform.localPosition.z >= 0)
            {
                Debug.Log("Debug06-4");
                ReleaseKey_list[0].localPosition -= new Vector3(ReleaseKey_list[0].localPosition.x, ReleaseKey_list[0].localPosition.y, Press_time) * Time.deltaTime;
            }
            else
            {
                Debug.Log("Debug06-5");
                ReleaseKey_list[0].transform.localPosition = new Vector3(ReleaseKey_list[0].localPosition.x, ReleaseKey_list[0].localPosition.y, 0.0f);
                ReleaseKey_list.RemoveAt(0);
                Debug.Log("Debug06-6");
            }
        }
    }

    public void HitKey(GameObject key)
    {
        if (press)
        {
            return;
        }

        if(cacheKey == null)
        {
            Debug.Log("Debug00-2");
            cacheKey = key;
            Debug.Log("Debug00-3" + cacheKey);
            Debug.Log("Debug00-4" + key);
        }

        if (cacheKey != key)
        {
            HoverOutKey(cacheKey);
            HoverKey(key);
            cacheKey = key;
        }
    }

    public void HoverKey(GameObject key)
    {
        var Image = key.GetComponent<Image>();
        Image.color = hover_c;
    }

    public void HoverOutKey(GameObject key)
    {
        Debug.Log("Debug00-1");
        var Image = key.GetComponent<Image>();
        Image.color = key_c;
    }

    public void HoverOutCacheKey()
    {
        if (press)
        {
            return;
        }

        if (cacheKey)
        {
            var Image = cacheKey.GetComponent<Image>();
            Image.color = key_c;
        }
    }

    public void PressKey()
    {
        Debug.Log("Debug05-1");
        var Image = cacheKey.GetComponent<Image>();
        Debug.Log("Debug05-1");
        Image.color = press_c;
        Debug.Log("Debug05-1");

        press = true;

        PressKey_list.Add(cacheKey.GetComponent<RectTransform>());
        InputKey(cacheKey);
    }

    public void ReleaseKey()
    {
        var Image = cacheKey.GetComponent<Image>();
        Image.color = key_c;

        press = false;

        Debug.Log("Debug06-1 " + cacheKey.gameObject.name + " " + cacheKey.gameObject.tag);
        ReleaseKey_list.Add(cacheKey.GetComponent<RectTransform>());

        cacheKey = null;
    }

    void PressDown(GameObject gameObject)
    {

    }


    void InputKey(GameObject key)
    {
        string st = key.GetComponentInChildren<TextMeshProUGUI>().text;
        Debug.Log("Debug04" + st);
        change_bar(st);
        WebViewController.Input_Key(st);
    }

    void change_bar(string st)
    {
        if (st == "Backspace")
        {
            st_bar = st_bar.Remove(st_bar.Length - 1);
        }
        else if (st == "Shift")
        {
            Click_Shift();
        }
        else
        {
            st_bar += st;
        }

        st_bartext.text = st_bar;
    }

    void Click_Shift()
    {
        if (Keyboard.activeSelf)
        {
            Keyboard.SetActive(false);
            Keyboard_shift.SetActive(true);
        }
        else
        {
            Keyboard.SetActive(true);
            Keyboard_shift.SetActive(false);
        }
        
    }

}
