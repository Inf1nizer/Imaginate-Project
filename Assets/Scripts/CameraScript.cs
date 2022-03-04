using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public float mouseSenstivity = 100f;
    public Transform PlayerBody;
    float xRot = 0f;
    RaycastHit hit;
    GameObject grabbedOBJ;
    public Transform grabPos;
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSenstivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSenstivity * Time.deltaTime;

        xRot -= mouseY;
        xRot = Mathf.Clamp(xRot, -60f, 60f);
        transform.localRotation = Quaternion.Euler(xRot, 0, 0);

        PlayerBody.Rotate(Vector3.up * mouseX);
        if(Input.GetMouseButtonDown(0) && Physics.Raycast(transform.position, transform.forward, out hit, 5) && hit.transform.GetComponent<Rigidbody>())
        {
            grabbedOBJ = hit.transform.gameObject;
        }
        else if(Input.GetMouseButtonUp(0))
        {
            grabbedOBJ = null; 
        }
        if(grabbedOBJ)
        {
            grabbedOBJ.GetComponent<Rigidbody>().velocity = 10 * (grabPos.position - grabbedOBJ.transform.position);
        }
    }

}
