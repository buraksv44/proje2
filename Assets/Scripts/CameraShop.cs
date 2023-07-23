using System.Collections;
using UnityEngine;

public class CameraShop : MonoBehaviour
{
    public Transform turnPosition, shopPosition,startPosition, rotate;
    float yRotation,zRotation;
    Shop shop;
    bool arrived;

    private void Awake()
    {
        shop = FindObjectOfType<Shop>();
        StartCoroutine("TrainArrive");
    }
    
    private void Update()
    {
        if (!shop.shopOpened)
        {
            RotateCam();
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, shopPosition.position, Time.deltaTime*5);
            transform.rotation = Quaternion.Lerp(transform.rotation, shopPosition.rotation, Time.deltaTime*5);
        }
    }
    void RotateCam() 
    {
        if (Input.GetMouseButton(0) && arrived)
        {
            float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * 250;
            float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * 250;

            yRotation += mouseX;
            zRotation += mouseY;
            zRotation = Mathf.Clamp(zRotation, -40f, 10f);
        }
        if (arrived)
        {
            transform.position = Vector3.Lerp(transform.position, turnPosition.position, Time.deltaTime * 5);
            transform.rotation = Quaternion.Lerp(transform.rotation, turnPosition.rotation, Time.deltaTime * 5);
            rotate.rotation = Quaternion.Euler(0, yRotation, zRotation);
        }
    }

    IEnumerator TrainArrive() 
    {
        transform.position = startPosition.position;
        yield return new WaitForSeconds(1.5f);
        arrived = true;
    }
}
