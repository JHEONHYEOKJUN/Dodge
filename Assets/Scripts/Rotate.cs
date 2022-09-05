using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float rotateSpeed = 60f;

    void FixedUpdate()
    {
        transform.Rotate(0f,rotateSpeed * Time.deltaTime,0f);
    }
}
