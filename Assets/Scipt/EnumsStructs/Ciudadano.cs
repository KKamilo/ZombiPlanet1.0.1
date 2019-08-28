using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NPC // NameSpace que guarga toda la estructura del Ciudadano
{
    namespace Ally // NameSpace que guarga la class Zombi para ser usada en el Generador
    {
        public class Ciudadano : MonoBehaviour
        {
            public DatosNPC datoNPC;
            public string yoSoy;
            void Start()
            {
                gameObject.transform.tag = "City";
                yoSoy = Nombre();
            }
            public string Nombre()
            {// esta funcion se encardga de construir el mensaje con el nombre y edad del adeano
                datoNPC.edades = Random.Range(15, 101);
                int lazar = Random.Range(0, 20);
                datoNPC.nameNPC = (Nombres)lazar;
                return "Hola, me llamo " + datoNPC.nameNPC + " y tengo " + datoNPC.edades + " años";
            }
        }
        //este Enum guarda los nombres de los aldeanos para mostrarlo mas adelante
        public enum Nombres
        { Krooth, Zacot, Skooth, Griath, Arait, Catinius, Conbertus, Ambilos, Divicatus, Centus, Donnius, nCenno, Cotto, Ambisavus, Tritó, Vírico, Litugena, Epasius, Epia, Regula }
        public struct DatosNPC
        {
            public Nombres nameNPC;
            public int edades;
        }
    }
}