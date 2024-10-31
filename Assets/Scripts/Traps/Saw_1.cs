using UnityEngine;

public class Saw_1 : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private float movementDistance;
    [SerializeField] private float speed;
    private bool movingLeft;
    private float upEdge;
    private float downEdge;

    private void Awake()
    {
        upEdge = transform.position.y - movementDistance;
        downEdge = transform.position.y + movementDistance;
    }
    private void Update()
    {
        if (movingLeft)
        {
            if (transform.position.y > upEdge)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - speed * Time.deltaTime,  0);
            }
            else
                movingLeft = false;
        }
        else
        {
            if (transform.position.y < downEdge)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + speed * Time.deltaTime, 0);
            }
            else
                movingLeft = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Health>().TakeDamage(damage);
        }
    }
}
