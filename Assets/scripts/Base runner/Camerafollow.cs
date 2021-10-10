using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerafollow : MonoBehaviour
{
    public Transform Target;

    public float FollowSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, Target.position, FollowSpeed * Time.deltaTime);
        //transform.rotation = Quaternion.Slerp(transform.rotation, Target.rotation, FollowSpeed * Time.deltaTime);    
    }
}
