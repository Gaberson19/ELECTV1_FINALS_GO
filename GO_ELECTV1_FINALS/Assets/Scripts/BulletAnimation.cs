using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletAnimation : MonoBehaviour
{
    public float turnSpeed;

    // Start is called before the first frame update
    void Start()
    {
        transform.Rotate(Vector3.right * 45);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * turnSpeed);
    }
}
