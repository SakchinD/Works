using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] DynamicJoystick joystick;
    [SerializeField] float _speed;
    [SerializeField] GameObject _sick;
    public Collider sickCol;
    public bool _isCut;
    Rigidbody _rb;
    Animator _animator;
    public StackController stack;
    public Animator animator { get { return _animator = _animator ?? GetComponent<Animator>(); } }
    public Rigidbody rb { get { return _rb = _rb ?? GetComponent<Rigidbody>(); } }

    void Start()
    {
        _sick.SetActive(false);
    }

    void FixedUpdate()
    {
        var input = new Vector3(joystick.Horizontal, 0, joystick.Vertical);
        if (input.x != 0 || input.y != 0)
        {
            transform.rotation = Quaternion.LookRotation(input);
            animator.SetBool("Run", true);
        }
        else
        {
            animator.SetBool("Run", false);
        }
        if (!_isCut)
        {
            rb.velocity = input * _speed;
        }
    }
    private void OnTriggerStay(Collider trig)
    {
        if (trig.CompareTag("Wheat"))
        {
            animator.SetBool("Cut",true);
        }
        else
        {
            animator.SetBool("Cut", false);
        }
        if (trig.CompareTag("Sale"))
        {
            StartCoroutine(stack.Sale());
        }
    }
    public void EnableSick()
    {
        sickCol.enabled = true;
    }
    public void EndCuting()
    {
        animator.SetBool("Cut", false);
        _isCut = false;
        sickCol.enabled = false;
        _sick.SetActive(false);
            
    }
    public void StartCuting()
    {
        _isCut = true;
        _sick.SetActive(true);
    }
}

