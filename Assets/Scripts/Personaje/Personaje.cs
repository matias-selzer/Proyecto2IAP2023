using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaje : Entidad
{
    private Inteligencia inteligencia;
    private List<Node> conocimiento;
   

    public Personaje(Inteligencia i, RepresentacionGrafica rep)
    {
        representacionGrafica = rep;
        inteligencia = i;
        conocimiento = new List<Node>();
    }
   
        //transform.position = Vector3.Lerp(transform.position, targetPosition, 5 * Time.deltaTime);
    



    
    

    public void Mover()
    {
        inteligencia.CalcularMovimiento(this);
    }
    /*
    public void MoverDerecha()
    {
        Mapa.MoverPersonajeDerecha();
        representacionGrafica.UpdateGraphics(((RepGraficaMultiple)representacionGrafica).RightRep);
        representacionGrafica.MoveGraphics(PosY, PosX);
    }
    public void MoverIzquierda()
    {
        Mapa.MoverPersonajeIzquierda();
        representacionGrafica.UpdateGraphics(((RepGraficaMultiple)representacionGrafica).LeftRep);
        representacionGrafica.MoveGraphics(PosY, PosX);
    }
    public void MoverArriba()
    {
        Mapa.MoverPersonajeArriba();
        representacionGrafica.UpdateGraphics(((RepGraficaMultiple)representacionGrafica).UpRep);
        representacionGrafica.MoveGraphics(PosY, PosX);
    }
    public void MoverAbajo()
    {
        mapa.MoverPersonajeAbajo();
        representacionGrafica.UpdateGraphics(((RepGraficaMultiple)representacionGrafica).DownRep);
        representacionGrafica.MoveGraphics(PosY, PosX);
    }*/

    public void ActualizarConocimiento(List<Node> contexto)
    {
        //hacer que agregue una copia del noto y no una referencia
        foreach(Node n in contexto)
        {
            if (!conocimiento.Contains(n))
            {
                conocimiento.Add(n);
            }
        }
    }

}
