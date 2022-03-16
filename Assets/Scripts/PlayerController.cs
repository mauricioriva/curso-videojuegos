using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool saltando;

    public int fuerzasalto;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        habilitamovimientos();
    }

    private void salta() {
        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0,fuerzasalto));
    }

    private void avanza() {
        gameObject.GetComponent<Animator>().SetBool("Avanza",true);
        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(500f * Time.deltaTime,0));
        gameObject.GetComponent<SpriteRenderer>().flipX = false;
    }

    private void retrocede() {
        gameObject.GetComponent<Animator>().SetBool("Avanza",true);
        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-500f * Time.deltaTime,0));
        gameObject.GetComponent<SpriteRenderer>().flipX = true;
    }

    private void habilitamovimientos() {
        if (Input.GetKey("a")) {
            retrocede();
        }
        if (Input.GetKey("d")) {
            avanza();
        }
        if (Input.GetKeyDown("w") && !saltando) {
            saltando = true;
            salta();
        }
        if (!Input.GetKey("a") && !Input.GetKey("d")) {
            gameObject.GetComponent<Animator>().SetBool("Avanza",false);
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.transform.tag == "Piso") {
            saltando = false;
        }
    }
}
