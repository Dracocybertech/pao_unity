//Make an empty GameObject and call it "Door"
//Drag and drop your Door model into Scene and rename it to "Body"
//Make sure that the "Door" Object is at the side of the "Body" object (The place where a Door Hinge should be)
//Move the "Body" Object inside "Door"
//Add a Collider (preferably SphereCollider) to "Door" object and make it bigger then the "Body" model
//Assign this script to a "Door" Object (the one with a Trigger Collider)
//Make sure the main Character is tagged "Player"
//Upon walking into trigger area press "F" to open / close the door

using UnityEngine;
using static Clef;

public class PorteV3 : MonoBehaviour
{
    // Smoothly open a door
    public AnimationCurve openSpeedCurve = new AnimationCurve(new Keyframe[] { new Keyframe(0, 1, 0, 0), new Keyframe(0.8f, 1, 0, 0), new Keyframe(1, 0, 0, 0) }); //Contols the open speed at a specific time (ex. the door opens fast at the start then slows down at the end)
    public float openSpeedMultiplier = 2.0f; //Increasing this value will make the door open faster
    public float doorOpenAngle = 90.0f; //Global door open speed that will multiply the openSpeedCurve

    public bool verrouille = false;
    public Clef nomCle;

    bool open = false;
    bool enter = false; //je suis dans le collider et à proximité de la poignée de porte.
    bool guiLocked = false;
    bool peutDeverrouiller = false;

    float defaultRotationAngle;
    float currentRotationAngle;
    float openTime = 0;

    void Start()
    {
        defaultRotationAngle = transform.localEulerAngles.y;
        currentRotationAngle = transform.localEulerAngles.y;

        //Set Collider as trigger
        GetComponent<Collider>().isTrigger = true;
    }

    // Main function
    void Update()
    {
        if (openTime < 1)
        {
            openTime += Time.deltaTime * openSpeedMultiplier * openSpeedCurve.Evaluate(openTime);
        }
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, Mathf.LerpAngle(currentRotationAngle, defaultRotationAngle + (open ? doorOpenAngle : 0), openTime), transform.localEulerAngles.z);





        if (Input.GetKeyDown(KeyCode.F) && enter && verrouille && !peutDeverrouiller) //la porte est verrouillée donc on le dit au joueur.
        {
            guiLocked = true;

        }


        if (Input.GetKeyDown(KeyCode.F) && enter && !verrouille)
        {
            open = !open;
            currentRotationAngle = transform.localEulerAngles.y;
            openTime = 0;
        }


        if (Input.GetKeyDown(KeyCode.G) && enter && peutDeverrouiller)
        {
            guiLocked = false;
            peutDeverrouiller = false;
            verrouille = false;

        }

    }

    void OnGUI()
    {
        if (enter)
        {
            if (!guiLocked && !peutDeverrouiller) //Porte déverrouillée
                GUI.Label(new Rect(Screen.width / 2 - 75, Screen.height - 100, 155, 30), "Press 'F' to " + (open ? "close" : "open") + " the door");

            if (guiLocked) //Porte verrouillée mais pas la clé dans l'inventaire
                GUI.Label(new Rect(Screen.width / 2 - 75, Screen.height - 100, 155, 30), "Door locked. Find the key");

            if (peutDeverrouiller) // Porte verrouillée mais clé dans l'inventaire.
                GUI.Label(new Rect(Screen.width / 2 - 75, Screen.height - 100, 155, 30), "Press 'G' to unlock");

        }


    }
    //

    // Activate the Main function when Player enter the trigger area
    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            enter = true; //je suis dans le collider

            //Le joueur a t il la clé ?
            if (other.GetComponent<CharacterMotor>().possedeObjet(this.nomCle) && verrouille)
            {
                    peutDeverrouiller = true;
                    guiLocked = false;
            }



        }

    }

    // Deactivate the Main function when Player exit the trigger area
    void OnTriggerExit(Collider other)
    {
        if (other.name == "Player")
        {
            enter = false;
            guiLocked = false;
        }
    }
}
