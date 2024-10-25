using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Camera Cam;
    public Transform RayObject;

    public Transform GunHole;
    public GameObject Bullet;
    public GameObject DamageFX;
    public GameObject DeathFX;

    public Image HealthBar;

    public float Health = 0f;

    public float Speed = 1f;
    public float ShootForce = 20f;

    public bool Dead = false;

    Plane plane = new Plane(Vector3.up, Vector3.zero);

    public void Start()
    {
        HealthBar.fillAmount = Health;
    }

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

    public void Damage(float damage)
    {
        if (Dead) return;

        if(DamageFX != null)
        {
            Instantiate(DamageFX, transform.position, transform.rotation);
        }
        Health -= damage;
        Health = Mathf.Max(0, Health);
        HealthBar.fillAmount = Health;

        if(Health <= 0 && !Dead)
        {
            if(DeathFX != null)
            {
                Instantiate(DeathFX, transform.position, transform.rotation);
            }
            gameObject.SetActive(false);
            Dead = true;
        }
    }
}
