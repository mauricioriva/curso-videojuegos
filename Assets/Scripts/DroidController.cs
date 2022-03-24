using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroidController : MonoBehaviour
{
    public Transform target;

    public Transform blasterBolt;

    public Transform blaster;

    public float distanciaDisparo;

    public float tiempoEntreDisparos;

    public bool puedeDisparar;
    
    private void Update() {
        if (ObjetivoCerca() && puedeDisparar) {
            Disparar();
        }
    }

    public bool ObjetivoCerca() {
        if (target) {
            return Mathf.Abs(target.position.x - transform.position.x) < distanciaDisparo;
        }
        return false;
    }

    public void Disparar() {
        Instantiate(blasterBolt, blaster.position, Quaternion.identity);
        StartCoroutine(BloquearDisparo(tiempoEntreDisparos));
    }
    
    public IEnumerator BloquearDisparo(float tiempo) {
        // Completar: Bloquear el disparo del arma por el tiempo dado
        puedeDisparar = false;
        yield return new WaitForSeconds(tiempo);
        puedeDisparar = true;
    }
}
