using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class perseguicao : MonoBehaviour
{

    public GameObject alvo;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, alvo.transform.position, Time.deltaTime * 10f);
    }

    
}
