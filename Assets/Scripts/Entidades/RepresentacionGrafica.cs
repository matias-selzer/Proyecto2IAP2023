using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RepresentacionGrafica 
{
    public abstract void UpdateGraphics(GameObject toActivate);
    public abstract void MoveGraphics(int posX, int posY);
}
