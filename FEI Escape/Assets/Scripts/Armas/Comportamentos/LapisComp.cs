using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LapisComp : ProjetilArmasComportamento
{

    LapisController lc;

    protected override void Start()
    {
        base.Start();
        lc = FindObjectOfType<LapisController>();
    }

    void Update()
    {
        transform.position += direction * weaponData.Speed * Time.deltaTime;    //Set the movement of the knife
    }
}