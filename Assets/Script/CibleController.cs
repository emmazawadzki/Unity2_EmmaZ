using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CibleController : MonoBehaviour
{
    [SerializeField] private GameObject CibleOriginal;
    [SerializeField] public Transform CibleTransform;
    [SerializeField] private GameObject Sol;
    // Start is called before the first frame update
    void Start()
    {
        //Créer une cible
        CreateCible();
    }

    void CreateCible(){
        StartCoroutine(CibleIni());
    }

    //Initialisation de la position de la cible aléatoirement
    private Vector3 PositionRandomCible() {
        //La cible se retrouve aléatoirement au dessus du sol et retombe sur le sol grace à la gravité
        //En évitant qu'elle se retrouve sur le mur (d'où le +1f ou -1f)
        return new Vector3(
            Random.Range(Sol.transform.position.x-Sol.transform.localScale.x/2+1f,Sol.transform.position.x+Sol.transform.localScale.x/2-1f),
            Random.Range(1f,4f),
            Random.Range(Sol.transform.position.z-Sol.transform.localScale.z/2+1f, Sol.transform.position.z+Sol.transform.localScale.z/2-1f));
    }

    private IEnumerator CibleIni() {
        while (true) {
            //Attendre 3 seconde avant de faire apparaître une cible
            yield return new WaitForSeconds(3f);
            //Faire apparaître une cible selon la prefab (CibleOriginal), une position aléatoire et sans rotation
            Instantiate(CibleOriginal, PositionRandomCible(), Quaternion.identity);
        }
    }
    

    
}
