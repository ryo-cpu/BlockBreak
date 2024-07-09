using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    //�{�[���̈ړ��̑������w��
    public float speed = 5f;
    public float minspeed = 5f;
    public float maxspeed = 10f;
    Rigidbody myRigidBody;
    // Start is called before the first frame update
    void Start()
    {
        //Rigidbody�ɃA�N�Z�X���ĕϐ��ɕێ����Ă���
        myRigidBody = GetComponent<Rigidbody>();
        //�E�΂߂S�T�x�ɐi��
        myRigidBody.velocity = new Vector3(speed,speed,0f);
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 velocity =myRigidBody.velocity;
        float calmpedSpeed=Mathf.Clamp(velocity.magnitude, minspeed, maxspeed);
        myRigidBody.velocity = velocity.normalized*calmpedSpeed;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("player") )
        {
            Vector3 playerPos=collision.transform.position;
            Vector3 ballPos=collision.transform.position;
            Vector3 directio = (ballPos - playerPos).normalized;
            float speed=myRigidBody.velocity.magnitude;
            myRigidBody.velocity=directio*speed;
        }
    }
}
