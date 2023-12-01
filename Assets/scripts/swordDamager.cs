using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
using SAOrpg.enemies;
using SAOrpg.playerAPI.RPGsstuff.inventory;
using SAOrpg.playerAPI.RPGsstuff.stats;

public class swordDamager : MonoBehaviour
{
    /// <summary>
    /// enum for the sharp vector direction
    /// </summary>
    public enum SharpDirection
    {
        forward,
        backward,
        right,
        left,
        up,
        down,
        none
    }

    #region variables
    public SharpDirection sharpDirection;

    public int strengthRequirement;
    public int duribility;
    public int maxDamage;
    public Transform playerCamera;

    public poseDirectionObject.directions lastHitDirection;
    public poseDirectionObject.directions topDownDirection;
    public poseDirectionObject.directions sideSideDirection;

    public Vector3 topDownCam = Vector3.zero;
    public Vector3 sideSideCam = Vector3.zero;
    public Vector3 topDownVelocity = Vector3.zero;
    public Vector3 sideSideVeclocity = Vector3.zero;

    #endregion
    private void getDirections()
    {
        Vector3 velocity = GetComponent<VelocityEstimator>().GetVelocityEstimate();


        sideSideVeclocity.x = velocity.x;
        sideSideVeclocity.y = 1;
        sideSideVeclocity.z = velocity.y;

        topDownVelocity.x = velocity.x;
        topDownVelocity.y = velocity.z;

        sideSideVeclocity = sideSideVeclocity.normalized;
        topDownVelocity = topDownVelocity.normalized;

        sideSideCam.y = playerCamera.forward.x;
        sideSideCam.x = playerCamera.forward.y;
        sideSideCam.z = playerCamera.forward.z;



        topDownCam.x = playerCamera.forward.x;
        topDownCam.y = playerCamera.forward.z;

        //playerCamera.InverseTransformVector(sideSideCam);

        topDownVelocity *= -1;

        float topDownAngle = Vector2.SignedAngle(topDownCam, topDownVelocity);


        // use this to check top/down angle
        if (topDownAngle > 45)
        {
            topDownDirection = poseDirectionObject.directions.left;
        }
        else if (topDownAngle < -45)
        {
            topDownDirection = poseDirectionObject.directions.right;
        }
        else if (topDownAngle <= 45 && topDownAngle >= -45)
        {
            topDownDirection = poseDirectionObject.directions.pierce;
        }

        float sideSideAngle = Vector2.SignedAngle(new Vector2(sideSideCam.y, sideSideCam.z), new Vector2(sideSideVeclocity.y, sideSideVeclocity.z));


        //use this to check top/down angle
        if (sideSideAngle < -135)
        {
            sideSideDirection = poseDirectionObject.directions.down;
        }
        else if (sideSideAngle >= -135 && sideSideAngle <= -45)
        {
            sideSideDirection = poseDirectionObject.directions.pierce;
        }
        else if (sideSideAngle > -45)
        {
            sideSideDirection = poseDirectionObject.directions.up;
        }
    }

    private void setMaster()
    {
        if (topDownDirection == poseDirectionObject.directions.left && sideSideDirection == poseDirectionObject.directions.pierce)
        {
            lastHitDirection = poseDirectionObject.directions.left;
        }
        if (topDownDirection == poseDirectionObject.directions.left && sideSideDirection == poseDirectionObject.directions.up)
        {
            lastHitDirection = poseDirectionObject.directions.leftUp;
        }
        if (topDownDirection == poseDirectionObject.directions.left && sideSideDirection == poseDirectionObject.directions.down)
        {
            lastHitDirection = poseDirectionObject.directions.leftDown;
        }
        if (topDownDirection == poseDirectionObject.directions.right && sideSideDirection == poseDirectionObject.directions.pierce)
        {
            lastHitDirection = poseDirectionObject.directions.right;
        }
        if (topDownDirection == poseDirectionObject.directions.right && sideSideDirection == poseDirectionObject.directions.up)
        {
            lastHitDirection = poseDirectionObject.directions.rightUp;
        }
        if (topDownDirection == poseDirectionObject.directions.right && sideSideDirection == poseDirectionObject.directions.down)
        {
            lastHitDirection = poseDirectionObject.directions.rightDown;
        }
        if (topDownDirection == poseDirectionObject.directions.pierce && sideSideDirection == poseDirectionObject.directions.up)
        {
            lastHitDirection = poseDirectionObject.directions.up;
        }
        if (topDownDirection == poseDirectionObject.directions.pierce && sideSideDirection == poseDirectionObject.directions.down)
        {
            lastHitDirection = poseDirectionObject.directions.down;
        }
        if (topDownDirection == poseDirectionObject.directions.pierce && sideSideDirection == poseDirectionObject.directions.pierce)
        {
            lastHitDirection = poseDirectionObject.directions.pierce;
        }
    }


    private VelocityEstimator velocityEstimator;

    public float delayTime;
    public bool deltDamage;

    public inventoryObjects stats;

    public float velocityThreshold;
    public Vector3 currentPos;
    public Vector3 previousPos;

    public GameObject enemy;

    private void Start()
    {
        velocityEstimator = GetComponent<VelocityEstimator>();
        playerCamera = GameObject.Find("Camera").transform;
    }

    private void Update()
    {
        getDirections();
        setMaster();

        if (deltDamage)
        {
            delayTime += Time.deltaTime;
        }
        if (delayTime >= 0.5f)
        {
            deltDamage = false;
            Debug.Log("fullHit");
            enemy.GetComponent<enemyHandler>().DealDamage(stats.maxDamage);
            delayTime = 0f;
        }

        currentPos = transform.position;
        raycastCollision();
        previousPos = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        //works, but healvily reilies on framerate. Might try a raycast system
        if (other.tag == "Enemy" && velocityEstimator.GetVelocityEstimate().magnitude > velocityThreshold)
        {
            //Debug.Log("hit enemy");
            if (!deltDamage)
            {
                Debug.Log("colliderHit");
                //DamageEnemy(other.gameObject);
                deltDamage = true;
                enemy = other.gameObject;

            }
            
        }
    }

    private void DamageEnemy(GameObject enemy)
    {
        enemyHandler handler = enemy.GetComponent<enemyHandler>();

        handler.DealDamage(10);
    }

    private void raycastCollision()
    {
        RaycastHit hit;

        if (Physics.Raycast(currentPos, velocityEstimator.GetVelocityEstimate() * -1, out hit, velocityEstimator.GetVelocityEstimate().magnitude + 0.5f) && velocityEstimator.GetVelocityEstimate().magnitude > velocityThreshold)
        {
            if (hit.transform.gameObject.tag == "Enemy" && !deltDamage)
            {
                enemy = hit.transform.gameObject;
                deltDamage = true;
                Debug.Log("raycastHit");
            }
        }
    }
}
