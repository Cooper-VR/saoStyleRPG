using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using static Thry.AnimationParser;
using Unity.Mathematics;
using System;
using Valve.VR.InteractionSystem;

public class enemyAI : MonoBehaviour
{
    private VelocityEstimator velocity;
    public GameObject player;
    public Transform emenyHead;
    public Vector3 toPlayer;
    public LayerMask groundPlayerMask;
    private NavMeshAgent agent;
    private Animator bokoAnimator;
    public Vector3 startDestination;
    private bool attacking;
    private float movingX;
    private float movingY;
    private float baseSpeed = 2.5f;
    private findVariable find;
    private float findAmount;
    private quaternion startRotation;


    bool didHit;
    RaycastHit hit;
    bool didHitLong;


    public bool inView;

    private void Start()
    {
        velocity = GetComponent<VelocityEstimator>();
        agent = GetComponent<NavMeshAgent>();
        bokoAnimator = transform.GetChild(0).GetChild(0).gameObject.GetComponent<Animator>();
        startDestination = transform.position;
        startRotation = transform.rotation;
        find = transform.GetChild(0).GetChild(0).gameObject.GetComponent<findVariable>();
    }

    void Update()
    {
        RaycastHit alwaysHit;

        bool alwaysHitBool = Physics.Raycast(emenyHead.position, player.transform.position - emenyHead.position, out alwaysHit, Mathf.Infinity, groundPlayerMask);


        float angle = vectorAngleCalculator(player.transform, emenyHead);

        bokoAnimator.SetInteger("idleType", UnityEngine.Random.Range(0, 8));
        bokoAnimator.SetInteger("attackType", UnityEngine.Random.Range(0, 5));

        bokoAnimator.SetFloat("direction_X", movingX);
        bokoAnimator.SetFloat("direction_Y", movingY);

        if (angle > 0.75f && angle < 2.15f)
        {
            inView = true;
        }
        else
        {
            inView = false;
        }

        if (inView || attacking)
        {
            RaycastHit hitLong;

            didHit = Physics.Raycast(emenyHead.position, player.transform.position - emenyHead.position, out hit, 30f / 2, groundPlayerMask);
            didHitLong = Physics.Raycast(emenyHead.position, player.transform.position - emenyHead.position, out hitLong, 30f, groundPlayerMask);

            if (didHitLong && hitLong.distance > 15f && !attacking)
            {
                bokoAnimator.SetFloat("findType", 1f);
                bokoAnimator.SetBool("hostile", true);
                findAmount += hitLong.distance / 15 * Time.deltaTime;
                if (findAmount >= 10f)
                {
                    attacking = true;
                    bokoAnimator.SetFloat("findType", 0f);
                    bokoAnimator.SetBool("hostile", true);
                    bokoAnimator.SetBool("interupt", true);

                }
            }
            else if (didHit || attacking)
            {
                bokoAnimator.SetFloat("findType", 0f);
                if (attacking || hit.transform.gameObject.tag == "player")
                {

                    bokoAnimator.SetBool("interupt", find.interupt);
                    bool closeEnough = checkDistance(2.5f, transform, player.transform);
                    bokoAnimator.SetBool("hostile", true);
                    bokoAnimator.SetBool("idle", false);
                    bokoAnimator.SetBool("attacking", closeEnough);

                    attacking = true;

                    if (!closeEnough && find.hasFound)
                    {
                        baseSpeed = 3.5f;
                        //bokoAnimator.SetFloat("speed", 1000);
                        agent.destination = player.transform.position;
                        float movingAngle = vectorAngleCalculator(player.transform, emenyHead);

                        float polarY = Mathf.Sqrt(Mathf.Pow(Mathf.Sin(movingAngle), 2));
                        float polarX = Mathf.Sqrt(Mathf.Pow(Mathf.Cos(movingAngle), 2));

                        movingX = polarX * Mathf.Cos(polarX);
                        movingY = polarY * Mathf.Sin(polarY);

                        agent.speed = baseSpeed;

                        if (movingX > 0.5f)
                        {
                            agent.speed = baseSpeed;
                            agent.angularSpeed = 260;
                        }
                        else
                        {
                            agent.speed = baseSpeed * 1.4f;
                            agent.angularSpeed = 190;
                        }
                    }
                    else if (closeEnough && find.hasFound)
                    {
                        agent.speed = 0f;
                        agent.angularSpeed = 300;
                        bokoAnimator.SetFloat("direction_Y", 0);
                    }

                }
                else
                {
                    bokoAnimator.SetFloat("speed", 1f);
                }
            }
            else
            {
                bokoAnimator.SetFloat("speed", 1f);

            }
        }
        else
        {

            agent.angularSpeed = 260;
            baseSpeed = 2f;
            agent.speed = baseSpeed;
            bokoAnimator.SetFloat("speed", 1f);
        }

        if (!checkDistance(30f, player.transform, emenyHead))
        {
            attacking = false;
            bokoAnimator.SetBool("hostile", false);
            agent.destination = startDestination;
            find.interupt = true;
            find.hasFound = false;
        }


        if (velocity.GetVelocityEstimate().magnitude < 0.4f)
        {
            bokoAnimator.SetBool("idle", true);
            transform.rotation = startRotation;
        }
        else
        {
            bokoAnimator.SetBool("idle", false);
        }
    }

    private float vectorAngleCalculator(Transform player, Transform enemy)
    {
        Vector3 toEnd = (player.transform.position - enemy.position).normalized;

        float dotProduct = (toEnd.x * enemy.forward.x) + (toEnd.z * enemy.forward.z);
        float cosAngle = dotProduct / (toEnd.magnitude * enemy.forward.magnitude);

        return Mathf.Acos(cosAngle);
    }

    private bool checkDistance(float threshold, Transform first, Transform second)
    {
        float distance = (first.position - second.position).magnitude;

        if (distance < threshold)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    IEnumerator coroutine(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

    }
}
