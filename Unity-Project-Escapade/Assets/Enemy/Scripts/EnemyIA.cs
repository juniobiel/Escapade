﻿using System;
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
    }
}
