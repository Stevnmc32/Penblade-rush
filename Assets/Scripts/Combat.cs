using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    public GameObject PenBlade;
    public GameObject Aplz;
    public bool CanAttack = false;

    public int lives = 5;

    [SerializeField] Sprite[] Arrows;
    [SerializeField] SpriteRenderer sr;
    [SerializeField] Transform sr_trans;

    private Stack<SpriteRenderer> sprites = new Stack<SpriteRenderer>(){};

    private Stack<int> arrows = new Stack<int>();
    public int num_arrows = 6;
    public int num_arrows_visible = 0;
    private int RandomNumber;

    private int KeyPressed=0;

    public void Start()
    {
        ArrowsR();
    }


    public void Update()
    {
        if (Input.anyKeyDown)
        {
            if (CanAttack) {
                if (Input.GetKeyDown(KeyCode.W))
                {
                    KeyPressed = 0;
                    PenBladeAttack();
                }
                if (Input.GetKeyDown(KeyCode.S))
                {
                    KeyPressed = 1;
                    PenBladeAttack();
                }
                if (Input.GetKeyDown(KeyCode.A))
                {
                    KeyPressed = 2;
                    PenBladeAttack();
                }
                if (Input.GetKeyDown(KeyCode.D))
                {
                    KeyPressed = 3;
                    PenBladeAttack();
                }
            }
        }
    }

    private void ArrowsR()
    {
        arrows.Clear();
        sprites.Clear();
        sr.enabled = true;
        Vector3 pos = sr_trans.position;
        num_arrows_visible = num_arrows;
        float move_with = num_arrows == 1 ? 0:(num_arrows*0.5f+0.5f);
        sr_trans.Translate(move_with, 0, 0);
        for (int i = 0; i < num_arrows; i++) {
            RandomNumber = Random.Range(1, 5);
            sr.sprite = Arrows[RandomNumber - 1];
            sr_trans.Translate(-1, 0, 0);
            
            sprites.Push(Instantiate(sr));
            arrows.Push(RandomNumber - 1);
        }
        sr_trans.position = pos;
        sr.enabled = false;
    }

    private void PenBladeAttack()
    {
        CanAttack = false;
        if (KeyPressed == arrows.Peek())
        {
            arrows.Pop();
            Destroy(sprites.Peek().gameObject);
            sprites.Pop();
            num_arrows_visible--;
            if (num_arrows_visible == 0)
            {
                ArrowsR();
            }
        }
        else
        {
            lives--;
        }
        Animator anim = PenBlade.GetComponent<Animator>();
        anim.SetTrigger("Swing");

        Animator anim2 = Aplz.GetComponent<Animator>();
        anim2.SetTrigger("Move");
        StartCoroutine(ResetAttackCoolDown());
        //CanAttack = true;
    }

    IEnumerator ResetAttackCoolDown()
    {
        yield return new WaitForSeconds(0.3f);
        CanAttack = true;
    }


}
