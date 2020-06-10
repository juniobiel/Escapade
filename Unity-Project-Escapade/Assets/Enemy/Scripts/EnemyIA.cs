using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum EnemyStates { Parado, Patrulha, Seguir, Correr }

public class EnemyIA : MonoBehaviour
{
    public EnemyStates myStates = EnemyStates.Patrulha;

    Animator animator;
    NavMeshAgent agent;

    //alvo
    [Header("ALVO")]
    public Transform player;

    //visao
    [Header("VISÃO")]
    public float angleVision = 90;
    public float minDistanceVision = 10;
    public Transform eye;
    float vTimer = 0; //caso o inimigo veja
    float vtAmount = 0.1f; //adiciona ao passar do tempo

    [Header("PATRULHA")]
    public Transform wayPoint;
    public Transform[] wayPoints;
    public float minDistance = 2;
    int wayPointIndex = 0;
    bool isClose = false;


    //animações
    float vertical;

    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();

        wayPoints = wayPoint.GetComponentsInChildren<Transform>();

        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        switch(myStates)
        {
            case EnemyStates.Parado:
                SetParado();
            break;

            case EnemyStates.Patrulha:
                SetPatrulha();
            break;

            case EnemyStates.Seguir:
                SetSeguir();
            break;

            case EnemyStates.Correr:

            break;

        }

        AnimUpdate();

    }

    void AnimUpdate()
    {
        animator.SetFloat("vertical", vertical);
    }

    void SetParado()
    {
        SetMove(false, true, 0);

        VisionTimer();
    }

    void SetMove(bool rm, bool ag, float v)
    {
        animator.applyRootMotion = rm;
        agent.enabled = ag;
        vertical = Mathf.Lerp(vertical, v, 2 * Time.deltaTime);
    }

    void SetPatrulha()
    {
        if(wayPoint == null)
        {
            myStates = EnemyStates.Parado;
            return;
        }

        float dis = Vector3.Distance(wayPoints[wayPointIndex].position, transform.position);

        if( dis <= minDistance)
        {
            wayPointIndex = UnityEngine.Random.Range(0, wayPoints.Length);
        }
        else
        {
            agent.destination = wayPoints[wayPointIndex].position;
        }

        SetMove(false, true, 1);

        VisionTimer();
    }

    void SetSeguir()
    {
        
    }

    void VisionTimer()
    {
        if (Ver())
        {
            vTimer += vtAmount;
        }
        else
        {
            vTimer -= vtAmount;
        }

        vTimer = Mathf.Clamp(vTimer, 0, 1); //limita os pontos min e máximo

        if (vTimer >= 1) 
        {
            myStates = EnemyStates.Seguir;
        }
        if (vTimer <= 0)
        {
            myStates = EnemyStates.Parado;
        }

    }

    bool Ver()
    {
        Vector3 direction = player.position - transform.position;
        float angle = Vector3.Angle(transform.forward, direction);
        float distance = Vector3.Distance(player.position, transform.position);
        RaycastHit hit;

        if(angle < angleVision && distance <= minDistanceVision)
        {
            if(Physics.Linecast(eye.position, player.position, out hit))
            {
                if(hit.transform.tag == "Player")
                {
                    return true;
                }
                else 
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
}
