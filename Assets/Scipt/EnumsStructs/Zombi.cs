﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NPC.Ally;
using UnityEngine.UI;

namespace NPC // NameSpace que guarga toda la estructura del enemigo
{
    namespace Enemy // NameSpace que guarga la class Zombi para ser usada en el Generador
    {
        public class Zombi : ReguladorNPC
        {//declaracion de variables
            
            public DatoZombis datos; //Variable estruc para guardar los datos
            public static string gusto;
            Vector3 directionCyti;
            Vector3 directionHero;
            float tempCyti;
            public static float DistanciaHero;
            float vision = 5f;
            public static string texto;
            void Start()
            {
                datos.edad = Random.Range(15, 101);
                rotarcion = Random.Range(35, 95);
                datos.gustos = Random.Range(0, 5);
                gameObject.transform.tag = "Zombi";
                positionInicial = transform.position;
                if (datos.edad > 15)
                    veloci = (float) (15*3)/datos.edad;
                player = GameObject.FindGameObjectWithTag("Herue");
              
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
                texto = ZombiHable();
                
                StartCoroutine(rutinaZombiCyti());
                
            }
            
            // Mensaje que retornara a la clase Hero para ser impreso con el gusto del Zombi
            public string ZombiHable()
            {
                datos.gusto = (Gustos)datos.gustos;
                return "Waaaarrrr quieroooo comeeer " + datos.gusto;
            }

            public void Update()
            {
                if (Juego.vivo == true) // Variable de vida del herue para ser ejetutada al empesar
                {
                    DistanciaHero = Vector3.Distance(player.transform.position, transform.position); // Distancia del Zombi al Herue
                    GameObject aldeanoCerca = null;// GameObject que almacena a todos los Aldeanos en la esena

                    foreach (Ciudadano aldeano in Transform.FindObjectsOfType<Ciudadano>())
                    {
                        tempCyti = Vector3.Distance(aldeano.transform.position, transform.position);// Distancia del Zombi al Aldeano mas sercano

                        if (tempCyti < vision)
                        {
                            vision = tempCyti;
                            aldeanoCerca = aldeano.gameObject; //remplasa el null por el Aldeano mas sercano

                        }

                    }
                    // If que hace que el Zombi tenga como prioridad al Aldeano y no al herue
                    if (aldeanoCerca != null)
                    {
                        directionCyti = Vector3.Normalize(aldeanoCerca.transform.position - transform.position);
                        transform.position += directionCyti * 0.1f;
                    }
                    else if (DistanciaHero <= vision)
                    {
                        gusto = ZombiHable();
                        directionHero = Vector3.Normalize(player.transform.position - transform.position);
                        transform.position += directionHero * 0.1f;
                    }
                    else
                    {
                        vision = 5f;
                        ComportarceNormal();
                    }
                }
            }
            // Finalisasion del juego al momento de colicionar con el herue 
            private void OnCollisionEnter(Collision collision)
            {
                if (collision.transform.tag == "Herue")
                {
                    Juego.perder.SetActive(true);
                    Juego.vivo = false;
                }
            }

        }
        //Estrus que almacena los datos del Zombi
        public struct DatoZombis
        {
            public Gustos gusto;
            public Accion mover;
            public int gustos;
            public int edad;
            // Gusto que pueden tener los Zombis
            
        }
        
        public enum Gustos
        {
            Pierna,
            Cesos,
            Corazon,
            Braso,
            Manos,
        }
        
    }
}


// enum Global que es utilizado por los Zombis y Aldeanos
public enum Accion { Running, Idle, Moving, Rotating, Pursuing }