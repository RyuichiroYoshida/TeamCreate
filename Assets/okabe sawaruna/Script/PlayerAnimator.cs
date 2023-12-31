using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator _anim = null;
    void Start()
    {
        _anim = GetComponent<Animator>();
    }
    private void Update()
    {
        if (!GameManager.instance.IsGameOver)
        {
            float horizontalKey = Input.GetAxis("Horizontal");  //InputManagerのHorizontal
            float jumpKey = Input.GetAxis("Jump");
            if (horizontalKey > 0)
            {
                transform.localScale = new Vector3(1, 1, 1);
                _anim.SetBool("Run", true);
            }
            else if (horizontalKey < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
                _anim.SetBool("Run", true);
            }
            else
            {
                _anim.SetBool("Run", false);
            }
            //ジャンプ
            if (jumpKey > 0)
            {
                _anim.SetBool("Jump", true);
                //_anim.SetBool("Stand",false);
            }
        }
    }
    public void IsGround()
    {
        _anim.SetBool("Jump", false);
    }
}
