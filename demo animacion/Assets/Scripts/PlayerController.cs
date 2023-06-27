using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Referencia a objeto Animator
    Animator animator;
    public float velocidadGiro = 200f;
    // Establecemos la distancia al suelo
    public float distanciaSuelo = 0.2f;
    public LayerMask capaSuelo;

    void Start()
    
    {
        //Creamos una nueva instancia de animator y nos posicionamos en el componente animator del personaje
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Si el personaje está  en el suelo (plane 3d), permitimos que la animacion controle la posicion
        //(el personaje en su posicion actual, la distancia del suelo actual, la distancia requerida para saber si esta en el suelo, el suelo)
        if(Physics.Raycast(transform.position,-Vector3.up,distanciaSuelo,capaSuelo))
        {
            animator.applyRootMotion = true;
        }else{
            animator.applyRootMotion = false;
        }

        //Opciones para controlar las animaciones
        //Animación 1: Caminar
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            animator.SetBool("Walk",true);
        }else{
            animator.SetBool("Walk",false);
        }
        //Animación 2: Correr
        if (Input.GetKey(KeyCode.R) )
        {
            animator.SetBool("Run",true);
        }else{
            animator.SetBool("Run",false);
        }
        //Animación 3: Saltar
        if (Input.GetKey(KeyCode.Space) )
        {
            animator.SetBool("Jump",true);
        }else{
            animator.SetBool("Jump",false);
        }
         //Animación 4: Celebrar
        if (Input.GetKey(KeyCode.C) )
        {
            animator.SetBool("Victory",true);
        }else{
            animator.SetBool("Victory",false);
        }
        //Operaciones para modificar la posicion del personaje
        float girar = Input.GetAxis("Horizontal") * velocidadGiro * Time.deltaTime;
        transform.Rotate(0,girar,0);
        
    }
}