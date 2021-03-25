using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollow : MonoBehaviour
{
    //criação do array waypoints
    public GameObject[] waypoints;

    //colocado valor vazio inicial para a variavel
    public int currentWP = 0;

    //criado a velociade, precisão e a movimentação na qual o objeto deve ser virado
    float speed = 3.0f;
    float accuracy = 5.0f;
    float rotSpeed = 0.4f;

    //inicio do programa
    void Start()
    {
        //faz o objeto busque um camiho para o ponto referido, no caso, os objetos com tag waypoint
        waypoints = GameObject.FindGameObjectsWithTag("waypoint");
    }

    //criado o late update, que faz a ultima atualização de todas as funções (opcional)
    void LateUpdate()
    {
        //verificar tamanho do array
        if (waypoints.Length == 0) return;

        //instanciando new vector3, dentro do waypoints, é definido um valor dado para o currentWP, e colocado cada uma das posições dentro dos eixos x e z
        Vector3 lookAtGoal = new Vector3(waypoints[currentWP].transform.position.x, this.transform.position.y, waypoints[currentWP].transform.position.z);

        //atribui para onde ele tem que olhar menos a posição referente ao ponto inicial
        Vector3 direction = lookAtGoal - this.transform.position;
        //definida uma suavidade para a rotação, para que a movimentação não seja tão brusca
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation,Quaternion.LookRotation(direction), //...
        
            //criado o deltatime devido ao lateupdate e o lookrotation
            Time.deltaTime * rotSpeed);

        //definir o tamanho da magnitude
        if(direction.magnitude < accuracy)
        {
            //troca a posição atual para o próximo waypoint
            currentWP++;
            //recalcula o tamanho do array
            if (currentWP >= waypoints.Length)
            {
                currentWP = 0;
            }
        }

        this.transform.Translate(0, 0, speed * Time.deltaTime);

    }
}
