using UnityEngine;

public class CharacterSelector : MonoBehaviour
{
    public static CharacterSelector instance;
    public PersonagemSO personagemData;

    void Awake()
    {
        if(instance == null) 
        { 
            instance = this;
            DontDestroyOnLoad(gameObject);   
        }
        else
        {
            Debug.LogWarning("Personagem a mais");
        }
    }

    public static PersonagemSO GetData() 
    {
        return instance.personagemData;
    }

    public void SelecionarPersonagem(PersonagemSO personagem){
        personagemData = personagem;
    }
}
