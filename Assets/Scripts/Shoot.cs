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

    void weaponCheck()
    {
        if (Gun.currWeapon != 1)
        {
            activeWeapon = Input.GetMouseButtonDown(0);
            print(activeWeapon);
        }
        else
        {
            activeWeapon = Input.GetMouseButton(0);
            
        }
    }

    void ADS()
    {

        if(Gun.currWeapon == 2){
            if (Input.GetMouseButtonDown(2) && !isADS) {
                cam.fieldOfView = 30.0f;
                sniperScope.SetActive(true);
                isADS = true;
                swappedADS = true;

            }
            else if (Input.GetMouseButtonDown(2) && isADS) {
                cam.fieldOfView = 60.0f;
                sniperScope.SetActive(false);
                isADS = false;
                swappedADS = false;
            }
        }
        else
        {
            if (swappedADS)
            {
                //bool check so camera is not contulally set to 60 degrees over and over
                sniperScope.SetActive(false);
                cam.fieldOfView = 60.0f;
                isADS = false;
                swappedADS = false;
            }
        }
    }

    void Update()
    {
        weaponCheck();
        ADS();
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
