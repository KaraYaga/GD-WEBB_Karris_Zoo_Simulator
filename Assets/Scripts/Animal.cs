using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

//Github test comment
public class Animal : MonoBehaviour
{
//Animal animations
    [SerializeField] Animator animator;

 //Animal Sprites
    [Header("Animal UI")]
    [SerializeField] SpriteRenderer aliveSprite;

//Health bar Images
    [Header("Health Bars")]
    [SerializeField] Image HungerBar;
    [SerializeField] Image ThirstBar;
    [SerializeField] Image FatigueBar;

//Establish animal variables
    [Header("Animal Stats")]
    [SerializeField] protected string animalName;
    [SerializeField] protected int animalAge;
    [SerializeField] protected foodType animalDiet;
    [SerializeField] protected animations movement;

    //Hunger, Thirst, Sleep Bars
    [SerializeField] protected int maxHunger = 100;
    [SerializeField] protected int maxThirst = 100;
    [SerializeField] protected int maxFatigue = 100;

//Current bodily statuses
    protected int currentHunger;
    protected int currentThirst;
    protected int currentFatigue;

//Initialize bodily functions
    private void initializeValues()
    {
        currentHunger = maxHunger;
        currentThirst = maxThirst;
        currentFatigue = maxFatigue;
    }

//Animal gets hungry
    private void getHungry()
    {
        currentHunger -= 20;
        HungerBar.fillAmount = currentHunger / 100f;
        Debug.Log("Getting hungry " + currentHunger);
    }

 //Feeding the animal on key press
    public void Eat (foodType foodToEat)
    {
        if (foodToEat == animalDiet)
        {
            currentHunger += 10;
            HungerBar.fillAmount = Mathf.Clamp(currentHunger, 0, maxHunger);
            HungerBar.fillAmount = currentHunger / 100f;
        }

    }
 //Animal gets thirsty
    private void getThirsty()
    {
        currentThirst -= 10;
        ThirstBar.fillAmount = currentThirst / 100f;
    }

 //Give animal water on button press
    public void Drink (int drinkAmount)
    {
        currentThirst += drinkAmount;
        ThirstBar.fillAmount = Mathf.Clamp(currentThirst, 0, maxThirst);
        ThirstBar.fillAmount = currentThirst / 100f;
    }

 //Animal gets sleepy
    private void getSleepy()
    {
        currentFatigue -= 30;
        FatigueBar.fillAmount = currentFatigue / 100f;
    }
    
 //Increase animal's sleep on button press
    public void Sleep (int sleepTime)
    {
        currentFatigue += sleepTime;
        FatigueBar.fillAmount = Mathf.Clamp(currentFatigue, 0, maxFatigue);
        FatigueBar.fillAmount = currentFatigue / 100f;

        if (animator != null)
        {
            animator.SetTrigger("SleepTrigger");
        }
        else
        {
            Debug.LogError("Animator not assigned to Animal script. Please assign it in the Inspector.");
        }
    }

 //Start animal's bodily functions
    protected void Start()
    {
        initializeValues();

        //Start animation behavior
        if (animator != null)
        {
            animator.SetBool("IsWalking", true);
            InvokeRepeating("getThirsty", 10f, 5f);
            InvokeRepeating("getHungry", 5f, 10f);
            InvokeRepeating("getSleepy", 10f, 20f);
            StartCoroutine(RandomAnimationCycle());
        }
    }

//Random Animation between Chilling and Walking
    private IEnumerator RandomAnimationCycle()
    {
        while (true)
        {
            float randomTime = Random.Range(5f, 15f);
            yield return new WaitForSeconds(randomTime);

            if (Random.value < 0.5f)
            {
                animator.SetBool("IsWalking", false);
            }
            else
            {
                animator.SetBool("IsWalking", true);
            }
        }
    }

    //Ability to give animals amount of food, water, etc.
    public void Update()
    {
        //Give Water
        if (Input.GetKeyUp(KeyCode.D))
        {
            Drink(20);
        }
        //Give Rest
        if (Input.GetKeyUp(KeyCode.S))
        {
            Sleep(10);
        }

        //Die if neglected
        if (HungerBar.fillAmount == 0f && ThirstBar.fillAmount == 0f && FatigueBar.fillAmount == 0f)
        {
            Die();
        }
    }

 //Kill innocent animals
    protected virtual void Die()
    {
        Destroy(gameObject);
    }
}

//Food type list
public enum foodType
{
    Fish,
    Meat,
    Vegetable
}

//Behaviors animations list
public enum animations
{
    walking,
    sleeping
}
