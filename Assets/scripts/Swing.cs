using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swing : MonoBehaviour
{
    public float arc = 90f;
    public float rotationSpeed = 2f;
    public Vector3 axis;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
transform.rotation = Quaternion.Euler(axis*arc *Mathf.Sin(Time.time*rotationSpeed));
    }
}
