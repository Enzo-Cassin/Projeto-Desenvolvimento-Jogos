using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public PersonagemSO characterData;

    //Current stats
    [HideInInspector]
    public float currentHealth;
    [HideInInspector]
    public float currentRecovery;
    [HideInInspector]
    public float currentMoveSpeed;
    [HideInInspector]
    public float currentmight;
    [HideInInspector]
    public float currentProjectileSpeed;
    [HideInInspector]
    public float currentMagnet;

    //Experience and level of the player
    [Header("Experience/Level")]
    public int experience = 0;
    public int level = 1;
    public int experienceCap = 100;
    public int experienceCapIncrease;

    //I-Frames
    [Header("I-Frames")]
    public float invincibilityDuration;
    float invincibilityTimer;
    bool isInvincible;


    InventoryManager inventory;
    public int armaIndex;
    public int itemIndex;

    //Debug, remover(ou comentar) quando terminar de testar o inventario
    public GameObject arma2, item1, item2;
    void Awake()
    {
        characterData = CharacterSelector.GetData();
        //CharacterSelector.instance.DestroySingleton();
        inventory = GetComponent<InventoryManager>();

        //Assign the variables
        currentHealth = characterData.MaxHealth;
        currentRecovery = characterData.Recovery;
        currentMoveSpeed = characterData.MoveSpeed;
        currentmight = characterData.Might;
        currentProjectileSpeed = characterData.ProjectileSpeed;
        currentMagnet = characterData.Magnet;

        SpawnWeapon(characterData.StartingWeapon);

        //Debug, remover(ou comentar) quando terminar de testar o inventario
        SpawnWeapon(arma2);
        SpawnItem(item1);
        SpawnItem(item2);
    }

    void Update()
    {
        if (invincibilityTimer > 0)
        {
            invincibilityTimer -= Time.deltaTime;
        }
        //If the invincibility timer has reached 0, set the invincibility flag to false
        else if (isInvincible)
        {
            isInvincible = false;
        }

        Recover();
    }

    public void IncreaseExperience(int amount)
    {
        experience += amount;

        LevelUpChecker();
    }

    void LevelUpChecker()   //Increase level if the experience is more than or equal to the required amount to level up
    {
        if (experience >= experienceCap)
        {
            //Level up the player and deduct their experience
            level++;
            experience -= experienceCap;
            experienceCap += experienceCapIncrease;
            GameManager.instance.StartLevelUp();
        }   
    }

    public void TakeDamage(float dmg)
    {
            currentHealth -= dmg;
            if (currentHealth <= 0)
            {
                Kill();
            }
    }

    public void Kill()
    {
        if(!GameManager.instance.isGameOver)
        {
            GameManager.instance.GameOver();
        }
        Debug.Log("BOMBOU");
    }

    public void RestoreHealth(float ammount)
    {
        if(currentHealth < characterData.MaxHealth)
        {
            currentHealth += ammount;

            if(currentHealth > characterData.MaxHealth)
            {
                currentHealth = characterData.MaxHealth;
            }
        }
    }

    public void Recover()
    {
        if(currentHealth < characterData.MaxHealth)
        {
            currentHealth += currentRecovery * Time.deltaTime;

            if(currentHealth > characterData.MaxHealth)
            {
                currentHealth = characterData.MaxHealth;
            }
        }
    }

    public void SpawnWeapon(GameObject weapon)
    {
        if(armaIndex >= inventory.slotArmas.Count - 1)
        {
            Debug.LogError("Não há mais espaço para armas");
            return;
        }

        GameObject spawnedWeapon = Instantiate(weapon, transform.position, Quaternion.identity);
        spawnedWeapon.transform.SetParent(transform);
        inventory.AddWeapon(armaIndex, spawnedWeapon.GetComponent<ArmasController>());
        armaIndex++;
    }

    public void SpawnItem(GameObject item)
    {
        if(itemIndex >= inventory.slotItens.Count - 1)
        {
            Debug.LogError("Não há mais espaço para itens");
            return;
        }

        GameObject spawnedItem = Instantiate(item, transform.position, Quaternion.identity);
        spawnedItem.transform.SetParent(transform);
        inventory.AddItem(itemIndex, spawnedItem.GetComponent<PassiveItem>());
        itemIndex++;
    }
}