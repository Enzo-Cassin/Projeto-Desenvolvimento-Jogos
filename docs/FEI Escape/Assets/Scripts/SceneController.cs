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
        else if (name == "1_Entrada"){
            SceneManager.LoadScene("Entrada");
        }
        else if (name == "2_Capela"){
            SceneManager.LoadScene("Capela");
        }
        else if (name == "3_Corporativo"){
            SceneManager.LoadScene("Estagio");
        }
        else if (name == "TCC"){
            SceneManager.LoadScene("FaseTCC");
        }
    }
}