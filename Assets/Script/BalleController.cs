using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalleController : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision){
        if (collision.gameObject.layer==LayerMask.NameToLayer("Cible")){
            Debug.Log("Une cible est détruite !");
            //Change la couleur de la cible une fois touché
            collision.gameObject.GetComponent<Renderer>().material.color = new Color(255, 0, 0);
            //Détruire la cible après une seconde après une collision avec la balle
            Destroy(collision.gameObject,1f);
            //Détruit la balle une fois que la cible est touché
            Destroy(gameObject);
        }
        else{
            //Détruire la balle si elle n'a pas toucher de cible en 5 seconde 
            Destroy(gameObject,5f);
        }
    }

   
}
