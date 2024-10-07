using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private Transform camera;
    private float inputH;
    private float inputV;
    private CharacterController controller;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
       controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        inputH = Input.GetAxis("Horizontal");
        inputV = Input.GetAxis("Vertical");
        Vector3 dirMovement = (camera.forward * inputV + camera.right * inputH).normalized;
        dirMovement.y = 0;
        controller.Move(dirMovement * movementSpeed*Time.deltaTime);

        if (inputH != 0 || inputV != 0)
        {
            RotateToDestiny(dirMovement);
        }
    }

    private void RotateToDestiny(Vector3 destiny) { 
    
    Quaternion rotationGoal =  Quaternion.LookRotation(destiny);
    transform.rotation = rotationGoal;

    }

}
