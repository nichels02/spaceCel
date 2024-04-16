using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;
using System;

public class ControladorTiempo : MonoBehaviour
{
    public static ControladorTiempo instance { get; private set; }

    public float distancia;
    public float Tiempo = 0;
    public float velocidad;
    public float VelocidadDeLaNave;
    public ControladorDelMapa[] Mapa;
    public UiControler LaUi;
    public float duracionEntreMeteoritos = 0;
    public float TiempoParaGenerarMeteorito=100;
    public float TiempoParaGenerarAliens=100;
    public float duracionEntreAliens=0;
    [SerializeField] GameObject PrefabMeteoro;
    [SerializeField] ObjectPoling ListaDeMeteoritos;
    [SerializeField] ObjectPoling ListaDeAliens;
    public bool SeMurio;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }
    private void Start()
    {
        
    }
    void Update()
    {
        if (!SeMurio)
        {
            Tiempo += Time.deltaTime;
            velocidad = 15f / (1f + 7f * math.exp(-Tiempo / 30f));
            distancia = Tiempo * velocidad;
            LaUi.ActualizarPuntaje();
            if (TiempoParaGenerarMeteorito > duracionEntreMeteoritos)
            {
                TiempoParaGenerarMeteorito = 0;
                duracionEntreMeteoritos = 0.5f + (2f - 0.08f) * (1f - (velocidad / 15f));
                GenerarMeteoro();
            }
            else
            {
                TiempoParaGenerarMeteorito += Time.deltaTime;
            }

            if (TiempoParaGenerarAliens > duracionEntreAliens)
            {
                TiempoParaGenerarAliens = 0;
                duracionEntreAliens = (0.5f + (2f - 0.08f) * (1f - (velocidad / 15f))) * 5;
                GenerarAlien();
            }
            else
            {
                TiempoParaGenerarAliens += Time.deltaTime;
            }
        }
        else
        {
            velocidad = 0;
        }
        
    }

    void GenerarMeteoro()
    {
        Vector2 LaPosicion = new Vector2(17, UnityEngine.Random.Range(-4, 4));
        GameObject Objeto = ListaDeMeteoritos.NuevoObjeto(LaPosicion);

        if (Objeto == null)
        {
            print("es nulo");
        }
        float Velocidad = 1.2f + 6f * (velocidad / 15f);
        Objeto.GetComponent<Meteorito>().velocidad = Velocidad;
    }

    void GenerarAlien()
    {
        Vector2 LaPosicion = new Vector2(17, UnityEngine.Random.Range(-4, 4));
        GameObject Objeto = ListaDeAliens.NuevoObjeto(LaPosicion);

        if (Objeto == null)
        {
            print("es nulo");
        }

        bool ArribaOabajo = UnityEngine.Random.Range(1, 3) == 1 ? true : false;
        float Velocidad = (1.2f + 6f * (velocidad / 15f))/2;
        Objeto.GetComponent<NaveAlienigena>().velocidad = Velocidad;
        Objeto.GetComponent<NaveAlienigena>().ArribaOAbajo = ArribaOabajo;
    }
}
