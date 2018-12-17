using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckBae : MonoBehaviour
{
    Animator animator;
    public GameObject BulletPrefabs;
    public GameObject grenadePrefabs;
    int CoolTime = 1000;
    public static int timer = 1000;
    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Attack() // 일어서서 쏘기 총알 날라가는 애니메이션
    {
        GameObject Bullet = Instantiate(BulletPrefabs) as GameObject;
        Bullet.transform.position = new Vector3(-4, 1.8f, 4);
    }
    void Attack2() // 앉아 쏘기 총알 날라가는 애니메이션
    {
        GameObject Bullet = Instantiate(BulletPrefabs) as GameObject;
        Bullet.transform.position = new Vector3(-4, 1.2f, 4);
    }
    void Attack3() // 엎드려서 쏘기 총알 날라가는 애니메이션
    {
        GameObject Bullet = Instantiate(BulletPrefabs) as GameObject;
        Bullet.transform.position = new Vector3(-3.5f, 0.2f, 4);
    }
    void throwGrenade() // 수류탄 날라가는 애니메이션
    {
        Invoke("Grenade", 0.3f);
    }
    void Grenade()
    {
        GameObject grenade = Instantiate(grenadePrefabs) as GameObject;
        grenade.transform.position = new Vector3(-4, 1.8f, 4);
    }
    void Move()
    {
        timer += (int)Time.deltaTime;
        if (timer >= CoolTime)
        {
            Attack2();
            timer = 0;
        }
    }
    void Move2()
    {
        timer += (int)Time.deltaTime;
        if (timer >= CoolTime)
        {
            Attack3();
            timer = 0;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (GUIscripts.grenade == true && GUIscripts.warStart == true && GUIscripts.ani == 4)
        {
            animator.SetBool("isthrow",false);
            if (timer >= CoolTime)
            {
                throwGrenade();
                timer = 0;
            }
        }
        if (GUIscripts.warStart == true && GUIscripts.ani == 0)
        {
            animator.SetTrigger("ISDRAW");
            animator.SetBool("isthrow", true);
            animator.SetBool("isShoot", true);
            animator.SetBool("isShoot2", true);
            animator.SetBool("iscrouch", true);
            animator.SetBool("crouchshoot2", true);
            animator.SetBool("crouchshoot", true);
            animator.SetBool("proneshoot2", true);
            animator.SetBool("proneshoot", true);
            animator.SetBool("isproneIdle", true);
            animator.SetBool("isprone", true);
        }
        if (GUIscripts.warStart == true && GUIscripts.ani == 1 && GUIscripts.ran == 1)
        {
            timer += (int)Time.deltaTime;
            if(timer >= CoolTime)
            {
                Attack();
                timer = 0;
            }
            animator.SetBool("isShoot",false);
            animator.SetTrigger("isReload");
            animator.SetTrigger("isDraw");
        }
        if (GUIscripts.warStart == true && GUIscripts.ani == 1 && GUIscripts.ran == 2)
        {
            timer += (int)Time.deltaTime;
            if (timer >= CoolTime)
            {
                Attack();
                timer = 0;
            }
            animator.SetBool("isShoot2", false);
            animator.SetTrigger("isReload");
            animator.SetTrigger("isDraw");
        }
        if (player.playerHp == 0)
        {
            animator.SetBool("isDeath",false);
        }
        if (GUIscripts.warStart == true && GUIscripts.ani == 2)
        {
            animator.SetBool("iscrouch",false);
        }
        if (GUIscripts.warStart == true && GUIscripts.ani == 2 && GUIscripts.ran == 1)
        {
            Invoke("Move", 0.5f);
            animator.SetBool("crouchshoot", false);
            animator.SetTrigger("isReload");
        }
        if (GUIscripts.warStart == true && GUIscripts.ani == 2 && GUIscripts.ran == 2)
        {
            Invoke("Move", 0.5f);
            animator.SetBool("crouchshoot2", false);
            animator.SetTrigger("isReload");
        }
        if (GUIscripts.warStart == true && GUIscripts.ani == 3)
        {
            animator.SetBool("isprone", false);
            animator.SetBool("isproneIdle", false);
        }
        if (GUIscripts.warStart == true && GUIscripts.ani == 3 && GUIscripts.ran == 1)
        {
            Invoke("Move2", 0.9f);
            animator.SetBool("proneshoot", false);
            animator.SetTrigger("isReload");
        }
        if (GUIscripts.warStart == true && GUIscripts.ani == 3 && GUIscripts.ran == 2)
        {
            Invoke("Move2", 0.9f);
            animator.SetBool("proneshoot2", false);
            animator.SetTrigger("isReload");
        }
    }
}
