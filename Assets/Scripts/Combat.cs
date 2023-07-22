using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    public GameObject PenBlade;
    public GameObject Aplz;
    public bool CanAttack = false;
    public float AttackCooldown = 1f;

    [SerializeField] Sprite [] Arrows;
    [SerializeField] SpriteRenderer sr;
    int RandomNumber;

    public Transform ArrowUp;
    public Transform ArrowDown;
    public Transform ArrowRight;
    public Transform ArrowLeft;
    public Transform ArrowDes;
    public Transform ArrowIsUpDes;

    public bool ArrowUpable = false;

    public void Start()
    {
        ArrowsR();
    }


    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (CanAttack)
            {
                if (ArrowUp != true && ArrowUpable)
                {
                    ArrowUp.gameObject.SetActive(false);
                    ArrowsR();
                }
                PenBladeAttack();
            }
        }

       



    }

    void ArrowsR()
    {
        RandomNumber = Random.Range(1, 5);
        sr.sprite = Arrows[RandomNumber - 1];

        
       
    }

    public void PenBladeAttack()
    {
        if(ArrowUp != true)
        {
            ArrowUp.position = ArrowDes.position;
            ArrowsR();
        }

        CanAttack = false;
        Animator anim = PenBlade.GetComponent<Animator>();
        anim.SetTrigger("Swing");

        Animator anim2 = Aplz.GetComponent<Animator>();
        anim2.SetTrigger("Move");

        StartCoroutine(ResetAttackCoolDown());
    }

    IEnumerator ResetAttackCoolDown()
    {
        yield return new WaitForSeconds(AttackCooldown);
        CanAttack = true;
    }


}
