using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float runSpeed = 7;
    public float rotationSpeed = 250;
    public float jumpForce = 8f;

    public Animator animator;

    private float x, y;
    public bool activarsalto;

    public int velcorrer;
    public float velocidadinicial;

    public Rigidbody rb;
    

    void Start()
    {
        activarsalto = false;
        animator = GetComponent<Animator>();

        velocidadinicial = runSpeed;
    }

    void FixedUpdate()
    {

        transform.Rotate(0, x * Time.deltaTime * rotationSpeed, 0);
        transform.Translate(0, 0, y * Time.deltaTime * runSpeed);
        

    }
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");


        animator.SetFloat("VelX", x);
        animator.SetFloat("VelY", y);

        if (activarsalto)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
               
                animator.SetBool("Jump", true);
                rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);

            }
            animator.SetBool("tocosuelo", true);
        }
        else
        {
            Estoycayendo();
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            animator.SetBool("crece", false);
        }

        if(Input.GetKey(KeyCode.LeftShift)&& activarsalto)
        {
            runSpeed = velcorrer;
            if(y>0)
            {
                animator.SetBool("correr", true);
            }
            else
            {
                animator.SetBool("correr", false);
            }

        }
           else
        {
            animator.SetBool("corre", false);


            if(activarsalto)
                {
                runSpeed = velocidadinicial;
            } 
        }



        


    }

    public void Estoycayendo()
    {
        animator.SetBool("tocosuelo", false);
        animator.SetBool("Jump", false);
    }



}
