using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    
    public int score = 0;
    public int goal;
    [Space(5f)]
    
    public float speed = 3f;
    public bool normaliseInput;
    private Vector2 m_MoveVector;

    private void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    private void Update()
    {
        UpdateMovement();
        UpdateGoalManager();
    }

    private void UpdateGoalManager()
    {
        if (score >= goal)
        {
            score = 0;
            SceneManager.LoadScene("Level_2");
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        UpdatePickup(col);
    }

    private void UpdatePickup(Collision2D col)
    {
        print($"I Collided with {col.transform.name}");
        
        if (!col.transform.CompareTag($"Complete/Coin")) return;
        
        score++;
        Destroy(col.gameObject);
    }

    private void UpdateMovement()
    {
        // GET INPUT
        m_MoveVector.x = (Keyboard.current.aKey.isPressed ? -1f : 0f) + (Keyboard.current.dKey.isPressed ? 1f : 0f);
        m_MoveVector.y = (Keyboard.current.sKey.isPressed ? -1f : 0f) + (Keyboard.current.wKey.isPressed ? 1f : 0f);

        // NORMALISE Vector INPUT
        if (normaliseInput && m_MoveVector.magnitude > 1)
        {
            m_MoveVector = m_MoveVector.normalized;
        }

        // APPLY INPUT & SPEED TO MOVEMENT
        var move = (m_MoveVector * speed ) * Time.deltaTime;
        transform.Translate(move);
    }
}