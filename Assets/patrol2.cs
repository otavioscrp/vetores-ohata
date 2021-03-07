using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class patrol2 : MonoBehaviour
{
    public float speed;

    public int index = 0;

    public List<GameObject> alvos;



    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, alvos[index].transform.position, speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        

        if (other.CompareTag("alvo"))
        {

            next();

            if (index == 0)
            {
                index = 3;
            }

        }

    }


    


    public void next()
    {
        index++;
        if (index >= alvos.Count)
        {
            index = 0;
        }
    }
}
