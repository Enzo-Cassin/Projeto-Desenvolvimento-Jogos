using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public List<ArmasController> slotArmas = new List<ArmasController>(6);
    public int[] weaponLvl = new int[6];
    public List<Image> weaponUISlots = new List<Image>(6);
    public List<PassiveItem> slotItens = new List<PassiveItem>(6);
    public int[] itensLvl = new int[6];
    public List<Image> itemUISlots = new List<Image>(6);

    public void AddWeapon(int slotIndex, ArmasController arma)
    {
        slotArmas[slotIndex] = arma;
        weaponLvl[slotIndex] = arma.weaponData.Level;
        weaponUISlots[slotIndex].enabled = true;
        weaponUISlots[slotIndex].sprite = arma.weaponData.Icon;
    }

    public void AddItem(int slotIndex, PassiveItem item)
    {
        slotItens[slotIndex] = item;
        itensLvl[slotIndex] = item.passiveItemData.Level;
        itemUISlots[slotIndex].enabled = true;
        itemUISlots[slotIndex].sprite = item.passiveItemData.Icon;
    }

    public void LevelUpWeapon(int slotIndex)
    {
        if(slotArmas.Count > slotIndex)
        { 
            ArmasController weapon = slotArmas[slotIndex];

            if(!weapon.weaponData.NextLevelPrefab)
            {
                Debug.LogError($"{weapon} já está no ultimo level");
                return;
            }
            GameObject upgradedWeapon = Instantiate(weapon.weaponData.NextLevelPrefab, transform.position, Quaternion.identity);
            upgradedWeapon.transform.SetParent(transform);
            AddWeapon(slotIndex, upgradedWeapon.GetComponent<ArmasController>());
            Destroy(weapon.gameObject);
            weaponLvl[slotIndex] = upgradedWeapon.GetComponent<ArmasController>().weaponData.Level;
        }
    }

    public void LevelUpItem(int slotIndex)
    {
        if(slotItens.Count > slotIndex)
        { 
            PassiveItem item = slotItens[slotIndex];
            if(!item.passiveItemData.NextLevelPrefab)
            {
                Debug.LogError($"{item} já está no ultimo level");
                return;
            }
            GameObject upgradeditem = Instantiate(item.passiveItemData.NextLevelPrefab, transform.position, Quaternion.identity);
            upgradeditem.transform.SetParent(transform);
            AddItem(slotIndex, upgradeditem.GetComponent<PassiveItem>());
            Destroy(item.gameObject);
            itensLvl[slotIndex] = upgradeditem.GetComponent<PassiveItem>().passiveItemData.Level;
        }
    }
}