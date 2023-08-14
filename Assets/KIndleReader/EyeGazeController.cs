using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

[RequireComponent(typeof(LineRenderer))]
public class EyeGazeController : MonoBehaviour
{
    [SerializeField]
    private float rayDistance = 1.0f;
    [SerializeField]
    private float raywidth = 0.01f;
    [SerializeField]
    private LayerMask layersToInclude;
    [SerializeField]
    private Color rayColorDefaultState = Color.yellow;
    [SerializeField]
    private Color rayColorHoverState = Color.red;
    private List<EyeInteractable> eyeInteractables = new List<EyeInteractable>();


    private Vector3 _startPoint;
    private Vector3 _forward;
    private Vector3 _endPoint;
    private LineRenderer lineRenderer;

    public GameObject cursorVisual;

    public float maxLength = 10.0f;

    public Keyboard_UI Keyboard_UI;
    public WebViewController WebViewController;

    // Start is called before the first frame update
    void Start()
    {
        if (cursorVisual) cursorVisual.SetActive(false);
        lineRenderer = GetComponent<LineRenderer>();
        SetupRay();
    }


    void SetupRay()
    {
        lineRenderer.useWorldSpace = false;
        lineRenderer.positionCount = 2;
        lineRenderer.startWidth = raywidth;
        lineRenderer.endWidth = raywidth;
        lineRenderer.startColor = rayColorDefaultState;
        lineRenderer.endColor = rayColorDefaultState;
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, new Vector3(transform.position.x, transform.position.y, transform.position.z + rayDistance));
    }



    void FixedUpdate()
    {   
        Debug.Log("test0-1");

        var usingHand = OVRInput.IsControllerConnected(OVRInput.Controller.Hands);
        if (!usingHand)
        {
            return;
        }

        RaycastHit hit;
        Vector3 rayCastDirection = transform.TransformDirection(Vector3.forward) * rayDistance;
        LayerMask layerMask = 1 << LayerMask.NameToLayer("Key")| 1 << LayerMask.NameToLayer("Reader");

        if (Physics.Raycast(transform.position, rayCastDirection, out hit, Mathf.Infinity, layerMask))
        {
            /*
            UnSelect();
            lineRenderer.startColor = rayColorHoverState;
            lineRenderer.endColor = rayColorHoverState;
            var eyeInteractable = hit.transform.GetComponent<EyeInteractable>();
            eyeInteractables.Add(eyeInteractable);
            eyeInteractable.IsHovered = true;
            */

            Debug.Log("test0-2-1" + hit.collider.gameObject.name);
            _startPoint = transform.position;
            _endPoint = hit.point;

            if (hit.collider.gameObject.tag == "Reader")
            {
                Debug.Log("test1");
                //ReadController ReadController = hit.collider.gameObject.GetComponent<ReadController>();
                WebViewController.GazeReader(hit.collider.gameObject);
                Debug.Log("test8" + hit.collider.gameObject.name);

                Keyboard_UI.HoverOutCacheKey();
            }
            else if (hit.collider.gameObject.tag == "Key")
            {
                //キーボードの場合の処理
                Debug.Log("Debug03" + hit.collider.gameObject.name);
                Keyboard_UI.HitKey(hit.collider.gameObject);

                WebViewController.GazeReaderOut();
            }
            else
            {
                Debug.Log("test0-2-2");
                Keyboard_UI.HoverOutCacheKey();
                WebViewController.GazeReaderOut();
            }

            Debug.Log("Debug01" + _endPoint);
            if (cursorVisual)
            {
                cursorVisual.transform.position = _endPoint;
                cursorVisual.SetActive(true);
                Debug.Log("Debug02" + cursorVisual.transform.position);
            }

            /*

            //キーボードの場合の処理
            if (hit.collider.gameObject.tag == "Key")
            {
                Debug.Log("Debug03" + hit.collider.gameObject.name);
                Keyboard_UI.HitKey(hit.collider.gameObject);
            }
            else
            {
                Keyboard_UI.HoverOutCacheKey();
            }
            */
        }
        else
        {
            // Keyレイヤーにhitしなかった場合
            Debug.Log("test0-2-3");
            //Keyboard_UI.HoverOutCacheKey();
            //WebViewController.GazeReaderOut();


            /*
            lineRenderer.startColor = rayColorDefaultState;
            lineRenderer.endColor = rayColorDefaultState;
            UnSelect(true);
            */

            _startPoint = transform.position;
            _forward = transform.forward;

            //if (cursorVisual) cursorVisual.SetActive(false);
        }
    }

    void UnSelect(bool clear = false)
    {
        foreach (var interactable in eyeInteractables)
        {
            interactable.IsHovered = false;
        }
        if (clear)
        {
            eyeInteractables.Clear();
        }
    }





    void OnDisable()
    {
        if (cursorVisual) cursorVisual.SetActive(false);
    }



}
