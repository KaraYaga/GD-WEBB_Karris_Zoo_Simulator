using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : Animal
{
//Start Animal and set unique ariables
    private void Start()
    {
        base.Start();
        animalDiet = foodType.Meat;
    }

//Define unique instances such as preferred food, and behaviors
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.M) || Input.GetKeyUp(KeyCode.N))
        {
            Eat(foodType.Meat);
        }
        base.Update();
    }

//Set variations of a function with override
    protected override void Die()
    {
        Debug.Log("A fox died, how sad");
        Destroy(gameObject);
    }
}
