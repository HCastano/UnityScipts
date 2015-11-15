using UnityEngine;
using System.Collections;
using System.Resources;

public class MoveBox : MonoBehaviour
{

    float moveSpeed = 0f;
    float moveAccel = 6.0f;

    // Use this for initialization
    void Start()
    {


    }


    // Update is called once per frame
    void Update()
    {
        //a = v/t
        //v = a * t 

        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

        while (Abs(moveSpeed) < 2)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                moveSpeed += moveAccel * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.DownArrow))
            {
                moveSpeed -= moveAccel * Time.deltaTime;

            }
        }
    }

    void FixedUpdate()
    {

    }

    float Abs(float num)
    {
        if (num < 0) return -1 * num;

        return num;
    }
}
