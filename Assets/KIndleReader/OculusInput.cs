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

    // this is test of VS

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Debug05-0-0 " + pinchi);
        if (OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger))
        {
            Keyboard_UI.PressKey();
        }

        if (OVRInput.GetUp(OVRInput.RawButton.RIndexTrigger))
        {
            Keyboard_UI.ReleaseKey();
        }

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
