using UnityEngine;
using UnityEngine.Animations;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1000f;
    [SerializeField] private float jumpForce = 10f;
    private Rigidbody _rb;
    private Animator _anim;
    private string currName;
    public LayerMask GroundLayer;
    private bool isGround;
    private string currentAnim;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       // isGround = checkGround();
        Move();
        Jump();
    }
    public void Move()
    {
        float xAxis = Input.GetAxisRaw("Horizontal");

        if (Mathf.Abs(xAxis) > 0.1f)
        {
            changeAnimation("run");
            _rb.linearVelocity = new Vector2(xAxis * moveSpeed*Time.deltaTime, _rb.linearVelocity.y);
            var rotate = (xAxis) > 0 ? 0 : -180;
            transform.rotation = Quaternion.Euler(0,rotate,0);
        }
        else
        {
            changeAnimation("idle");
            _rb.linearVelocity = new Vector2(0,_rb.linearVelocity.y);
        }
    }
    public void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            changeAnimation("jump");
            _rb.AddForce(new Vector2(_rb.linearVelocity.x, jumpForce * Time.deltaTime), (ForceMode)ForceMode2D.Impulse);
        }
    }
    public void changeAnimation(string Animname)
    {
        if (currentAnim != Animname)
        {
            _anim.ResetTrigger(Animname);
            currentAnim = Animname;
            _anim.SetTrigger(Animname);
        }
    }
    public void checkGround()
    {

    }
}
