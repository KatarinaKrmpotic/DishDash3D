using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balancing : MonoBehaviour
{
    
    public PlayerMovement player;
    public float power = 0.1f;
    public float rotation = 15f;
    GameObject playerGameObject;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (player == null)
        {
            player = other.gameObject.GetComponent<PlayerMovement>();
            if (player != null)
            {
                playerGameObject = player.gameObject;
            }

        }
    }

    void OnTriggerStay(Collider other)
    {
        if (player != null)
        {
            float leftWeight = player.collectLeftHand.foods.Count;
            float rightWeight = player.collectRightHand.foods.Count;

            float dif = rightWeight - leftWeight;
            Vector3 step = player.transform.right * dif * Time.deltaTime * power;
            player.characterController.Move(step);
            playerGameObject.transform.Rotate(Vector3.forward * rotation * -dif * Time.deltaTime, Space.Self);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == playerGameObject)
        {
            playerGameObject.transform.rotation = Quaternion.identity;
            player = null;
            playerGameObject = null;
        }
    }
}
