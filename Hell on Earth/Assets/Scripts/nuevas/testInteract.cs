using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class testInteract : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
{
    private Color originalColor;
    private void Start()
    {
        AddPhysics2DRaycaster();
        originalColor = GetComponent<SpriteRenderer>().color;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        float distance = Vector3.Distance(this.transform.position, GameObject.Find("Player_Isometric_Witch").transform.position);
        GameObject.Find("Player_Isometric_Witch").GetComponent<IsometricPlayerMovementController>().think("HOLA");
        if (distance < 1)
        {

            Debug.Log("Clicked: " + eventData.pointerCurrentRaycast.gameObject.name);
            Debug.Log("distancia: " + distance);
            //test para ehhh obtener datos de un objeto

            //la idea es la siguiente, definimos una clase (DatosEntidad) que va a tener todas las posibles variables comunes que podamos esperar en todos los objetos
            //(idk cuales serian ahora mismo) pero el tema es usar eso de template. Luego, creas otra clase para el objeto que quieras en especifico
            //por ejemplo, un bicho concreto, el "theWokChino", que tiene hp 1000 y ataque 50
            //con esta linea puedes acceder a los datos del objeto concreto
            //y para saber que tipo de cosa estas viendo, pues puedes poner una var tipo o algo
            Debug.Log("Clicked: " + eventData.pointerCurrentRaycast.gameObject.GetComponent<DatosEntidad>().test);

            //esto llama al metodo que hayas definido como interaccion en la clase concreta. 
            //eventData.pointerCurrentRaycast.gameObject.GetComponent<DatosEntidad>().inter();
            string bubble = eventData.pointerCurrentRaycast.gameObject.GetComponent<DatosEntidad>().bubble();
            if (bubble != null && bubble != "") 
            {
                //GameObject.Find("Player_Isometric_Witch").GetComponent<IsometricPlayerMovementController>().think(bubble);
            }
        }
    }


    //Detect if the Cursor starts to pass over the GameObject
    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        GetComponent<SpriteRenderer>().color = new Color(1, 0, 0, 1);
    }

    //Detect when Cursor leaves the GameObject
    public void OnPointerExit(PointerEventData pointerEventData)
    {
        GetComponent<SpriteRenderer>().color = originalColor;
    }

    private void AddPhysics2DRaycaster()
    {
        Physics2DRaycaster physicsRaycaster = FindObjectOfType<Physics2DRaycaster>();
        if (physicsRaycaster == null)
        {
            Camera.main.gameObject.AddComponent<Physics2DRaycaster>();
        }
    }

}
