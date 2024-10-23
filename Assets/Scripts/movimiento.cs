using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

public class movimiento : MonoBehaviour
{
    //CambiodeCollier
    public CapsuleCollider colParado;
    public CapsuleCollider colAgachado;
    public GameObject cabeza;
    public logicacabeza logicaCabeza;
    public bool estoyagachado;


    //
    public float velocidadMovimiento = 7.0f;
    public float velocidadRotacion = 200.0f;
    private Animator animator;
    public float x, y;
    public Rigidbody rb;
    public float fuerzaDeSalto = 8f;
    public bool puedoSaltar;
    public float velocidadInicial;
    public float velocidadAgachado;
    public int velcorrer;
    void Start()
    {
        puedoSaltar = false;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();

        velocidadInicial = velocidadMovimiento;
        velocidadAgachado = velocidadMovimiento * 0.5f;
    }

    void FixedUpdate()
    {

        transform.Rotate(0, x * Time.deltaTime * velocidadRotacion, 0);
        transform.Translate(0, 0, y * Time.deltaTime * velocidadMovimiento);

        
        
    }

    void Update()
    {

        if (Input.GetKey(KeyCode.LeftShift) && !estoyagachado && puedoSaltar)
        {
            velocidadMovimiento = velcorrer;
            if (y > 0)
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
            animator.SetBool("correr", false);


            if (estoyagachado)
            {
                velocidadMovimiento = velocidadAgachado;
            }
            else if(puedoSaltar)
            {
                velocidadMovimiento = velocidadInicial;
            }
        }

        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        animator.SetFloat("VelX", x);
        animator.SetFloat("VelY", y);


        if (puedoSaltar)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {

                animator.SetBool("Jump", true);
                rb.AddForce(new Vector3(0, fuerzaDeSalto, 0), ForceMode.Impulse);

            }


            if (Input.GetKey(KeyCode.LeftControl))
            {

                animator.SetBool("agachado", true);
                //velocidadMovimiento = velocidadAgachado;

                //cambiodeCollider
                colAgachado.enabled = true;
                colParado.enabled = false;

                cabeza.SetActive(true);
                estoyagachado = true;

            }
            else
            {
                if(logicaCabeza.contadorDeColision <=0)
                {
                animator.SetBool("agachado", false);
                //velocidadMovimiento = velocidadInicial;

                    //cambiodeCollider
                    cabeza.SetActive(false);
                    colAgachado.enabled = false;
                    colParado.enabled = true;
                    estoyagachado = false;
                }
            }
            animator.SetBool("tocosuelo", true);
        }
        else
        {
            Estoycayendo();
        }

    }


    public void Estoycayendo()
    {
        animator.SetBool("tocosuelo", false);
        animator.SetBool("Jump", false);
    }
}
