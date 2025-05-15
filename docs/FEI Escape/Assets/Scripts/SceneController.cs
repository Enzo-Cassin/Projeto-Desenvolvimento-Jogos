using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void SceneChange(string name)
    {
        Time.timeScale = 1;
        if (name == "Menu"){
            SceneManager.LoadScene("Menu");
        }
        else if (name == "Entrada"){
            SceneManager.LoadScene("Entrada");
        }
        else if (name == "Capela"){
            SceneManager.LoadScene("Capela");
        }
        else if (name == "Estagio"){
            SceneManager.LoadScene("Estagio");
        }
        else if (name == "TCC"){
            SceneManager.LoadScene("FaseTCC");
        }
    }
}