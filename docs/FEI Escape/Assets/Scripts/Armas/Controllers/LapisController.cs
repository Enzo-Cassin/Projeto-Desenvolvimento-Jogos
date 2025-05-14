using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LapisController : ArmasController
{
    protected override void Start()
    {
        base.Start();
    }

    protected override void Attack()
    {
        base.Attack();
        GameObject spawnedLapis = Instantiate(weaponData.Prefab);
        spawnedLapis.transform.position = transform.position; //Assign the position to be the same as this object which is parented to the player
        spawnedLapis.GetComponent<LapisComp>().DirectionChecker(pm.lastMovedVector);
    }
}