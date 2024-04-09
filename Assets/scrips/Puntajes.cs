using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ElPuntaje", order = 1)]

public class Puntajes : ScriptableObject
{
    public float[] Lalista = new float[10];
    public float posicionDelDatoNuevo;



    public bool ActualizarLista(float ElNuevoDato)
    {
        if (ElNuevoDato > Lalista[Lalista.Length - 1])
        {
            Lalista[Lalista.Length - 1] = ElNuevoDato;

            for (int i = Lalista.Length - 2; i >= 0; i--)
            {
                if (Lalista[i] < Lalista[i + 1])
                {
                    float tmp = Lalista[i];
                    Lalista[i] = Lalista[i + 1];
                    Lalista[i + 1] = tmp;
                    posicionDelDatoNuevo = i + 1;
                }
                else
                {
                    break;
                }
            }

            return true;
        }
        else
        {
            return false;
        }
    }

}
