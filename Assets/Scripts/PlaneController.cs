using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlaneController : MonoBehaviour
{
    // -> Declaring Variables:

    //__________Public Variables__________
    // ~ transforms
    public Transform planeTransform;
    // ~ Vector3
    public Vector3 arrow_pos;
    public Vector3 arrow_angle;
    
    public float speed=3.0f;
    public float rotSpeed=30.0f;
    public float angle_hor;
    public float angle_vert;
    public Vector3 steph;
    public Vector3 stepv;
    
    //__________Private Variables__________
    

    // Start is called before the first frame update
    void Start()
    {
        arrow_pos=planeTransform.position;
        arrow_angle=planeTransform.eulerAngles;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        arrow_angle=planeTransform.eulerAngles;
        PlaneDir();
    }

    //Plane Direction
    void PlaneDir()
    {
        bool w=Input.GetKey(KeyCode.W)||Input.GetKey(KeyCode.UpArrow);
        bool a=Input.GetKey(KeyCode.A)||Input.GetKey(KeyCode.LeftArrow);
        bool s=Input.GetKey(KeyCode.S)||Input.GetKey(KeyCode.DownArrow);
        bool d=Input.GetKey(KeyCode.D)||Input.GetKey(KeyCode.RightArrow);

        
        
        //______________Up-Down____________________
            // Up
            if(w)
            {
                if(arrow_angle.z<30.2f && arrow_angle.z>29.8f)
                {
                    arrow_angle.z = 30.0000f;
                }
                else
                {
                    arrow_angle.z += rotSpeed * Time.deltaTime;
                }
            }
            else if(!w)
            {
                if(arrow_angle.z>0.2f && arrow_angle.z<30.2f)
                {
                    arrow_angle.z -= 0.5f * rotSpeed * Time.deltaTime;
                }
            }
            // <Up End>
            if ((arrow_angle.z<0.2f || arrow_angle.z>359.8f) && (!w && !s))
            {
                arrow_angle.z =0.0000f;
            }
            // Down
            if(s)
            {
                if(arrow_angle.z>329.8f && arrow_angle.z<330.2f)
                {
                    arrow_angle.z = 330.0000f;
                }
                else
                {
                    arrow_angle.z -= rotSpeed * Time.deltaTime;
                }
            }
            else if(!s)
            {
                if(arrow_angle.z<360.0000f && arrow_angle.z>329.8f)
                {
                    arrow_angle.z += 0.5f * rotSpeed * Time.deltaTime;
                }
            }
            // <Down end>

        
        //______________Left-Right____________________
            // Left
            if(a)
            {
                if(arrow_angle.y==0)
                {
                    arrow_angle.y=360.0000f;
                }

                arrow_angle.x += rotSpeed * Time.deltaTime;
                arrow_angle.y -= rotSpeed * Time.deltaTime;

                if(arrow_angle.x<60.0f)
                {
                    arrow_angle.x = Mathf.Clamp(arrow_angle.x, -220.02f, 30.0000f);
                    // arrow_angle.y = Mathf.Clamp(arrow_angle.y, 330.0000f, 560.2f);
                }
                
               
                
            }
            else if(!a)
            {
                if(arrow_angle.x>0.2f && arrow_angle.x<60.2f)
                {
                    arrow_angle.x -= 0.5f * rotSpeed * Time.deltaTime;
                }
                // if (arrow_angle.y<359.8f && arrow_angle.y>299.8f)
                // {
                //     arrow_angle.y += 0.5f * rotSpeed * Time.deltaTime;
                // }
                
            }
            // <Left End>
            if ((arrow_angle.x<0.2f || arrow_angle.x>359.8f) && (arrow_angle.y<0.2f || arrow_angle.y>359.8f) && (!a && !d))
            {
                arrow_angle.x =0.0000f;
                arrow_angle.y =0.0000f;
            }
            // Right
            if(d)
            {
                if(arrow_angle.x==0)
                {
                    arrow_angle.x=360.0000f;
                }

                arrow_angle.x -= rotSpeed * Time.deltaTime;
                arrow_angle.y += rotSpeed * Time.deltaTime;

                if (arrow_angle.x>300.0f)
                {
                    // arrow_angle.y = Mathf.Clamp(arrow_angle.y, -220.02f, 30.0000f);
                    arrow_angle.x = Mathf.Clamp(arrow_angle.x, 330.0000f, 560.2f);
                }
                
            }
            else if(!d)
            {
                if((arrow_angle.x<360.0000f && arrow_angle.x>299.8))
                {
                    arrow_angle.x += 0.5f * rotSpeed * Time.deltaTime;
                }
                // if(arrow_angle.y>0.2f && arrow_angle.y<60.2f)
                // {
                //     arrow_angle.y -= 0.5f * rotSpeed * Time.deltaTime;
                // }
            }
            // <Right end>
        // arrow_angle.y = 0.0000f;
        planeTransform.eulerAngles = arrow_angle;
        PlanePos();
    }

    // Plane Position
    void PlanePos()
    {
        planeTransform.position += planeTransform.right * Time.deltaTime * speed;
        // stepv = new Vector3(Mathf.Abs(Mathf.Sin(arrow_angle.x))*10,0,Mathf.Abs(Mathf.Cos(arrow_angle.x))*10);
        
        // // stepv=new Vector3( Mathf.Abs(Mathf.Cos( arrow_angle.x * Mathf.Deg2Rad ))*speed, 0, Mathf.Abs(Mathf.Sin( arrow_angle.x * Mathf.Deg2Rad ))*speed);
        // planeTransform.position += stepv * speed * Time.deltaTime;

        // steph = new Vector3( Mathf.Abs(Mathf.Cos( arrow_angle.y * Mathf.Deg2Rad ))*speed, Mathf.Abs(Mathf.Sin( arrow_angle.y * Mathf.Deg2Rad ))*speed,0);
        
        // angle_hor=Mathf.Abs(arrow_angle.y);

/* 
        if (angle_hor>360.0f)
        {
            angle_hor=360.0f-angle_hor;
        }

        if ((angle_hor>=0.0f) && (angle_hor<90.0f))
        {
            arrow_pos.x = arrow_pos.x + (steph.x * Time.deltaTime);
            arrow_pos.z = arrow_pos.z + (steph.z * Time.deltaTime);
        }
        if ((angle_hor>=90) && (angle_hor<180))
        {
            arrow_pos.x = arrow_pos.x - (steph.x * Time.deltaTime);
            arrow_pos.z = arrow_pos.z + (steph.z * Time.deltaTime);
        }
        if ((angle_hor>=180) && (angle_hor<270))
        {
            arrow_pos.x = arrow_pos.x - (steph.x * Time.deltaTime);
            arrow_pos.z = arrow_pos.z - (steph.z * Time.deltaTime);
        }
        if ((angle_hor>=270) && (angle_hor<360))
        {
            arrow_pos.x = arrow_pos.x + (steph.x * Time.deltaTime);
            arrow_pos.z = arrow_pos.z - (steph.z * Time.deltaTime);
        }
        

        
        if (angle_vert>360.0f)
        {
            angle_vert=360.0f-angle_vert;
        }

        if ((angle_vert>=0.0f) && (angle_vert<90.0f))
        {
            
            arrow_pos.y = arrow_pos.y - (stepv.y * Time.deltaTime);
        }
        if ((angle_vert>=90) && (angle_vert<180))
        {
            
            arrow_pos.y = arrow_pos.y - (stepv.y * Time.deltaTime);
        }
        if ((angle_vert>=180) && (angle_vert<270))
        {
            
            arrow_pos.y = arrow_pos.y + (stepv.y * Time.deltaTime);
        }
        if ((angle_vert>=270) && (angle_vert<360))
        {
            
            arrow_pos.y = arrow_pos.y + (stepv.y * Time.deltaTime);
        }

        planeTransform.position = arrow_pos; */
    }

    //Reload when hit
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "bullet")
        {
            Debug.Log("Fire!!");
        }
        else
        {
            Debug.Log("Hit!");
            // Application.LoadLevel(0);
            // SceneManager.LoadScene("Menu", LoadSceneMode.Additive);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -1);
        }
        // SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
