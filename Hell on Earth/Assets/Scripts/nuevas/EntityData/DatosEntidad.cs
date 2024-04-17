using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class DatosEntidad : MonoBehaviour
{

    public string test = "hola";
    public StatPoints hitPoints;
    public StatPoints actionPoints;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //esto es lo que debes hacer un override para definir que accion concreta va a tener el gameobject cuando le das click
    public abstract void inter();

    //esto es lo que debes hacer un override para definir que texto quieres que se muestre cuando interactuas
    public abstract string bubble();
}
