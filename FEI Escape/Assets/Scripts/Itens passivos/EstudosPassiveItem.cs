using UnityEngine;

public class EstudosPassiveItem : PassiveItem
{
    protected override void ApplyModifier()
    {
        player.currentmight *= 1 + passiveItemData.Multiplier / 100f;
    }
}