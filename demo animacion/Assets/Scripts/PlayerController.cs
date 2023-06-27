using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Referencia a objeto Animator
    Animator animator;
    public float velocidadGiro = 200f;

    void Start()
    
    {
        //Creamos una nueva instancia de animator y nos posicionamos en el componente animator del personaje
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
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