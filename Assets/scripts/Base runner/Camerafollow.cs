using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerafollow : MonoBehaviour
{
    public Transform Target;

    public Transform GamePlayTarget;

    public Transform EndGamePlayTarget;
    public bool isRotatingActive = false;

    public float FollowSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        Target = GamePlayTarget;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, Target.position, FollowSpeed * Time.deltaTime);
        if(isRotatingActive)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Target.rotation, FollowSpeed * Time.deltaTime);
            
        }
            
    }

    public void EndGameCamera()
    {
        Target = EndGamePlayTarget;
        isRotatingActive = true;
    }
}
