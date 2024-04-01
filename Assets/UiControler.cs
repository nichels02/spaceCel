using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiControler : MonoBehaviour
{

    [SerializeField] TMP_Text DistanciaTexto;
    [SerializeField] TMP_Text PuntajeFinal;
    [SerializeField] TMP_Text Vida;
    [SerializeField] GameObject Panel;


    public void ActualizarPuntaje()
    {
        DistanciaTexto.text = "Distancia: " + ((int)ControladorTiempo.instance.distancia);
    }

    public void Moriste()
    {
        Panel.SetActive(true);
        DistanciaTexto.gameObject.SetActive(false);
        Vida.gameObject.SetActive(false);
        PuntajeFinal.text= "Puntaje: " + ((int)ControladorTiempo.instance.distancia);
    }

    public void actualizarVida(float vidas)
    {
        Vida.text = "Vidas: " + vidas;
    }

    public void RegresarMenu()
    {
        SceneManager.LoadScene(1);
    }

    public void Salir()
    {
        Application.Quit();
    }
}
