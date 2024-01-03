using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Move : MonoBehaviour
{
    public float speed;
    public float runspeed;
    public float jumpspeed;
    public float rotationSpeed;

    public bool isjump = false;

    public bool iswalk = true;
    public bool isrun = false;
    public bool islook = false;
    //public bool isattack = false;

    public bool ismove = false;

    private Animator animator;



    // Start is called before the first frame update
    void Start()
    {
        speed = 6;
        runspeed = 10;
        jumpspeed = 6;
        rotationSpeed = 5;

        isjump = false;
        iswalk = true;
        isrun = false;
        islook = false;
        //isattack = false;
        ismove = false;

        animator = GetComponent<Animator>();

}

// Update is called once per frame
void Update()
    {
        
        // ��·
        if (Input.GetKey(KeyCode.W))
        {
            
            ismove = true;
            if (iswalk)
            {
                transform.Translate(Vector3.forward * Time.deltaTime * speed);

            }
            else
            {
                transform.Translate(Vector3.forward * Time.deltaTime * runspeed);
            }

/*            Debug.Log("w");*/
        }

        if (Input.GetKey(KeyCode.S))
        {

            ismove = true;
            if (iswalk)
            {
                transform.Translate(Vector3.back * Time.deltaTime * speed);

            }
            else
            {
                transform.Translate(Vector3.back * Time.deltaTime * runspeed);
            }

            //transform.Translate(Vector3.back * Time.deltaTime * speed);
            //Debug.Log("s");
        }

        if (Input.GetKey(KeyCode.A))
        {
           
            ismove = true;
            if (iswalk)
            {
                transform.Translate(Vector3.left * Time.deltaTime * speed);

            }
            else
            {
                transform.Translate(Vector3.left * Time.deltaTime * runspeed);
            }
            //transform.Translate(Vector3.left * Time.deltaTime * speed);
            //Debug.Log("a");
        }

        if (Input.GetKey(KeyCode.D))
        {

            ismove = true;
            if (iswalk)
            {
                transform.Translate(Vector3.right * Time.deltaTime * speed);

            }
            else
            {
                transform.Translate(Vector3.right * Time.deltaTime * runspeed);
            }
            //transform.Translate(Vector3.right * Time.deltaTime * speed);
            //Debug.Log("d");
        }

        if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            ismove = false;
        }


        // ��ת�ӽ�
        float mouseX = Input.GetAxis("Mouse X") * rotationSpeed;
        transform.Rotate(Vector3.up, mouseX);
        /*// ��ȡ�����ˮƽ�ʹ�ֱ�����ϵ�����
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // �������������ת�ӽ�
        transform.Rotate(Vector3.up, mouseX * rotationSpeed, Space.World);
        transform.Rotate(Vector3.right, -mouseY * rotationSpeed, Space.Self);*/

        //��Ծ
        if (Input.GetKey(KeyCode.Z))
        {
            isjump = true;
            transform.Translate(Vector3.up * Time.deltaTime * jumpspeed);
            Debug.Log("z");
        }
        else
        {
            isjump = false;
        }

        //�ܲ�
        if (Input.GetKeyDown(KeyCode.X))
        {
            iswalk = !iswalk;
            isrun = !isrun;
        }
        //��
        if (Input.GetKeyDown(KeyCode.C))
        {
            islook = true;
        }
        else
        {
            islook = false;
        }

        /*//����1
        if (Input.GetKeyDown(KeyCode.G))
        {
            isattack = true;
        }
        else
        {
            isattack = false;
        }*/


        //���ö���
        if (ismove)
        {
            animator.SetBool("IsMove", true);
        }
        else
        {
            animator.SetBool("IsMove", false);

        }
        if (iswalk)
        {
            animator.SetBool("IsWalk", true);
        }
        else
        {
            animator.SetBool("IsWalk", false);

        }
        if (isrun)
        {
            animator.SetBool("IsRun", true);
        }
        else
        {
            animator.SetBool("IsRun", false);

        }
        if (islook)
        {
            animator.SetBool("IsLook", true);
        }
        else
        {
            animator.SetBool("IsLook", false);

        }

        /*if (isattack)
        {
            animator.SetBool("IsAttack", true);
        }
        else
        {
            animator.SetBool("IsAttack", false);

        }*/



    }
}
