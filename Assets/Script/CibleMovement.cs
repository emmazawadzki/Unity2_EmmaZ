using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CibleMovement : MonoBehaviour
{
    private Rigidbody Cible;
    [SerializeField] public Transform CibleTransform;

    private void Start() {
        Cible = GetComponent<Rigidbody>();
        StartCoroutine(CibleMouvement());
    }

    private IEnumerator CibleMouvement() {
        //La cible attend 2 secondes avant de démarrer
        yield return new WaitForSeconds(2f);

        //Mouvement de la cible
        while (true) {
            float TempsMouvement = Random.Range(1f, 10f);
            float Timer = 0f;

            //Changement de la position
            Vector3 deltaPosition = new Vector3(
                Random.Range(-1f, 1f),
                CibleTransform.position.y,
                Random.Range(-1f, 1f))*Time.deltaTime*1f;

            while (Timer < TempsMouvement) {
                Timer += Time.deltaTime;
                Cible.position += deltaPosition;
                yield return new WaitForEndOfFrame();
            }
        }
    }

    private void OnCollisionEnter(Collision collision){
            //Detruire la cible si elle n'a pas été toucher par une balleau bout de 15 secondes 
            Destroy(gameObject,15f);
        
    }
}
