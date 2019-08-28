using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NPC // NameSpace que guarga toda la estructura del enemigo
{
    namespace Enemy // NameSpace que guarga la class Zombi para ser usada en el Generador
    {
        public class Zombi : MonoBehaviour
        {//declaracion de variables
            public DatoZombis datos; //Variable estruc para guardar los datos
            public int rotarcion;
            public float veloci = 2f;
            public string gusto;
            public int direccion;
            void Start()
            {
                rotarcion = Random.Range(35, 95);
                gusto = ZombiHable();
                gameObject.transform.tag = "Zombi";

                int color = Random.Range(1, 4);
                switch (color)
                {
                    case 1:
                        this.GetComponent<Renderer>().material.color = Color.cyan;
                        break;
                    case 2:
                        this.GetComponent<Renderer>().material.color = Color.green;
                        break;
                    case 3:
                        this.GetComponent<Renderer>().material.color = Color.magenta;
                        break;
                }
                StartCoroutine(rutina());
            }
            // Corutina para indicar el mobimiento del Zombi que es estar quieto o caminar
            IEnumerator rutina()
            {
                while (true)
                {
                    int accion = Random.Range(0, 3);
                    switch (accion)
                    {
                        case 0:
                            datos.mover = Accion.Idle;
                            break;
                        case 1:
                            datos.mover = Accion.Moving;
                            direccion = Random.Range(0, 4);
                            break;
                        case 2:
                            
                            datos.mover = Accion.Rotating;
                            break;
                    }
                    yield return new WaitForSeconds(3f);
                }
            }
            // Mensaje que retornara a la clase Hero para ser impreso con el gusto del Zombi
            public string ZombiHable()
            {
                datos.gustos = Random.Range(0, 5);
                datos.gusto = (Gustos)datos.gustos;
                return "Waaaarrrr quieroooo comeeer " + datos.gusto;
            }
            public void Update()
            {
                if (datos.mover == Accion.Moving)
                {
                    switch (direccion)
                    {
                        case 0:
                            transform.position += transform.forward * veloci * Time.deltaTime;
                            break;
                        case 1:
                            transform.position -= transform.forward * veloci * Time.deltaTime;
                            break;
                        case 2:
                            transform.position += transform.right * veloci * Time.deltaTime;
                            break;
                        case 3:
                            transform.position -= transform.right * veloci * Time.deltaTime;
                            break;
                    }

                }
                else if (datos.mover== Accion.Rotating)
                {
                    
                    transform.Rotate(transform.up  * rotarcion * Time.deltaTime);
                }
            }
        }
        //Estrus que almacena los datos del Zombi
        public struct DatoZombis
        {
            public Gustos gusto;
            public Accion mover;
            public int gustos;
        }
        // Gusto que pueden tener los Zombis
        public enum Gustos
        {
            Pierna,
            Cesos,
            Corazon,
            Braso,
            Manos,
            Last
        }
        //Indicadior que ace mover al Zombi los cuales son: Idle => Quieto y Moving => Mover
        public enum Accion { Idle, Moving, Rotating }
    }
}