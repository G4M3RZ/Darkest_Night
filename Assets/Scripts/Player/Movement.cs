using UnityEngine;

public class Movement : MonoBehaviour {

    [Range(0,20)]
    public float _moveSpeed;
    [HideInInspector]
    public Rigidbody2D _rgb;

    private void Awake()
    {
        _rgb = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate ()
    {
        float h = Input.GetAxis("Horizontal");

        Vector2 temporalVelocity = _rgb.velocity;
        float movimientoPlayer = h * _moveSpeed;

        temporalVelocity.x = movimientoPlayer;
        _rgb.velocity = temporalVelocity;

        Flip(h);
    }
    private void Flip(float movement)
    {
        if(movement > 0)
        {
            Vector3 theScale = transform.localScale;
            theScale.x = 1;
            transform.localScale = theScale;
        }
        if (movement < 0)
        {
            Vector3 theScale = transform.localScale;
            theScale.x = -1;
            transform.localScale = theScale;
        }
    }
}