using UnityEngine;
using System.Collections;

public class PlayersMovement : MonoBehaviour
{
    public float Speed = 5f;
    public GameObject Beam, display,background;
    float Rotation;
    float ShootTime;
    public float RepeatTime = 1;
    // Use this for initialization
    void Start()
    {
        ShootTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        Rotation = Input.acceleration.x;
        if (Rotation >= 0.1 && transform.position.x < 2.5)
        {
            transform.position = new Vector3(transform.position.x + (Speed * Time.deltaTime), transform.position.y, transform.position.z);
        }
        if (Rotation <= -0.1 && transform.position.x > -2.5)
        {
            transform.position = new Vector3(transform.position.x - (Speed * Time.deltaTime), transform.position.y, transform.position.z);
        }
        if (Time.time > ShootTime)
        {
            ShootTime = Time.time + RepeatTime;
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(Beam, new Vector3(transform.position.x + 0.33f, transform.position.y + 0.8f, transform.position.z), Quaternion.identity);
        Instantiate(Beam, new Vector3(transform.position.x - 0.33f, transform.position.y + 0.8f, transform.position.z), Quaternion.identity);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        {
            Debug.Log(col.gameObject.tag);
            if (col.gameObject.tag != "playerBeam")
            {
                display.SetActive(true);
                Deadnotice notice = display.GetComponent<Deadnotice>();
                notice.Display();
                CreateEnemies ce = background.GetComponent<CreateEnemies>();
                Background bg = background.GetComponent<Background>();
                bg.PlayerDead();
                ce.PlayerDead();
                Destroy(col.gameObject);
                Destroy(gameObject);
            }
        }
    }
}
