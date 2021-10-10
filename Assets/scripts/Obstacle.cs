using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
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
        PlayerMovement player = other.gameObject.GetComponent<PlayerMovement>();
        if (player != null)
        {
            player.isDead = true;
            GameControl.instance.gameOver = true;
            GameControl.instance.LoseUI.SetActive(true);
        }

        FoodPickup food = other.gameObject.GetComponent<FoodPickup>();
        if (food != null && !food.dead)
        {


            if (GameControl.instance.player.collectLeftHand.foods.Contains(food.gameObject))
            {

                List<GameObject> leftFoods = GameControl.instance.player.collectLeftHand.foods;
                int index = leftFoods.IndexOf(food.gameObject);
                int count = leftFoods.Count - 1;
                for (int i = count; i >= index; i--)
                {
                    FoodPickup current = leftFoods[i].GetComponent<FoodPickup>();
                    current.dead = true;
                    KillFood(current);
                    leftFoods.Remove(current.gameObject);
                }
            }

            if (GameControl.instance.player.collectRightHand.foods.Contains(food.gameObject))
            {

                List<GameObject> rightFoods = GameControl.instance.player.collectRightHand.foods;
                int index = rightFoods.IndexOf(food.gameObject);
                int count = rightFoods.Count - 1;
                for (int i = count; i >= index; i--)
                {
                    FoodPickup current = rightFoods[i].GetComponent<FoodPickup>();
                    current.dead = true;
                    KillFood(current);

                    rightFoods.Remove(current.gameObject);
                }
            }
        }
    }

    void KillFood(FoodPickup food)
    {
        Rigidbody rb = food.GetComponent<Rigidbody>();
        rb.isKinematic = false;
        rb.useGravity = true;
        rb.AddForce((food.transform.position - transform.position) * Random.Range(300, 1000));
        Collider col = food.GetComponent<Collider>();
        //col.isTrigger = false;
        col.enabled = false;
        food.connectedBody = null;
    }
}
