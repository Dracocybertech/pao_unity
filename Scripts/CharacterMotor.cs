using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMotor : MonoBehaviour{
    //Liste des objets à stocker
    [SerializeField]
    List<Objet> mesObjets = new List<Objet>();

    CharacterController characterController;

    public Camera playerCamera;

    // Vitesse de déplacement
    public float walkSpeed;
    public float runSpeed;
    public float turnSpeed;
    public float jumpSpeed;

    //Gravité
    float gravity = 20f;

    //Déplacement
    Vector3 moveDirection;

    //Rotation de la caméra
    float rotationX = 0;
    public float rotationSpeed = 2.0f;
    public float rotationXLimit = 45.0f;


    void Start() {
        Cursor.visible = false; //cacher le curseur de la souris
        characterController = GetComponent<CharacterController>();
    }

    void Update() {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        float speedZ = Input.GetAxis("Vertical"); //avant/arrière
        float speedX = Input.GetAxis("Horizontal"); //gauche/droite
        float speedY = moveDirection.y; //haut/bas

        //suis-je en traind de courir ?
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speedX = speedX * runSpeed;
            speedZ = speedZ * runSpeed;
        }
        else
        {
            speedX = speedX * walkSpeed;
            speedZ = speedZ * walkSpeed;
        }

        //calcul du mouvement 
        moveDirection = forward * speedZ + right * speedX;

        if (characterController.isGrounded && Input.GetButton("Jump"))
        {
            moveDirection.y = jumpSpeed;
        } else
        {
            moveDirection.y = speedY;
        }

        //Si le joueur ne touche pas le sol
        if (!characterController.isGrounded)
        {
            //Applique la gravité * deltaTime
            //Time.deltaTime = Temps écoulé depuis la dernière frame
            moveDirection.y -= gravity * Time.deltaTime;
        }

        //Applique le mouvement
        characterController.Move(moveDirection * Time.deltaTime);


        //Rotation de la caméra

        //Input.GetAxis("Mouse Y") = mouvement de la souris haut/bas
        //On est en 3D donc applique ("Mouse Y") sur l'axe de rotation X 
        rotationX += -Input.GetAxis("Mouse Y") * rotationSpeed;

        //La rotation haut/bas de la caméra est comprise entre -45 et 45 
        //Mathf.Clamp permet de limiter une valeur
        //On limite rotationX, entre -rotationXLimit et rotationXLimit (-45 et 45)
        rotationX = Mathf.Clamp(rotationX, -rotationXLimit, rotationXLimit);

        //Applique la rotation haut/bas sur la caméra
        playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);

        //Input.GetAxis("Mouse X") = mouvement de la souris gauche/droite
        //Applique la rotation gauche/droite sur le Player
        transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * rotationSpeed, 0);
    }

    public void ramasserObjet(Objet objectToAdd)
    {
        mesObjets.Add(objectToAdd);
    }

    void lacherObjet(Objet objectToRemove)
    {
        mesObjets.Remove(objectToRemove);
    }

    public bool possedeObjet(Objet Objet)
    {
        return mesObjets.Find(obj => obj == Objet) != null;
    }
}
