using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Multiplier : MonoBehaviour
{

    public Animator LeftAnimator;
    public Animator RightAnimator;
    public Transform LeftLocator;
    public Transform RightLocator;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public enum Side
    {
        LEFT,
        RIGHT,
    }

    public void TryPutFoodToLocator(PlayerMovement player, Side side, Transform locator)
    {
        Animator Anim = LeftAnimator;
        if (side == Side.RIGHT)
        {
            Anim = RightAnimator;
        }

        List<GameObject> foodList = player.collectLeftHand.foods;
        if (side == Side.RIGHT)
        {
            foodList = player.collectRightHand.foods;
        }

        int foodCount = foodList.Count;

        if (foodCount > 0)
        {
            int topFoodIndex = foodCount - 1;
            GameObject topFood = foodList[topFoodIndex];

            foodList.Remove(topFood);

            topFood.GetComponent<FoodPickup>().connectedBody = null;
            topFood.transform.position = locator.position;

            int Rnd = Random.Range(1,3);
            if(Rnd == 1)
            {
                Anim.SetTrigger("isWaving");
            }
            if(Rnd == 2)
            {
                Anim.SetTrigger("isCheering");
            }
            if(Rnd == 3)
            {
                Anim.SetTrigger("isBeckoning");
            }

        }
    }

    void OnTriggerEnter(Collider other)
    {
        PlayerMovement player = other.GetComponent<PlayerMovement>();
        bool isThisPlayer = player != null;
        if (isThisPlayer)
        {
            TryPutFoodToLocator(player, Side.LEFT, LeftLocator);
            TryPutFoodToLocator(player, Side.LEFT, LeftLocator);
            
            TryPutFoodToLocator(player, Side.RIGHT, RightLocator);
            TryPutFoodToLocator(player, Side.RIGHT, RightLocator);
            
            

            if (player.collectRightHand.foods.Count == 0 && player.collectLeftHand.foods.Count == 0)
            {
                GameControl.instance.gameOver = true;
                player.StickMan.SetTrigger("isDancing");
            }

            // int LeftPlateCount = player.collectLeftHand.foods.Count;
            // if (LeftPlateCount > 0)
            // {
            //     int TopFoodIndex = LeftPlateCount - 1;
            //     GameObject TopFood = player.collectLeftHand.foods[TopFoodIndex];

            //     player.collectLeftHand.foods.Remove(TopFood);
            //     TopFood.GetComponent<FoodPickup>().connectedBody = null;
            //     TopFood.transform.position = LeftLocator.position;

            // }

            // int RightPlateCount = player.collectRightHand.foods.Count;
            // if (RightPlateCount > 0)
            // {
            //     int TopFoodIndex = RightPlateCount - 1;
            //     GameObject TopFood = player.collectRightHand.foods[TopFoodIndex];

            //     player.collectRightHand.foods.Remove(TopFood);
            //     TopFood.GetComponent<FoodPickup>().connectedBody = null;
            //     TopFood.transform.position = RightLocator.position;
            // }
        }

    }
}
