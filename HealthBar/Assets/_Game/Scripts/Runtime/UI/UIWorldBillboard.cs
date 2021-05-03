using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class UIWorldBillboard : MonoBehaviour
{
    private Camera Cam => cam == null ? (cam = Camera.main) : cam;
    private Camera cam;

    private void LateUpdate()
    {
        transform.LookAt(transform.position + Cam.transform.forward, Cam.transform.rotation * Vector3.up);
    }
}
