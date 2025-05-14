using UnityEngine;

public class EstudosPassiveItem : PassiveItem
{
    protected override void ApplyModifier()
    {
        player.Currentmight *= 1 + passiveItemData.Multiplier / 100f;
    }
}