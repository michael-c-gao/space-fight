using UnityEngine;
using UnityEngine.UI;

public class Shoot : MonoBehaviour
{
    public Camera cam;

    private float nextShot = 0f;

    public float count;
    public float Damage = 10f;
    public float fireRate = 15f;

    public static float maxCount = 50;
    
    public GameObject impact;
    bool activeWeapon = false;

    public Image abilityBar;
    
    [SerializeField] ParticleSystem attackParticle;


    void shootGun()
    {
        RaycastHit hit;
        if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hit)){
            Enemy enemy = hit.transform.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.BulletHit(Damage);
                count += 1;
            }

            GameObject impactMark = Instantiate(impact, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactMark, 3f);
        }
    }

    void weaponCheck()
    {
        if (Gun.currWeapon != 1)
        {
            activeWeapon = Input.GetMouseButtonDown(0);
        }
        else
        {
            activeWeapon = Input.GetMouseButton(0);
        }
    }

    void Update()
    {
        weaponCheck();

        if (activeWeapon && (Time.time >= nextShot) && !GameOver.isGameOver)
        {
            nextShot = Time.time + 4 / fireRate;
            attackParticle.Play();
            shootGun();
        }

        abilityBar.fillAmount = (count / maxCount);
    }
}
