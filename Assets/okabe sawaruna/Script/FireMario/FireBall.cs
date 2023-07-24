using UnityEngine;

public class FireBall : MonoBehaviour
{
    [SerializeField] float _speed = 1f;
   

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject);
        }
    }
    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player)
        {
            Vector2 v = this.transform.position - player.transform.position;
            v = v.normalized * _speed;

            // 速度ベクトルをセットする
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.velocity = v;
        }
        Destroy(this.gameObject, 2f);
    }
}
