using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR;

public class Pin : MonoBehaviour
{
    public Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public bool CheckFall()
    {
        Vector3 up = transform.up;
        float angle = Math.Abs(Vector3.Angle(up, Vector3.up));

        return angle > 45f;
    }
}
