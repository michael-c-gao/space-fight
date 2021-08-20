using UnityEngine;
using UnityEngine.UI;

public class Shoot : MonoBehaviour
{

    public float Damage = 10f;
    public float fireRate = 15f;
    private float nextShot = 0f;
    public float count;
    public Camera cam;
    [SerializeField] ParticleSystem attackParticle;
    public GameObject impact;
    public Image abilityBar;
    public static float maxCount = 50;


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


    void Update()
    {


        if (Input.GetMouseButtonDown(0) && (Time.time >= nextShot) && !GameOver.isGameOver)
        {
            nextShot = Time.time +  4/fireRate;
            attackParticle.Play();
            shootGun();
           

        }
        abilityBar.fillAmount = (count / maxCount);
    }
}
