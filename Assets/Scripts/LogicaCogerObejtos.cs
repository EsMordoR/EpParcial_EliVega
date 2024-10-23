using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaCogerObejtos : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "objeto" && other.GetComponent<logicaobjetos>().destruirautomatico == true)
        {
            other.GetComponent<logicaobjetos>().AplicarPowerUp();
            Destroy(other.gameObject);
        }

      
    }
}
