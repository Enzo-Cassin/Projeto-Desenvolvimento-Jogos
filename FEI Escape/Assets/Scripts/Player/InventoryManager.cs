using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public List<ArmasController> slotArmas = new List<ArmasController>(6);
    public int[] weaponLvl = new int[6];
    public List<PassiveItem> slotItens = new List<PassiveItem>(6);
    public int[] itensLvl = new int[6];

    public void AddWeapon(int slotIndex, ArmasController arma)
    {
        slotArmas[slotIndex] = arma;
    }

    public void AddItem(int slotIndex, PassiveItem item)
    {
        slotItens[slotIndex] = item;
    }

    public void LevelUpWeapon(int slotIndex)
    {

    }

    public void LevelUpItem(int slotIndex)
    {
        
    }
}
