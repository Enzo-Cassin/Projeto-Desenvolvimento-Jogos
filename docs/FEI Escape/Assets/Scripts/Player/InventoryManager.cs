using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public List<ArmasController> slotArmas = new List<ArmasController>(6);
    public int[] weaponLvl = new int[6];
    public List<Image> weaponUISlots = new List<Image>(6);
    public List<PassiveItem> slotItens = new List<PassiveItem>(6);
    public int[] passiveItemLevels = new int[6];
    public int[] itensLvl = new int[6];
    public List<Image> passiveItemUISlots = new List<Image>(6);
    
    
    [System.Serializable]
    public class WeaponUpgrade
    {
        public GameObject initialWeapon;
        public ArmasSO weaponData;
    }

    [System.Serializable]
    public class PassiveItemUpgrade
    {
        public GameObject initialPassiveItem;
        public PassiveItemScriptableObject passiveItemData;
    }

    [System.Serializable]
    public class UpgradeUI
    {
        public Text upgradeNameDisplay;
        public Text upgradeDescriptionDisplay;
        public Image upgradeIcon;
        public Button upgradeButton;
    }

    public List<WeaponUpgrade> weaponUpgradeOptions = new List<WeaponUpgrade>();    //List of upgrade options for weapons
    public List<PassiveItemUpgrade> passiveItemUpgradeOptions = new List<PassiveItemUpgrade>(); //List of upgrade options for passive items
    public List<UpgradeUI> upgradeUIOptions = new List<UpgradeUI>();    //List of ui for upgrade options present in the scene
    

       //List of ui for upgrade options present in the scene
    public void AddWeapon(int slotIndex, ArmasController arma)
    {
        slotArmas[slotIndex] = arma;
        weaponLvl[slotIndex] = arma.weaponData.Level;
    }

    public void AddItem(int slotIndex, PassiveItem item)
    {
        slotItens[slotIndex] = item;
        itensLvl[slotIndex] = item.passiveItemData.Level;
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
