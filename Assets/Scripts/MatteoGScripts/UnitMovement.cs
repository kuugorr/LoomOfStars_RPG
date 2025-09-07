using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UnitMovement : MonoBehaviour
{
    public Camera playerCamera;
    public float walkSpeed = 6f;
    public float runSpeed = 12f;
    public float jumpPower = 7f;
    public float gravity = 20f;
    public float lookSpeed = 2f;
    public float lookXLimit = 45f;
    public float defaultHeight = 2f;
    public float crouchHeight = 1f;
    public float crouchSpeed = 3f;

    private Vector3 moveDirection = Vector3.zero;
    private float rotationX = 0;
    private CharacterController characterController;
   // public LayerMask Ground;

    private bool canMove = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //variabili inizializzate 
        characterController = GetComponent<CharacterController>(); //questa è l'entita CharacterController legata all'oggetto player che serve per muoverlo
        Cursor.lockState = CursorLockMode.Locked; //blocco il cursore al centro dello schermo
        Cursor.visible = false; //rendo invisibile il cursore
        // Ground = LayerMask.GetMask("Terrain"); serve devo sapere se il terreno è sotto il player non usato per ora, non so come usarlo 
    }

    // Update is called once per frame
    void Update()
    {
        //istanzio le variabili per il movimento del player, in avanti e destra che questo dipende dalla rotazione del player
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        //controllo se il player sta correndo o camminando tenendo premuto il tasto shift 
        bool isRunning = Input.GetKey(KeyCode.LeftShift);

        //calcolo la velocità del player in base al tasto premuto, se non può muoversi la velocità è 0
        float curSpeedX = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Horizontal") : 0;
        
        //salvo la direzione y del movimento per non perderla quando salto
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        //se il player preme il tasto spazio e può muoversi e sta a terra allora salta
        if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
        {
            moveDirection.y = jumpPower;
        }
        //se no mantiene la direzione y che aveva prima
        else
        {
            moveDirection.y = movementDirectionY;
        }

        //applico la gravità al player se non è a terra
        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        //se il player preme il tasto ctrl o r si abbassa e cammina più lentamente
        if (Input.GetKey(KeyCode.R) && canMove)
        {
            characterController.height = crouchHeight;//al posto di questo si potrebbe fare una animazione di abbassamento
            walkSpeed = crouchSpeed;
            runSpeed = crouchSpeed;

        }
        //se no torna alla sua altezza normale e velocità normale
        else
        {
            characterController.height = defaultHeight;//animazione di rialzamento e idle
            walkSpeed = 6f;
            runSpeed = 12f;
        }

        //muovo il player in base alla direzione calcolata
        characterController.Move(moveDirection * Time.deltaTime);
        
        //controllo la rotazione del player in base al movimento del mouse
        if (canMove)
        {

            //logica per non far ruotare la camera oltre un certo angolo in alto e in basso / da rivedere in caso volessi un angolo di visuale più ampio o fisso
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }
    }
}
