using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioPlayer : MonoBehaviour {

    public Animator marioAnim;
    public Rigidbody2D rigid;
    public Transform trans;
    public SpriteRenderer render;

    public bool isMoving;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {

        // Si la tecla Space es presionada por el usuario
        if(Input.GetKeyDown(KeyCode.Space)) {
            
            // Agregamos una fuerza instantanea hacia arriba
            rigid.AddForce(Vector2.up * 10, ForceMode2D.Impulse);

			// Permitimos la transicion a la animacion MarioFly
			marioAnim.SetTrigger("SpaceKeyPressed");

            // Apago el parametro que indica que Mario esta tocando la plataforma
            marioAnim.SetBool("MarioTouchedPlatform", false);
        }

        isMoving = false;

		// Si la tecla Flecha Derecha es presionada por el usuario
		if(Input.GetKey(KeyCode.RightArrow)) {

            // Muevo a Mario suavemente hacia la derecha
            trans.Translate(Vector3.right * 0.1f);

            // Activo la propiedad Flip del Sprite Renderer para que Mario mire a la derecha
            render.flipX = true;

            // Indicamos que Mario se esta moviendo
            isMoving = true;

        }

		// Si la tecla Flecha Izquierda es presionada por el usuario
		if (Input.GetKey(KeyCode.LeftArrow)) {

			// Muevo a Mario suavemente hacia la derecha
			trans.Translate(Vector3.left * 0.1f);

            // Activo la propiedad Flip del Sprite Renderer para que Mario mire a la derecha
            render.flipX = false;

			// Indicamos que Mario se esta moviendo
            isMoving = true;
		}

        if(isMoving == true) {
			marioAnim.SetBool("MarioIsMoving", true);
        } else {
            marioAnim.SetBool("MarioIsMoving", false);
        }
	}

	void OnCollisionEnter2D(Collision2D collision) {

        // Si la tag del objecto que colisiono con el personaje es la adecuada
		if (collision.gameObject.tag == "Platform") {
            
			// Activo el parametro que indica que Mario esta tocando la plataforma
			marioAnim.SetBool("MarioTouchedPlatform", true);
		}

	}
}
