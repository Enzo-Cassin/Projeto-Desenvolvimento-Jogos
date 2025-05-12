using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeiPoints : PickUp, ICollectible
{
    public int experienceGranted;

    public void Collect()
    {
        PlayerStats player = FindAnyObjectByType<PlayerStats>();
        player.IncreaseExperience(experienceGranted);
    }
}