using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    public Image HPImage;
    public int maxHP          = 4; //�ő�HP
    private int currentHP;
    public float knockback    = 5f;//�m�b�N�o�b�N
    public float invincible   = 2f;//���G
    private bool isInvincible = false;

    Rigidbody2D rb;

    private void Start()
    {
        currentHP = maxHP;//�Q�[���J�n����HP��������
        StartCoroutine(InvincibleTime());
        rb = GetComponent<Rigidbody2D>();
    }

    //void OnCollisionEnter2D(Collision2D collision)
    //{
    //    Debug.Log("�Փ˂�������: " + collision.gameObject.name);

    //    if (collision.gameObject.CompareTag("Enemy") && !isInvincible)
    //    {
    //        Debug.Log("�G�ƏՓ˂��܂����I");
    //        TakeDamege(1);
    //    }
    //}

    void OnTriggerEnter2D(Collider2D other)
    {
        //�G�ƏՓ˂���ƃm�b�N�o�b�N
        if (other.CompareTag("Enemy"))
        {
            rb.velocity = Vector2.zero;
            Vector2 direction = (transform.position - other.transform.position).normalized;
            rb.AddForce(direction * knockback, ForceMode2D.Impulse);
        }
        //�G�ƏՓ˂���ƃ_���[�W
        if (other.CompareTag("Enemy") && !isInvincible)
        {
            Debug.Log("�G�ƏՓ˂��܂����I");
            TakeDamege(1);
        }
        if (other.CompareTag("Trap"))
        {
            Debug.Log("㩂ƏՓ˂��܂���");
            TakeDamege(maxHP);
        }

    }

    //void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (other.CompareTag("Enemy"))
    //    {
    //        rb.velocity = Vector2.zero;

    //        Vector2 direction = (transform.position - other.transform.position).normalized;

    //        rb.AddForce(direction * knockback, ForceMode2D.Impulse);

    //    }
    //}

    void TakeDamege(int damage)
    {
        currentHP -= damage;
        HPImage.fillAmount = (float)currentHP / maxHP;
        StartCoroutine(InvincibleTime());

        Debug.Log("�c��HP�F" + currentHP);

        if(currentHP <= 0)
        {
            Die();
        }
    }

    private IEnumerator InvincibleTime()
    {
        isInvincible = true;
        yield return new WaitForSeconds(invincible);

        isInvincible = false;
        Debug.Log("���G����");

    }



    void Die()
    {
        //���S����
        Debug.Log("�v���C���[���S");

        gameObject.SetActive(false);
    }

}

