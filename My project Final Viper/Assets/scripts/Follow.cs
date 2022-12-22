using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public float circleDiameter;
    public Transform Body;
    public List<Transform> snakeTail = new List<Transform>();
    private List<Vector2> positions = new List<Vector2>();

    private void Start()
    {
        positions.Add(Body.position);
    }

    // Update is called once per frame
    private void Update()
    {
        float distance = ((Vector2)Body.position - positions[0]).magnitude;
        if(distance > circleDiameter)
        {
            Vector2 direction = ((Vector2)Body.position - positions[0]).normalized;
            positions.Insert(0, positions[0] + direction * circleDiameter);
            positions.RemoveAt(positions.Count - 1);
            distance -= circleDiameter;

        }
        for(int i = 0; i < snakeTail.Count; i++)
        {
            snakeTail[i].position = Vector2.Lerp(positions[i + 1], positions[i], distance / circleDiameter);
        }
    }
    public void AddTail()
    {
        Transform tail = Instantiate(Body, positions[positions.Count - 1], Quaternion.identity, transform);
        snakeTail.Add(tail);
        positions.Add(tail.position);
    }
}
