using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRockAttack : MonoBehaviour
{
    [SerializeField]
    private GameObject Rock;

    [SerializeField]
    private GameObject player;

    [SerializeField]
    private float spawnThreshold = 100f;
    private float spawnTimer;
    private bool RockAttack;

    [HideInInspector]
    public Animator anim;

    public GameObject activeModel;

    private bool SlamAttack = false;

    public AudioSource SlamSound;



    private void Start()
    {
        SetupAnimator();
    }


    private void SetupAnimator()
    {
        if (activeModel == null)
        {
            anim = activeModel.GetComponent<Animator>();
            if (anim == null)
            {
                Debug.Log("no model found");
            }
            else
            {
                activeModel = anim.gameObject;
            }
        }

        anim = activeModel.GetComponent<Animator>();
    }
        private void HandleMovementAnimations()
    {
        anim.SetBool("RockAttack", RockAttack);
    }





    private void Update()
    {
        HandleMovementAnimations();

        

        StartCoroutine("StartSlamAnimation");
        

        spawnTimer += 0.01f;
        if (SlamAttack == true)
        {
            if (spawnTimer >= spawnThreshold)
            {
                Rockattack();
                spawnTimer = 0;
            }
        }

    }

    private void Rockattack()
    {
        Vector3 playerPos = player.transform.position;
        Vector3 playerDirection = player.transform.up;
        float height = 40;

        Vector3 spawnPos = playerPos + playerDirection * height;

        Instantiate(Rock, spawnPos, Quaternion.identity);     
        StopCoroutine("StartSlamAnimation");
        StartCoroutine("StartSlam");
   

    }

    IEnumerator StartSlamAnimation()
    {
        
        yield return new WaitForSeconds(5);
        
        RockAttack = true;
        SlamAttack = true;     
    }

    IEnumerator StartSlam()
    {
        
        yield return new WaitForSeconds(5);
        RockAttack = false;
        SlamAttack = false;
        
    }


}
