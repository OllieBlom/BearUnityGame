   using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;   

   public class PlayerCameraController : MonoBehaviour
   {
       public Transform Target;

       private Vector2 rotateVector;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateCamera();
    }

    void UpdateCamera()
    {
        transform.position = Target.position;
        transform.Rotate(new Vector3(1, 0, 0), -rotateVector.y*100*Time.deltaTime);
        transform.Rotate(new Vector3(0,rotateVector.x, 0), 100*Time.deltaTime, Space.World);
        transform.Translate(0,0,-4);
    }
    
    public void OnRotate(InputValue input)
    {
        rotateVector = input.Get<Vector2>();
    }
}
