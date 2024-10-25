using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Camera Cam;
    public Transform RayObject;

    public Transform GunHole;
    public GameObject Bullet;

    public float Speed = 1f;
    public float ShootForce = 20f;
    Plane plane = new Plane(Vector3.up, Vector3.zero);

    void Update(){
        transform.position += Vector3.forward * Time.deltaTime * Input.GetAxis("Vertical") * Speed;
        transform.position += Vector3.right * Time.deltaTime * Input.GetAxis("Horizontal") * Speed;

        Ray ray = Cam.ScreenPointToRay(Input.mousePosition);
        plane.Raycast(ray, out float distance);
        Vector3 CursorPoint = ray.GetPoint(distance);
        RayObject.position = CursorPoint;
        transform.LookAt(CursorPoint);

        if(Input.GetKeyDown(KeyCode.Mouse0)){
            var bullet = Instantiate(Bullet, GunHole.position, GunHole.rotation);
            bullet.GetComponent<Rigidbody>().velocity = GunHole.forward * 20f;
            Destroy(bullet, 10);
        }
    }
}
