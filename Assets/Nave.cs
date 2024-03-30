using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/NaveScriptableObject", order = 1)]
public class Nave : ScriptableObject
{
    public Sprite Imagen;
    public int vida;
    public float velocidadHorizontal;
    public float velocidadVertical;

}
