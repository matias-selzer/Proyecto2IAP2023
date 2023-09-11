using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaje : MonoBehaviour
{
    private int x, y;
    private Vector3 targetPosition;

    public GameObject up, down, left, right;

    public int X { get => x; set => x = value; }
    public int Y { get => y; set => y = value; }

    // Start is called before the first frame update
    void Start()
    {
        targetPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            ActivateGraphics(right);
            Mover(X, ++Y);
        }else if (Input.GetKeyDown(KeyCode.A))
        {
            ActivateGraphics(left);
            Mover(X, --Y);
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            ActivateGraphics(up);
            Mover(--X, Y);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            ActivateGraphics(down);
            Mover(++X, Y);
        }

        transform.position = Vector3.Lerp(transform.position, targetPosition, 5 * Time.deltaTime);
    }


    public void Mover(int posX,int posY)
    {
        targetPosition = new Vector3(posX, 1, posY);
        X = posX;
        Y = posY;
    }

    private void ActivateGraphics(GameObject toActivate)
    {
        up.SetActive(false);
        down.SetActive(false);
        right.SetActive(false);
        left.SetActive(false);
        toActivate.SetActive(true);
    }


}
