using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hamster : Animal
{
    //Start Animal and set unique ariables
    private void Start()
    {
        base.Start();
        animalDiet = foodType.Vegetable;
    }

    //Define unique instances such as preferred food, and behaviors
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.V))
        {
            Eat(foodType.Vegetable);
        }
        base.Update();
    }

}
