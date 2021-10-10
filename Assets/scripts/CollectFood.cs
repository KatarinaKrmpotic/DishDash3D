using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectFood : MonoBehaviour
{
    public List<GameObject> foods;

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
        FoodPickup food = other.gameObject.GetComponent<FoodPickup>();
        if (food != null && !food.collected)
        {
            if (foods.Contains(other.gameObject))
            {
                return;
            }
            if (foods.Count == 0)
            {
                food.connectedBody = transform;
            }
            else
            {
                int last = foods.Count - 1;
                food.connectedBody = foods[last].transform;
            }
            foods.Add(food.gameObject);
            food.collected = true;

        }
    }
}
