using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Botones : MonoBehaviour
{
    [SerializeField] GameObject ElPanel;
    [SerializeField] GameObject ElPanelDePuntos;
    [SerializeField] Nave Nivel1;
    [SerializeField] Nave Nivel2;
    [SerializeField] Nave Nivel3;
    [SerializeField] Nave NaveElegida;
    [SerializeField] TMP_Text[] ListasDePuntajes = new TMP_Text[10];
    [SerializeField] Puntajes LaListaDePuntajes;



    private void Start()
    {
        seleccionarNave(Nivel2);
    }
    public void Jugar()
    {
        SceneManager.LoadScene(0);
    }

    public void ElegirPersonaje()
    {
        ElPanel.SetActive(true);
    }

    public void Nave1()
    {
        seleccionarNave(Nivel1);
        ElPanel.SetActive(false);
    }
    public void Nave2()
    {
        seleccionarNave(Nivel2);
        ElPanel.SetActive(false);
    }
    public void Nave3()
    {
        seleccionarNave(Nivel3);
        ElPanel.SetActive(false);
    }

    void seleccionarNave(Nave laNave)
    {
        NaveElegida.Imagen = laNave.Imagen;
        NaveElegida.vida = laNave.vida;
        NaveElegida.velocidadHorizontal = laNave.velocidadHorizontal;
        NaveElegida.velocidadVertical = laNave.velocidadVertical;
    }


    public void Salir()
    {
        print("salir");
        Application.Quit();
    }




    public void ListaDePuntajes()
    {
        ElPanelDePuntos.SetActive(true);
        for(int i = 0; i < 10; i++)
        {
            ListasDePuntajes[i].text = i + 1 + ". " + LaListaDePuntajes.Lalista[i];
        }
    }

    public void CerrarLista()
    {
        ElPanelDePuntos.SetActive(false);
    }
}
