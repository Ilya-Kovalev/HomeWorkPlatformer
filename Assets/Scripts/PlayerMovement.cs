using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _thrust;

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.D)) 
        {
            _animator.SetBool("IsRun", true);
            transform.Translate(_speed * Time.deltaTime, 0, 0);
            Vector3 newScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
            transform.localScale = newScale;
        }
        else if(Input.GetKey(KeyCode.A)) 
        {
            _animator.SetBool("IsRun", true);
            transform.Translate(_speed * Time.deltaTime * -1, 0, 0);
            Vector3 newScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
            transform.localScale = newScale;
        }
        else 
        {
            _animator.SetBool("IsRun", false);
        }

        if(Input.GetKeyDown(KeyCode.W)) 
        {
            GetComponent<Rigidbody2D>().AddForce(transform.up * _thrust, ForceMode2D.Impulse);
        }
    }
}
