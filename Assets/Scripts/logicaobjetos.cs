using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class logicaobjetos : MonoBehaviour
{
    public bool destruirautomatico;
    public PlayerMove playerMove;



    // Start is called before the first frame update
    void Start()
    {
        playerMove = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMove>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AplicarPowerUp()
    {

        playerMove.gameObject.transform.localScale = new Vector3(8, 8, 8);
        playerMove.animator.SetBool("crece", true);
    }
}