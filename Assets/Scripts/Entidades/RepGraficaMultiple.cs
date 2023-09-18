using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepGraficaMultiple 
{
    private GameObject upRep, downRep, leftRep, rightRep;

    public RepGraficaMultiple(GameObject up, GameObject down,GameObject left, GameObject right)
    {
        UpRep = up;
        DownRep = down;
        LeftRep = left;
        RightRep = right;
    }

    public GameObject UpRep { get => upRep; set => upRep = value; }
    public GameObject DownRep { get => downRep; set => downRep = value; }
    public GameObject LeftRep { get => leftRep; set => leftRep = value; }
    public GameObject RightRep { get => rightRep; set => rightRep = value; }

    public  void MoveGraphics(int posX, int posZ)
    {
        upRep.transform.position = new Vector3(posX, upRep.transform.position.y, posZ);
        downRep.transform.position = new Vector3(posX, downRep.transform.position.y, posZ);
        leftRep.transform.position = new Vector3(posX, leftRep.transform.position.y, posZ);
        rightRep.transform.position = new Vector3(posX, rightRep.transform.position.y, posZ);
    }

    public  void UpdateGraphics(GameObject toActivate)
    {
        UpRep.SetActive(false);
        DownRep.SetActive(false);
        LeftRep.SetActive(false);
        RightRep.SetActive(false);
        toActivate.SetActive(true);
    }
}
