using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NPC.Ally; //se llama el Namespaces que tiene encapsulado la clase Ciudadano
using NPC.Enemy; //se llama el Namespaces que tiene encapsulado la clase Zombi
using UnityEngine.UI;

public class Juego : MonoBehaviour //Generador
{
    public Text textZ;
    public Text textC;
    readonly int cantidad; //variable de Readonly para la creacion de los cubos
    public Juego() // costructor para inicialisar el Readonly 
    {
        System.Random rnd = new System.Random(); //se creo una bariable Random 
        cantidad = rnd.Next(5, 16);// se le agrega los parametros para la variable creada anterior mente
    }
    public static float hSpied;//variable estatica para la velocidad del herue
    public void Awake() //usamos el Aweke para inicialisar una bariable Randon.Range para que no salte un problema con la Readonly
    {
        hSpied = Random.Range(0.1f, 0.5f);
    }
    void Start()
    {
        
        int i = 0;
        int k = 0;
        while (i < cantidad)
        {
            int n = Random.Range(1, 3);
            GameObject objec = GameObject.CreatePrimitive(PrimitiveType.Cube);
            objec.AddComponent<Rigidbody>();
            Vector3 v = new Vector3();
            v.x = Random.Range(5, 50);
            v.z = Random.Range(5, 50);
            objec.transform.position = v;
            if (i == 0 && k == 0)
            {
                objec.AddComponent(typeof(Hero));
                k++;
            }
            else
            {
                switch (n)
                {
                    case 1:
                        objec.AddComponent(typeof(Zombi));
                        break;
                    case 2:
                        objec.AddComponent(typeof(Ciudadano));
                        break;
                }
            }
            i++;
        }

        int cyti = 0; // variable de contador para mostrar cuantos ciudadanos hay
        int enemy = 0; // variable de contador para mostrar cuantos Zombis hay
        foreach (Zombi zombi in Transform.FindObjectsOfType<Zombi>()) //Usamos Transform.FindObjectsOfType para buscar el objetoreferente al zombi en la esena
        {
            enemy = enemy +1;
            textZ.text = "Zombi: "+enemy; // modifica el texto del cambas y muestra el numero de enemigos
        }
        foreach (Ciudadano aldeano in Transform.FindObjectsOfType<Ciudadano>()) //Usamos Transform.FindObjectsOfType para buscar el objetoreferente al ciudadano en la esena
        {
            cyti = cyti + 1;
            textC.text = "Aldeanos:" + cyti; // modifica el texto del cambas y muestra el numero de aliados
        }
    }
}