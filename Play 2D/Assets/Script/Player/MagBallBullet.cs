using UnityEngine;

public class MagBallBullet : MonoBehaviour
{
    private float speed = 24;
    public Animator anim;
    bool OnAnim = false;
    int LifeTime = 5;
    public static bool Destr = false;
    void Update()
    {
        if (Destr == true)
        {
            DestroyBall();
        }
        InvokeRepeating("LifeMinus", 5, 5);
        anim.SetBool("OnDestroyBall", OnAnim == true);
        if(LifeTime <= 0)
        {
            Destroy(gameObject);
        }
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
    private void DestroyBall()
    {
        Destroy(gameObject);
    }
    void LifeMinus()
    {
        LifeTime -= 1;
    }
}
