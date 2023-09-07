using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerComboController : MonoBehaviour
{
    private Animator anim;
    private int currentCombo = 0; // Para llevar un registro del combo actual
    private int activeCombo = 0; // Para llevar un registro del combo actual
    bool activeAnimation = false;
    public float timeToReset = 1;
    Coroutine waitFA = null;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        // Detectar el click izquierdo del ratón
        if (Input.GetMouseButtonDown(0))
        {
            if (activeAnimation == false) {
                // Incrementar el valor del combo actual
                currentCombo++;

                // Si superamos el tercer ataque, reiniciamos el combo
                if (currentCombo > 3)
                {
                    currentCombo = 3;
                }
                if (waitFA != null)
                {
                    StopCoroutine(waitFA);
                }
                // Establecer el valor del parámetro "Clicks" en función del combo actual
                switch (currentCombo)
                {
                    case 1:
                        anim.SetFloat("Clicks", 1f);
                        waitFA = StartCoroutine(waitForAnimation(false));
                        break;
                    case 2:
                        anim.SetFloat("Clicks", 2f);
                        waitFA = StartCoroutine(waitForAnimation(false));
                        break;
                    case 3:
                        anim.SetFloat("Clicks", 3f);
                        waitFA = StartCoroutine(waitForAnimation(true));
                        break;
                }
            }
        }

        // Restablecer el valor del combo cuando se suelte el botón del ratón
        /*
        if (Input.GetMouseButtonUp(0))
        {
            currentCombo = 0;
            anim.SetFloat("Clicks", 0.0f);
        }
        */
    }

    IEnumerator waitForAnimation(bool lastHit)
    {
        activeAnimation = true;
        yield return 0;
        yield return new WaitForSeconds(anim.GetCurrentAnimatorClipInfo(0).LongLength);
        yield return 0;
        activeAnimation = false;
        if (lastHit)
        {
            currentCombo = 0;
        }
        anim.SetFloat("Clicks", 0);

        yield return new WaitForSeconds(timeToReset);
        currentCombo = 0;
    }
}