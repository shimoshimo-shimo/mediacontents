using UnityEngine;

public class MajoController : MonoBehaviour
{
    Animator animator;
    float moveSpeed = 4;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = (x == 0) ? Input.GetAxisRaw("Vertical") : 0.0f;

        if (x != 0 || y != 0)
        {
            animator.SetFloat("x", x);
            animator.SetFloat("y", y);
        }

        //“®‚­
        transform.position += new Vector3(x, y) * Time.deltaTime * moveSpeed;
    }
}
