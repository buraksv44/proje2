using UnityEngine;

public class CameraHolder : MonoBehaviour
{
    public Transform cameraPosition;

    //public Animator cameraAnim;
    private void Update()
    {
        transform.position = cameraPosition.position;
        //if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        //{
        //    cameraAnim.SetTrigger("walk");
        //}
        //else 
        //{
        //    cameraAnim.SetTrigger("idle");   
        //}
    }

}
