using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public PersonagemSO characterData;

    //Current stats
    [HideInInspector]
    float currentHealth;
    [HideInInspector]
    float currentRecovery;
    [HideInInspector]
    float currentMoveSpeed;
    [HideInInspector]
    float currentmight;
    [HideInInspector]
    float currentProjectileSpeed;
    [HideInInspector]
    float currentMagnet;

    #region Current Stats Properties
    public float CurrentHealth{
        get { return currentHealth;}
        set {
            if(currentHealth != value){
                currentHealth = value;
            }
        }
    }

    public float CurrentRecovery{
        get { return currentRecovery;}
        set {
            if(currentRecovery != value){
                currentRecovery = value;
            }
        }
    }

    public float CurrentMoveSpeed{
        get { return currentMoveSpeed;}
        set {
            if(currentMoveSpeed != value){
                currentMoveSpeed = value;
            }
        }
    }

    public float Currentmight{
        get { return currentmight;}
        set {
            if(currentmight != value){
                currentmight = value;
            }
        }
    }

    public float CurrentProjectileSpeed{
        get { return currentProjectileSpeed;}
        set {
            if(currentProjectileSpeed != value){
                currentProjectileSpeed = value;
            }
        }
    }

    public float CurrentMagnet{
        get { return currentMagnet;}
        set {
            if(currentMagnet != value){
                currentMagnet = value;
            }
        }
    }
    #endregion
    
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
        CharacterSelector.instance.DestroySingleton();
        inventory = GetComponent<InventoryManager>();

        //Assign the variables
        CurrentHealth = characterData.MaxHealth;
        CurrentRecovery = characterData.Recovery;
        CurrentMoveSpeed = characterData.MoveSpeed;
        Currentmight = characterData.Might;
        CurrentProjectileSpeed = characterData.ProjectileSpeed;
        CurrentMagnet = characterData.Magnet;

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
        }   
    }

    public void TakeDamage(float dmg)
    {
        //If the player is not currently invincible, reduce health and start invincibility
        if (!isInvincible)
        {
            CurrentHealth -= dmg;

            invincibilityTimer = invincibilityDuration;
            isInvincible = true;

            if (CurrentHealth <= 0)
            {
                Kill();
            }
        }
    }

    public void Kill()
    {
        Debug.Log("BOMBOU");
    }

    public void RestoreHealth(float ammount)
    {
        if(CurrentHealth < characterData.MaxHealth)
        {
            CurrentHealth += ammount;

            if(CurrentHealth > characterData.MaxHealth)
            {
                CurrentHealth = characterData.MaxHealth;
            }
        }
    }

    public void Recover()
    {
        if(CurrentHealth < characterData.MaxHealth)
        {
            CurrentHealth += CurrentRecovery * Time.deltaTime;

            if(CurrentHealth > characterData.MaxHealth)
            {
                CurrentHealth = characterData.MaxHealth;
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