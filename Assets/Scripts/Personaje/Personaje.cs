using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaje : Entidad
{
    private Inteligencia inteligencia;
    private Mapa mapa;

    private int posX, posY;

    public int PosX { get => posX; set => posX = value; }
    public int PosY { get => posY; set => posY = value; }
    public Mapa Mapa { get => mapa; set => mapa = value; }

    public Personaje(Inteligencia i, RepresentacionGrafica rep)
    {
        representacionGrafica = rep;
        inteligencia = i;
    }
   
        //transform.position = Vector3.Lerp(transform.position, targetPosition, 5 * Time.deltaTime);
    



    
    

    public void CalcularMomiviento()
    {
        inteligencia.CalcularMovimiento(this);
    }

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
    }

}
