using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Penguin :Animal
{
    //Start Animal and set unique ariables
    private void Start()
    {
        base.Start();
        animalDiet = foodType.Fish;
    }

    //Define unique instances such as preferred food, and behaviors
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.F))
        {
            Eat(foodType.Fish);
        }
        base.Update();
    }
}
