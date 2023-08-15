using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static OVRHand;

public class OculusInput : MonoBehaviour
{
    public Keyboard_UI Keyboard_UI;
    public OVRHand hand_L;
    public OVRHand hand_R;

    public LineRenderer LineRenderer;

    bool pinchi = false;

    [SerializeField]
    GameObject leftController;

    [SerializeField]
    GameObject rightController;

    [SerializeField]
    private float rayDistance = 1.0f;

    public GameObject Controller;
    public WebViewController WebViewController;

    // this is test of VS

    // Start is called before the first frame update.
    void Start()
    {
        Controller = rightController;
    }

    // Update is called once per frame
    void Update()
    {
        var usingHand = OVRInput.IsControllerConnected(OVRInput.Controller.Hands);
        var usingTouch = OVRInput.IsControllerConnected(OVRInput.Controller.RTouch) | OVRInput.IsControllerConnected(OVRInput.Controller.LTouch);

        Debug.Log($"Debug10 usingHand = {usingHand}, usingTouch = {usingTouch}");

        if (usingTouch)
        {   
            if (OVRInput.GetDown(OVRInput.RawButton.LIndexTrigger))
            {
                Controller = leftController;
            }

            if (OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger))
            {
                Controller = rightController;
            }


            RaycastHit hit;
            Vector3 rayCastDirection = Controller.transform.TransformDirection(Vector3.forward) * rayDistance;
            LayerMask layerMask = 1 << LayerMask.NameToLayer("Key") | 1 << LayerMask.NameToLayer("Reader") | 1 << LayerMask.NameToLayer("BG");
            Debug.DrawRay(Controller.transform.position, rayCastDirection, Color.red);
            if (Physics.Raycast(Controller.transform.position, rayCastDirection, out hit, Mathf.Infinity, layerMask))
            {
                Debug.Log("test0-2-1-1" + hit.collider.gameObject.name);

                if (hit.collider.gameObject.tag == "Reader")
                {
                    WebViewController.GazeReader(hit.collider.gameObject);
                    Keyboard_UI.HoverOutCacheKey();
                    Debug.Log("test8-1" + hit.collider.gameObject.name);
                }
                else if (hit.collider.gameObject.tag == "Key")
                {
                    Debug.Log("Debug03-1" + hit.collider.gameObject.name);
                    Keyboard_UI.HitKey(hit.collider.gameObject);
                    WebViewController.GazeReaderOut();
                }
                else
                {
                    Debug.Log("test0-2-2-1");
                    Keyboard_UI.HoverOutCacheKey();
                    WebViewController.GazeReaderOut();
                }
            }

            if (OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger) | OVRInput.GetDown(OVRInput.RawButton.LIndexTrigger))
            {
                Keyboard_UI.PressKey();
            }

            if (OVRInput.GetUp(OVRInput.RawButton.RIndexTrigger) | OVRInput.GetUp(OVRInput.RawButton.LIndexTrigger))
            {
                Keyboard_UI.ReleaseKey();
            }
        }

        
        Debug.Log("Debug05-0-0 " + pinchi);

        if ((hand_L.GetFingerIsPinching(OVRHand.HandFinger.Index) | hand_R.GetFingerIsPinching(OVRHand.HandFinger.Index)) & !pinchi)
        {
            Debug.Log("Debug05-0-1");
            pinchi = true;
            Keyboard_UI.PressKey();
        }
        else if (!(hand_L.GetFingerIsPinching(OVRHand.HandFinger.Index)) & !(hand_R.GetFingerIsPinching(OVRHand.HandFinger.Index)) & pinchi)
        {
            Debug.Log("Debug05-0-2");
            pinchi = false;
            Keyboard_UI.ReleaseKey();
        }

        if (hand_L.IsTracked | hand_R.IsTracked)
        {
            LineRenderer.enabled = false;
        }
        else
        {
            LineRenderer.enabled = true;
        }
    }

}
