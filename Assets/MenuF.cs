using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuF : MonoBehaviour
{
    // Start is called before the first frame update
    public void Iniciar(string name)
    {
        SceneManager.LoadScene(name, LoadSceneMode.Single);
    }

    public void Salir()
    {
        Application.Quit();
        Debug.Log("Saliiir");
    }

}
