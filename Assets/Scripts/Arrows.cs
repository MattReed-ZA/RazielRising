using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrows : MonoBehaviour
{
   [SerializeField]public GameObject Launcher;
    [SerializeField]public GameObject Target;
    public float ProjectileSpeed=10f;
    private float LauncherX;
    private float TargetX;
    private float dist;
    private float nextX;
    private float baseY;
    private float height;
    private Quaternion temp;

    void Start()
    {
        
    }

    void Update()
    {                
        ProjectileMovement();
        if(transform.position.x==TargetX || transform.position.y==Target.transform.position.y)
        {
            transform.position=Launcher.transform.position;
        }
        temp=transform.rotation;
        if(Time.timeScale==0)
        {
            transform.rotation=temp;
        }
        
    }

    public void ProjectileMovement()
    {
        TargetX=Target.transform.position.x;
        LauncherX=Launcher.transform.position.x;

        dist=TargetX-LauncherX;
        nextX=Mathf.MoveTowards(transform.position.x,TargetX,ProjectileSpeed*Time.deltaTime);
        baseY=Launcher.transform.position.y;
        height=2*(nextX-LauncherX)*(nextX-TargetX)/(-0.25f*dist*dist);

        Vector3 movePosition = new Vector3(nextX,baseY+height,transform.position.z);
        transform.rotation=LookAtTarget(movePosition-transform.position);
        transform.position=movePosition;
    }

    public static Quaternion LookAtTarget(Vector2 rotation)
    {
        return Quaternion.Euler(0,0,Mathf.Atan2(rotation.y,rotation.x));
    }
}
