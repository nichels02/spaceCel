using System.Collections;
using System.Collections.Generic;
//<<<<<<< Updated upstream
//=======
using Unity.VisualScripting;
//using UnityEditor.SearchService;
//>>>>>>> Stashed changes
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladorDeEscenas : MonoBehaviour
{
    public static ControladorDeEscenas instance { get; private set; }

    private int NumeroDeEscenaGuardada;
    private string NombreDeEscenaGuardada;
    bool NumeroONombre;


    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this);
            NombreDeEscenaGuardada = "menu";
            NumeroONombre = true;
            SceneManager.LoadSceneAsync("menu", LoadSceneMode.Additive);
            
        }
    }

    private void Start()
    {
        
    }

    public void CambiarDeMapa(string escena)
    {
        if (NumeroONombre)
        {
            print(NombreDeEscenaGuardada);
            SceneManager.UnloadSceneAsync(NombreDeEscenaGuardada, UnloadSceneOptions.UnloadAllEmbeddedSceneObjects);
            print(NombreDeEscenaGuardada);
        }
        else
        {
            print(NumeroDeEscenaGuardada);
            SceneManager.UnloadSceneAsync(NumeroDeEscenaGuardada, UnloadSceneOptions.UnloadAllEmbeddedSceneObjects);
            print(NumeroDeEscenaGuardada);
        }
        NumeroONombre = true;
        NombreDeEscenaGuardada = escena;
        SceneManager.LoadSceneAsync(escena, LoadSceneMode.Additive);
    }
    public void CambiarDeMapa(int escena)
    {

        if (NumeroONombre)
        {
            print(NombreDeEscenaGuardada);
            SceneManager.UnloadSceneAsync(NombreDeEscenaGuardada, UnloadSceneOptions.UnloadAllEmbeddedSceneObjects);
            print(NombreDeEscenaGuardada);
        }
        else
        {
            print(NumeroDeEscenaGuardada);
            SceneManager.UnloadSceneAsync(NumeroDeEscenaGuardada, UnloadSceneOptions.UnloadAllEmbeddedSceneObjects);
            print(NumeroDeEscenaGuardada);
        }
        NumeroONombre = false;
        NumeroDeEscenaGuardada = escena;
        SceneManager.LoadSceneAsync(escena, LoadSceneMode.Additive);
    }
}
