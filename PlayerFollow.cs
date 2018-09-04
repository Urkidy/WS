using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour {

    public Transform PlayerTransform;
    private Vector3 distancia;
    public float SmoothFactor = 0.5f;
    public float turnSmoothing = 15f;
    public GameObject jugador;
    public GameObject referencia; 

    // Use this for initialization
    void Start () {
        distancia = transform.position - jugador.transform.position;
	}

    void LateUpdate()
    {
        //distancia = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * 2, Vector3.up) * distancia;
        transform.position = jugador.transform.position + distancia;
        transform.LookAt(jugador.transform.position);

        //Referencia de controles

        Vector3 copiaRotacion = new Vector3(0, transform.eulerAngles.y, 0);
        referencia.transform.eulerAngles = copiaRotacion;

    }

}
