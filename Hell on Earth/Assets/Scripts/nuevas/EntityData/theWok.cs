using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Transactions;
//using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class theWok : DatosEntidad
{
    // Start is called before the first frame update
    void Start()
    {
        //tenemos que sobreescribir todo lo que pertenezca a este concreto diferente del base aqui, porque los definimos en DatosEntidad
        test = "theWok";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void inter() {
        Debug.Log("oleeeeeeeeeeeeee");
        //por ejemplo, cambiamos de escena asi
        SceneManager.LoadScene("Scene_Biome_Desert");
    }

    public override string bubble()
    {
        return "ROCA";
    }
}
