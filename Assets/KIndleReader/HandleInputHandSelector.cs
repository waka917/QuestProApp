/*
 * Copyright (c) Meta Platforms, Inc. and affiliates.
 * All rights reserved.
 *
 * Licensed under the Oculus SDK License Agreement (the "License");
 * you may not use the Oculus SDK except in compliance with the License,
 * which is provided at the time of installation or download, or which
 * otherwise accompanies this software in either electronic or hard copy form.
 *
 * You may obtain a copy of the License at
 *
 * https://developer.oculus.com/licenses/oculussdk/
 *
 * Unless required by applicable law or agreed to in writing, the Oculus SDK
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;

public class HandleInputHandSelector : MonoBehaviour
{
    OVRCameraRig m_CameraRig;
    OVRInputModule m_InputModule;

    public OVRHand hand_L;
    public OVRHand hand_R;

    void Start()
    {
        m_CameraRig = FindObjectOfType<OVRCameraRig>();
        m_InputModule = FindObjectOfType<OVRInputModule>();
    }

    void Update()
    {
        Debug.Log("test08" + m_InputModule.rayTransform);
        if (hand_L.GetFingerIsPinching(OVRHand.HandFinger.Index))
        {
            if (m_InputModule.rayTransform != m_CameraRig.leftHandAnchor)
            {
                SetActiveController(OVRInput.Hand.HandLeft);
            }
        }
        else if (hand_R.GetFingerIsPinching(OVRHand.HandFinger.Index))
        {
            if (m_InputModule.rayTransform != m_CameraRig.rightHandAnchor)
            {
                SetActiveController(OVRInput.Hand.HandRight);
            }
        }
    }

    void SetActiveController(OVRInput.Hand c)
    {
        Transform t;
        if (c == OVRInput.Hand.HandLeft)
        {
            t = m_CameraRig.leftHandAnchor;
        }
        else
        {
            t = m_CameraRig.rightHandAnchor;
        }

        m_InputModule.rayTransform = t;
    }
}