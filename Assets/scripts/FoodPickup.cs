using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodPickup : MonoBehaviour
{
    public Transform connectedBody;
    public float speed = 10.0f;

    public float height = 0.5f;

    public bool collected = false;
    public bool dead = false;
    // Update is called once per frame
    void Update()
    {
        if (connectedBody == null)
        {
            return;
        }
        Vector3 pos = connectedBody.transform.position + Vector3.up * height;
        transform.position = Vector3.Lerp(transform.position, pos, speed * Time.deltaTime);
    }
}
