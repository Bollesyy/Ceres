using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_AI : MonoBehaviour
{


    public Transform Player;
    int  MoveSpeed = 1;
    int MaxDist = 10;
    int MinDist = 5;
    int floorLevel = 0;

    float xpos;
    float ypos;

    bool onLadder = false;




    private void Start()
    {

    }

    private void Update()
    {
        if (transform.position.x >= Player.position.x)
        {
            //Debug.LogError("PLAYER IS ON LEFT");
            xpos = 1;
            //transform.position -= new Vector3( MoveSpeed * Time.deltaTime, (transform.position.y - Player.transform.position.y) *  MoveSpeed * Time.deltaTime);
        }
        else
        {
            //Debug.LogError("PLAYER IS ON right");
            xpos = -1;
        }

        if (transform.position.y >= Player.position.y)
        {
            //Debug.LogError("PLAYER IS below");
            ypos = 1;
        }
        else
        {
            //Debug.LogError("PLAYER IS Above");
            ypos = -1;
        }

        //If the player is above a certain height (if transform.y <= player.transform.y)

        if (transform.position.y < Player.transform.position.y)
        {
            print("FloorLevel"  + floorLevel);
            switch (floorLevel)
            {
                case 1:
                    xpos = -1;
                    break;
                case 2:
                    xpos = 1;
                    break;
                case 3:
                    xpos = -1;
                    break;
                case 4:
                    xpos = 1;
                    break;
                default:
                    break;
            }
        }


        if (!onLadder)
        {
            GetComponent<Rigidbody2D>().WakeUp();
            if (xpos < 0)
                transform.position += Vector3.right * .01f;
            else
                transform.position += Vector3.left * .01f;

        }
        else
        {
            transform.position += Vector3.up * .01f;
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        print(collision.gameObject.name);
        if (collision.gameObject.tag == "Ladder")
        {
            GetComponent<Rigidbody2D>().Sleep();
            onLadder = true;
            print("IM on a ladder");
            Invoke("offOfLadder", 2f);
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("HiT FLOOR LEVEL: " + collision.gameObject.name);

        StartCoroutine(SwtichFloors(collision));
    }

    private IEnumerator SwtichFloors(Collision2D collision)
    {
        yield return new WaitForSeconds(2.8f);
        switch (collision.gameObject.tag)
        {
            case "Floor1":
                floorLevel = 1;
                break;
            case "Floor2":
                floorLevel = 2;
                break;
            case "Floor3":
                floorLevel = 3;
                break;
            case "Floor4":
                floorLevel = 4;
                break;
            default:
                break;
        }
    }

    private void offOfLadder()
    {
        onLadder = false;
    }

}
//	public int PlayerDamage;

//	private Animator animator;
//	private Transform target;

//	void Start()
//	{
//		target = GameObject.FindGameObjectWithTag ("Player").transform;
//	}

//	void Update ()
//	{
//		MoveEnemy ();
//	}

//	public void MoveEnemy ()
//	{

//	    int xDir = 0;
//	    int yDir = 0;

//	if (Mathf.Abs (target.position.x - transform.position.x) < float.Epsilon)
//        {
//			//yDir = target.position.y > transform.position.y ? 1 : 1 ;

//	    }
//	//If the difference in positions is not approximately zero (Epsilon) do the following:
//	else
//	{
//		//Check if target x position is greater than enemy's x position, if so set x direction to 1 (move right), if not set to -1 (move left).
//		xDir = target.position.x > transform.position.x ? 1 : -1;
//    }
//}
//}
