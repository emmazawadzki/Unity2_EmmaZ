using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private GameObject prefab;
    [SerializeField] private float mouseSensitivity = 1f;
    private float rotationX = 0.0f;
    private float rotationY = 0.0f;

	//Pour pouvoir enlever le curseur
	[SerializeField] private bool lockCursor = true;

    // Start is called before the first frame update
    void Start(){
        //Permet d’enlever le curseur
		if(lockCursor){
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
		}

    }

    // Update is called once per frame
    void Update(){
        CameraDirection() ;
		CameraMouvement();

        //Lancer une balle au clic gauche de la souris
        if (Input.GetButtonDown("Fire1")){
            SpawnBalle();
        }

    }

    void CameraDirection(){
		rotationX += Input.GetAxis("Mouse X") * mouseSensitivity;
        rotationY -= Input.GetAxis("Mouse Y") * mouseSensitivity;
		rotationY = Mathf.Clamp(rotationY, -90f, 90f);
		transform.eulerAngles = new Vector3(rotationY, rotationX, 0f);
	}

	void CameraMouvement(){
        Vector3 PositionActuel = cameraTransform.position;
        Vector3 deltaPosition = cameraTransform.right*Input.GetAxis("Horizontal")*Time.deltaTime*30f+cameraTransform.forward*Input.GetAxis("Vertical")*Time.deltaTime*30f;
        deltaPosition.y=0f;
		cameraTransform.position = PositionActuel + deltaPosition;
    }
    
    void SpawnBalle(){
        //J'instantie la balle
        GameObject balle=Instantiate(prefab,cameraTransform.position,Quaternion.identity);

        //Récupération de son RigidBody
        Rigidbody balleRigidBody=balle.GetComponent<Rigidbody>();

        //Application d'une force initiale à la balle
        balleRigidBody.AddForce(cameraTransform.forward*1000f);
    }
    

}
