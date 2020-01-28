using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerScript : MonoBehaviour {

    //  public Camera mainCamera;
    public GameObject weapon;

    private Rigidbody2D rb;

    private Vector2 dir;
    public float speed;

    public Transform cirTarg;
    public float jumpForce = 20f;
    private float radCir = 0.5f;

    private float fireRate = 0.2f;
    private float nextFire;
    private float curTime;

    public bool isRight = true;

    // Use this for initialization
    void Start() {

        rb = GetComponent<Rigidbody2D>();
        GameObject[] chekers = GameObject.FindGameObjectsWithTag("cheker");

        foreach (GameObject cheker in chekers) {
            cirTarg = cheker.transform;
        }
        curTime = 0;
        nextFire = fireRate;
    }

    
    void CheckRotation()
    {
        float weaponRotation = weapon.transform.eulerAngles.z;

        if (270f - weaponRotation > 0)
        {
            weaponRotation = Mathf.Floor(weaponRotation);
        }
        else
        {
            weaponRotation = Mathf.Ceil(weaponRotation);
        }

        //Debug.Log(weaponRotation);
        if ((weaponRotation > 100f && weaponRotation < 270f) && isRight)
        {

            Flip();

        }
        else if ((weaponRotation > 100f && weaponRotation < 270f) && !isRight)
        {
            //Debug.Log(weaponRotation);
            Flip();
        }
    }
    // Update is called once per frame
    void Update()
    {
        curTime += Time.deltaTime;
        CheckRotation();
        getInput();
        rb.velocity = new Vector2(dir.x * speed, rb.velocity.y); //dir * Time.deltaTime * 60 * 5;
    }

    void getInput()
    {
        dir = Vector2.zero;

        if (Input.GetKey(KeyCode.A))
        {
            dir = Vector2.left;
           // if (isRight) Flip();
        }

        if (Input.GetKey(KeyCode.D))
        {
            dir = Vector2.right;

            //if ( !isRight ) Flip();

        }

        if (Input.GetButtonDown("Jump") && onGround())
        {
            Jump();
        }

        if ( Input.GetKey(KeyCode.Mouse0) )
        {
            if ( curTime >= nextFire ) Fire();
        }
    }

    void Flip()
    {
        isRight = !isRight;
        weapon.GetComponent<WeaponLogic>().IsRight = !weapon.GetComponent<WeaponLogic>().IsRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void Fire()
    {
        var bulletPrefab = weapon.GetComponent<WeaponLogic>().bulletType;
        var firePoint = weapon.GetComponent<WeaponLogic>().firePoint;
        var bulletDir = firePoint.right;

        if (!isRight) bulletDir = -bulletDir;

        var bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.Euler( 0, 0, weapon.transform.rotation.eulerAngles.z + 270));

        var mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Rigidbody2D bulletRB = bullet.GetComponent<Rigidbody2D>();
        bulletRB.AddForce(bulletDir * 15f, ForceMode2D.Impulse);

        nextFire = curTime + fireRate;
    }

    bool onGround()
    {
        Collider2D[] og = Physics2D.OverlapCircleAll(cirTarg.position, radCir);
        int j = 0;
        for (int i = 0; i < og.Length; i++)
        {
            if (og[i].gameObject != gameObject)
                j++;
        }
        return j > 0;
    }

    // Function jump
    public void Jump()
    {

        rb.AddForce(new Vector2(0f, jumpForce));
    }

}
