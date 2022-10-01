using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectiles : MonoBehaviour
{
    [SerializeField]public GameObject Shooter;
    [SerializeField]public GameObject Target;
    public float ProjectileSpeed=10f;
    private float ShooterX;
    private float TargetX;
    private float dist;
    private float nextX;
    private float baseY;
    private float height;
    
    void Start()
    {
        
    }

    void Update()
    {                
        ProjectileMovement();
        if(transform.position.x==TargetX || transform.position.y==Target.transform.position.y)
        {
            transform.position=Shooter.transform.position;
        }
    }

    public void ProjectileMovement()
    {
        TargetX=Target.transform.position.x;
        ShooterX=Shooter.transform.position.x;

        dist=TargetX-ShooterX;
        nextX=Mathf.MoveTowards(transform.position.x,TargetX,ProjectileSpeed*Time.deltaTime);
        baseY=Mathf.Lerp(Shooter.transform.position.y,Target.transform.position.y,(nextX-ShooterX)/dist);
        height=2*(nextX-ShooterX)*(nextX-TargetX)/(-0.25f*dist*dist);

        Vector3 movePosition = new Vector3(nextX,baseY+height,transform.position.z);
        transform.position=movePosition;
    }
}
