using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class camara : MonoBehaviour
{
    public Camera _cam;
    public enum CAMERA_TYPE { FREE_LOOK, LOCKED }
    public CAMERA_TYPE type = CAMERA_TYPE.FREE_LOOK;

    [Range(0.1f, 2.0f)]
    public float sensi;
    public bool invertXAxis;
    public bool invertYAxis;
    public Transform lookat;
    private void Awake()
    {
        if( type == CAMERA_TYPE.FREE_LOOK)
        {
            _cam.transform.parent = transform; 
        }
    }
    private void FixedUpdate()
    {
        float h = Input.GetAxis("Mouse X");
        float v = Input.GetAxis("Mouse Y");

        h = (invertXAxis ? (-h) : h);
        v = (invertYAxis ? (-v) : v);

        if (h !=0)
        {
            if (type == CAMERA_TYPE.LOCKED) transform.Rotate(Vector3.up,h*90*sensi*Time.deltaTime);
            else if (type == CAMERA_TYPE.FREE_LOOK) _cam.transform.RotateAround(transform.position,transform.up,h*90*sensi* Time.deltaTime);
        }
        if(v!=0)
        {
            _cam.transform.RotateAround(transform.position, transform.right, v * 90 * sensi * Time.deltaTime);
        }
        _cam.transform.LookAt(lookat);
        Vector3 ea = _cam.transform.rotation.eulerAngles;
        _cam.transform.rotation = Quaternion.Euler(new Vector3(ea.x,ea.y,0));
    }
    
}
   