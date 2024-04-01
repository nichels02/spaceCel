using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;

public class ControladorTiempo : MonoBehaviour
{
    public static ControladorTiempo instance { get; private set; }

    public float distancia;
    public float Tiempo = 0;
    public float velocidad;
    public float VelocidadDeLaNave;
    public ControladorDelMapa[] Mapa;
    public UiControler LaUi;
    public float TiempoParaGenerarMeteorito=100;
    public float duracionEntreMeteoritos=0;
    [SerializeField] GameObject PrefabMeteoro;
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
        }
        else
        {
            velocidad = 0;
        }
        
    }

    void GenerarMeteoro()
    {
        float posicion = UnityEngine.Random.Range(-4, 4);
        GameObject Objeto = Instantiate(PrefabMeteoro, new Vector2(11, posicion), Quaternion.identity);
        float Velocidad = 1.2f + 6f * (velocidad / 15f);
        Objeto.GetComponent<Meteorito>().velocidad = Velocidad;
    }


}
