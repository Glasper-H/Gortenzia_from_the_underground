using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementalLine : MonoBehaviour
{
    public enum MovementType
    {
        Moveing,
        Lerping
    }

    public MovementType Type = MovementType.Moveing;
    public MoveForLine MyPath;
    public float speed = 1;
    public float maxDistance = .1f;

    private IEnumerator<Transform> pointInPath;

    void Start()
    {
        if (MyPath == null)
        {
            Debug.Log("���� ����");
            return;
        }

        pointInPath = MyPath.GetNextPathPoint();

        pointInPath.MoveNext();

        if (pointInPath.Current == null)
        {
            Debug.Log("����� ������");
            return;
        }

        transform.position = pointInPath.Current.position;
    }

    void Update()
    {
        if (pointInPath == null || pointInPath.Current == null)
        {
            Debug.Log("��� ��� ����� �Ϩ�");
            return;
        } 

        if (Type == MovementType.Moveing)
        {
            transform.position = Vector3.MoveTowards(transform.position, pointInPath.Current.position, Time.deltaTime * speed);
        }
        else if (Type == MovementType.Lerping)
        {
            transform.position = Vector3.Lerp(transform.position, pointInPath.Current.position, Time.deltaTime * speed);
        }

        var distanceSqure = (transform.position - pointInPath.Current.position).sqrMagnitude;
        if (distanceSqure < maxDistance * maxDistance)
        {
            pointInPath.MoveNext();
        }
    }
}
// � ��� ����� ��� ��� ��������, �� ��� ��������, ��� ��� ����� ���� ������

