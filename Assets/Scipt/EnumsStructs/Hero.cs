using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NPC.Enemy;
using NPC.Ally;

public class Hero : MonoBehaviour
{
    void Start()
    {
        gameObject.transform.name = "Granger";
        gameObject.AddComponent(typeof(Player));

        GameObject cara = new GameObject();
        cara.AddComponent(typeof(Camera));
        cara.AddComponent(typeof(Ojos));//codigo de camara

        gameObject.GetComponent<Player>().mirar = cara.GetComponent<Ojos>();
        cara.transform.SetParent(gameObject.transform);
        cara.transform.localPosition = new Vector3 (0, 0.5f, 0);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Zombi")
        {
            Debug.Log(collision.transform.GetComponent<Zombi>().gusto);
        }
        else if (collision.transform.tag == "City")
        {
            Debug.Log(collision.transform.GetComponent<Ciudadano>().yoSoy);
        }
    }
}