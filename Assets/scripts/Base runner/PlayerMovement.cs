using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator StickMan;
    public bool CanRotate = false;
    public float speed = 3f;
    public float sidespeed = 5f;
    public float TurnRate = 15f;
    public Vector2 PrevScreenX;

    public bool isDead = false;

    public CharacterController characterController;

    public CollectFood collectLeftHand;
    public CollectFood collectRightHand;

    void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        /*
        if(UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject(-1))
        {
            return;
        }
        */
        if (Input.GetMouseButtonDown(0))
        {
            GameControl.instance.gameStarted = true;
            GameControl.instance.StartUI.gameObject.SetActive(false);
            StickMan.SetTrigger("isRunning");
        }

        if (isDead || !GameControl.instance.gameStarted || GameControl.instance.gameOver || GameControl.instance.isPaused)
        {
            return;
        }

        //Moving forward
        Vector3 pos = transform.position;
        Vector3 step = transform.forward * speed * Time.deltaTime;
        Vector3 sidestep = Vector3.zero;

        if (Input.GetMouseButtonDown(0))
        {
            PrevScreenX = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {
            var deltaX = Input.mousePosition.x - PrevScreenX.x;
            if (Mathf.Abs(deltaX) < 1.0f)
            {
                deltaX = 0.0f;
            }
            else
            {
                deltaX = Mathf.Sign(deltaX);
            }
            //deltaX = Mathf.Sign(deltaX);
            if (CanRotate)
            {
                transform.localRotation = Quaternion.Euler(0, transform.localRotation.eulerAngles.y + TurnRate * Time.deltaTime * deltaX, 0);
            }
            else
            {
                sidestep = transform.right * sidespeed * deltaX * Time.deltaTime;
                // transform.position += sidestep;
            }
        }

        Vector3 gravity = Vector3.down * 9.81f * Time.deltaTime;

        characterController.Move(step + sidestep + gravity);

        PrevScreenX = Input.mousePosition;
    }
}
