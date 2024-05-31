using UnityEngine;

public class DestroyOak : MonoBehaviour
{
    public GameObject effect;
    public Animator animator;
    BoxCollider2D coll;
    bool On = true;

    private void Start()
    {
        animator = GetComponent<Animator>();
        coll = GetComponent<BoxCollider2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "MagBall")
        {
            animator.SetBool("OnDestroy", On == true);
            Invoke("Stadia1", 0.25f);
            Invoke("DestroyObj", 0.8f);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Slash")
        {
            animator.SetBool("OnDestroy", On == true);
            Invoke("Stadia1", 0.25f);
            Invoke("DestroyObj", 0.8f);
        }
    }
    void Stadia1()
    {
        Instantiate(effect, transform.position, transform.rotation);
        coll.isTrigger = true;
    }
    void DestroyObj()
    {
        Destroy(gameObject);
    }
}
