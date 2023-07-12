using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundController : MonoBehaviour
{
    float speed = 3;
    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }
}