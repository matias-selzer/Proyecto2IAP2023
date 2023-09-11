using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject pared, piso, caja, jarron,personaje;
    //public GameObject camara;

    private Grilla grilla;
    private Personaje personajeActual;

    // Start is called before the first frame update
    void Start()
    {
        ReadMap();
        AsignarVecinos();
        CrearPersonaje(3,3); //hallar lugar libre
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void ReadMap()
    {
        string textFile = Resources.Load("Mapa1").ToString();
        string[] lineas = textFile.Split("\n");

        int tamañox = lineas.Length;
        int tamañoy = lineas[0].ToCharArray().Length-1;

        CrearGrilla(tamañox, tamañoy);

        for (int i = 0; i < tamañox; i++)
        {
            
            for (int j = 0; j < tamañoy; j++)
            {

                if (lineas[i].ToCharArray()[j] == '0') //es piso
                {
                    GameObject nuevoObjecto = Instantiate(piso, new Vector3(i, 0, j), Quaternion.Euler(new Vector3(90, 0, 0))) as GameObject;
                    Node nuevoNodo = new Node(i, j, 10);
                    grilla.AddNode(nuevoNodo, i, j);
                } else if (lineas[i].ToCharArray()[j] == '1') //es pared
                {
                    GameObject nuevoObjecto = Instantiate(pared, new Vector3(i, 0, j), Quaternion.identity) as GameObject;
                    Node nuevoNodo = new Node(i, j, 10000);
                    grilla.AddNode(nuevoNodo, i, j);
                }
                else if (lineas[i].ToCharArray()[j] == '2') //es caja
                {
                    GameObject nuevoObjecto = Instantiate(caja, new Vector3(i, 0.4f, j), Quaternion.identity) as GameObject;
                    Node nuevoNodo = new Node(i, j, 10000);
                    grilla.AddNode(nuevoNodo, i, j);
                }
                else if (lineas[i].ToCharArray()[j] == '3') //es pared
                {
                    GameObject nuevoObjecto = Instantiate(jarron, new Vector3(i, 0, j), Quaternion.identity) as GameObject;
                    Node nuevoNodo = new Node(i, j, 10000);
                    grilla.AddNode(nuevoNodo, i, j);
                }
            }
        }
    }

    private void CrearGrilla(int tamañox, int tamañoy)
    {
        grilla = new Grilla(tamañox, tamañoy);
    }

    private void AsignarVecinos()
    {
        grilla.AsignarVecinos();
    }

 
    private void CrearPersonaje(int posX,int posY)
    {
        GameObject personajeGrafico = Instantiate(personaje) as GameObject;
        personajeActual = personajeGrafico.GetComponent<Personaje>();
        personajeActual.Mover(posX, posY);
    }
}
