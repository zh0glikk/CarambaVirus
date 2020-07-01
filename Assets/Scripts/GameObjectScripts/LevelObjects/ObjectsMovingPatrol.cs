using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsMovingPatrol : MonoBehaviour
{
    public Transform[] Points;
    public float Speed = 0.0f, Distance = 0.0f;
    private int _currentPoint;
    public static bool isFacingRight = true;



    // Update is called once per frame
    void Update()
    {

        if (_currentPoint == Points.Length)
        {
            _currentPoint = 0;
            //Flip();
        }
        float _currentDistance = Vector3.Distance(transform.position, Points[_currentPoint].position);
        if (_currentDistance <= Distance)
        {
            _currentPoint++;
            //Flip();
        }
        transform.position = Vector3.MoveTowards(transform.position, Points[_currentPoint].position, Speed * Time.deltaTime);

        //  transform.LookAt(Points[_currentPoint].position);

    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
