using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float MoveSpeed = 10f;
    public float rollBoost = 10f;
    public float rollTime;
    public float rollTimer;
    public bool rollCheck;

    public Rigidbody2D rgb2;
    public Vector3 keyInput;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
       // animator = GetComponent<Animator>();
        rollTimer = 0.9f;
        rollTime = 0.0f;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        keyInput.x = Input.GetAxis("Horizontal");
        keyInput.y = Input.GetAxis("Vertical");
        transform.position += keyInput * MoveSpeed * Time.deltaTime;

        //animator.SetFloat("Speed", keyInput.sqrMagnitude);

        if (Input.GetKeyDown(KeyCode.Space) && rollTime <= 0)
        {
            //animator.SetBool("Roll", true);
            MoveSpeed += rollBoost;
            rollTime = rollTimer;
            rollCheck = true;
        }
        if (rollTime <= 0 && rollCheck==true)
        {
            //animator.SetBool("Roll", false);
            MoveSpeed -= rollBoost;
            rollCheck = false;
        }
        else
        {
           
            rollTime -= Time.deltaTime;
        }

        if (keyInput.x != 0 && spriteRenderer != null)
        {
            if (keyInput.x > 0)
            {
                spriteRenderer.transform.localScale = new Vector3(0, 0, 1);
            }
            else
            {
                spriteRenderer.transform.localScale = new Vector3(-0, 0, 1);
            }
        }
    }
}
