using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigosMov : MonoBehaviour
{
    InimigosStats enemy;
    Transform player;


    void Start()
    {
        enemy = GetComponent<InimigosStats>();
        player = FindObjectOfType<PlayerMovement>().transform;
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, enemy.currentMoveSpeed * Time.deltaTime);    //Constantly move the enemy towards the player
    }
}