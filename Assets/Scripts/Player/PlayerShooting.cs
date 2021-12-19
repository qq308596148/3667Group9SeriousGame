using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public float gunBetweenTime = 0.15f;
    public float gunDisplayTime = 0.2f;
    AudioSource gunAudio;
    Ray gunRay;
    RaycastHit gunHit;
    Light gunLight;
    LineRenderer gunLine;

    public int atk = 20;
    LayerMask layerMask;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        gunAudio = GetComponent<AudioSource >();
        gunLight = GetComponent<Light>();
        gunLine = GetComponent<LineRenderer>();
        layerMask = LayerMask.GetMask("shootable");
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (Input.GetButton("Fire1") && timer > gunBetweenTime)
        {
            shoot();
        }
        if(timer > gunBetweenTime * gunDisplayTime)
        {
            disableGun();
        }
    }
    void shoot()
    {
        timer = 0;
        gunAudio.Play();
        gunLight.enabled = true;
        gunLine.enabled = true;
        gunRay.origin = transform.position;
        gunRay.direction = transform.right;

        gunLine.SetPosition(0,transform.position);
        if(Physics.Raycast(gunRay, out gunHit, 100f, layerMask))
        {
            EnemyHealth enmyHealth = gunHit.collider.GetComponent<EnemyHealth>();
            if(enmyHealth != null)
            {
                enmyHealth.OnAttack(atk);
            }
            gunLine.SetPosition(1,gunHit.point);
        }
        else
        {
            gunLine.SetPosition(1, gunRay.origin + gunRay.direction * 100f);
        }
    }
    public void disableGun()
    {
        gunLight.enabled = false;
        gunLine.enabled = false;
    }
}
