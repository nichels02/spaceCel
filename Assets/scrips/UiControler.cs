using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiControler : MonoBehaviour
{
    [SerializeField] Puntajes LaListaDePuntajes;
    [SerializeField] TMP_Text TextoDeQueSeGuardo;
    [SerializeField] TMP_Text DistanciaTexto;
    [SerializeField] TMP_Text PuntajeFinal;
    [SerializeField] TMP_Text Vida;
    [SerializeField] GameObject Panel;
    [SerializeField] ObjectPoling[] ELObjectPolling;


    public void ActualizarPuntaje()
    {
        DistanciaTexto.text = "Distancia: " + ((int)ControladorTiempo.instance.distancia);
    }

    public void Moriste()
    {
        bool SeGuardo=LaListaDePuntajes.ActualizarLista((int)ControladorTiempo.instance.distancia);
        if (SeGuardo)
        {
            TextoDeQueSeGuardo.gameObject.SetActive(true);
            TextoDeQueSeGuardo.text = "Lograste superar la posicion " + LaListaDePuntajes.posicionDelDatoNuevo + " del puntaje mas alto";
            NotificationSimple.instance.SendNotification("Limite superado", "Lograste superar la posicion " + LaListaDePuntajes.posicionDelDatoNuevo + " del puntaje mas alto" + " con " + (int)ControladorTiempo.instance.distancia + " puntos", 0, SeGuardo);
        }
        else
        {
            NotificationSimple.instance.SendNotification("No se logro", "Perdiste al consueguir unos " + (int)ControladorTiempo.instance.distancia + " puntos", 0, SeGuardo);
            TextoDeQueSeGuardo.gameObject.SetActive(false);
        }
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
        ControladorDeEscenas.instance.CambiarDeMapa(1);
        for(int i= 0;i<ELObjectPolling.Length;i++)
        {
            ELObjectPolling[i].desactivartodo();
        }
    }

    public void Salir()
    {
        Application.Quit();
    }
}
