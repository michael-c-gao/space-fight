using UnityEngine;
using UnityEngine.UI;

public class Shoot : MonoBehaviour
{
    public Camera cam;

    private float nextShot = 0f;

    public static float count;
    public float Damage = 10f;
    public float fireRate = 15f;
    public TrailRenderer tracerRound;
    public GameObject gunBarrel;

    public static float maxCount = 50;
    
    public GameObject impact;
    bool activeWeapon = false;
    public GameObject sniperScope;

    public Image abilityBar;
    private static bool isADS = false;
    private static bool swappedADS = false;
    
    [SerializeField] ParticleSystem attackParticle;


    void shootGun()
    {
        RaycastHit hit;
        
        if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hit)){
            var tracer = Instantiate(tracerRound, gunBarrel.transform.position, Quaternion.identity);
            tracer.AddPosition(gunBarrel.transform.position);
            Enemy enemy = hit.transform.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.BulletHit(Damage);
                count += 1;
            }
            tracer.transform.position = hit.point;
            GameObject impactMark = Instantiate(impact, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactMark, 3f);
        }
    }

    void weaponCheck(int currGun)
    {
        switch (currGun)
        {
            case 0:
                activeWeapon = Input.GetMouseButtonDown(0);
                swapADS();
                break;
            case 1:
                activeWeapon = Input.GetMouseButton(0);
                swapADS();
                break;
            case 2:
                activeWeapon = Input.GetMouseButtonDown(0);
                ADS();
                break;
        }
    }

    void ADS()
    {
        if (Input.GetMouseButtonDown(2)) {
            if (!isADS) {
                cam.fieldOfView = 30.0f;
            }
            else
            {
                cam.fieldOfView = 60.0f;
            }
            sniperScope.SetActive(!isADS);
            isADS = !isADS;
            swappedADS = !swappedADS;
        }
    }

    void swapADS()
    {
        if (swappedADS)
        {
            //bool check so camera is not continually set to 60 degrees over and over
            sniperScope.SetActive(false);
            cam.fieldOfView = 60.0f;
            isADS = false;
            swappedADS = false;
        }
    }


    void Update()
    {
        if (!GameOver.isGameOver && !Pause.isPaused) {
            weaponCheck(Gun.currWeapon);
            if (activeWeapon && (Time.time >= nextShot) && !GameOver.isGameOver && !Pause.isPaused)
            {
                nextShot = Time.time + 4 / fireRate;
                attackParticle.Play();
                shootGun();
                if (isADS && Gun.currWeapon == 2)
                {
                    sniperScope.SetActive(false);
                    cam.fieldOfView = 60.0f;
                }
            }

            abilityBar.fillAmount = (count / maxCount);
        }
    }
}
