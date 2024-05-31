using UnityEngine;

public class SpawnMagicBall : AUDIO
{
    public GameObject bullet;
    public Transform shotPoint;
    public float offset;
    public bool Mattack = true;
    public GameObject MagicBallLight;
    bool OnSpawnMagBall = true;
    void Update()
    {
        Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);

        float Hor = Input.GetAxis(OpinionKey.Hor);

        if (Input.GetKeyDown(OpinionKey.shoot) && OnSpawnMagBall == true && Player_Controller.onGrab == false && Player_Controller.StopAction == false && Player_Controller.OnGround == false && Mattack == true && Player_Controller.Stam >= 20 && Player_Controller.Mana >= 40 && Hor == 0 && Player_Controller.learnedMagicBall == true)
        {
            OnSpawnMagBall = false;
            Mattack = false;
            Invoke("ReMAttack", 0.55f);
            Player_Controller.Stam -= 20;
            Player_Controller.Mana -= 40;
            MagicBallLight.SetActive(true);
            Invoke("Spawn", 0.4f);
            PlaySounnd(sounds[0], p1: 0.85f, p2: 1.2f);
        }
    }
    void Spawn()
    {
        Instantiate(bullet, shotPoint.position, transform.rotation);
    }
    void StopMagicAttackAnim()
    {
        MagicBallLight.SetActive(false);
    }
    void ReMAttack()
    {
        Mattack = true;
        OnSpawnMagBall = true;
    }
}
