using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimTransition : MonoBehaviour
{
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        bool moverseOprimido = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D);
        bool shiftOprimido = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);

        if (moverseOprimido)
        {
            if (shiftOprimido)
            {
                anim.SetFloat("Velocidad", 1.0f); // Configurar la Velocidad de corrida en el BlendTree
            }
            else
            {
                anim.SetFloat("Velocidad", 0.5f); // Configurar la Velocidad de caminar en el BlendTree
            }
        }
        else
        {
            anim.SetFloat("Velocidad", 0.0f); // Configurar la Velocidad de estar quieto en el BlendTree
        }
    }
}
