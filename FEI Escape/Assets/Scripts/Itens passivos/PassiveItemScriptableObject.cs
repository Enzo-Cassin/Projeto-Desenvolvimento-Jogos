using UnityEngine;


[CreateAssetMenu(fileName = "PassiveItemScriptableObject", menuName = "ScriptableObjects/Item Passivo")]
public class PassiveItemScriptableObject : ScriptableObject
{
    [SerializeField]
    float multiplier;
    public float Multiplier { get => multiplier; private set => multiplier = value; }
}
