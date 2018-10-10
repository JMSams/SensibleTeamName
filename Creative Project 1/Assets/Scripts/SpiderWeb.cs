using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderWeb : MonoBehaviour
{
    public float radiusPerSegment = 1f;
    public int segments = 7;

    public int sections = 8;
    float degreesPerSection { get { return 360f / sections; } }

    public Material lineMaterial;

    List<LineRenderer> lines;

    void Start()
    {
        lines = new List<LineRenderer>();

        for (int i = 0; i < sections; i++)
        {
            LineRenderer temp = NewLine();
            temp.SetPositions(new Vector3[]
                {
                    Vector3.zero,
                    PolarToCartesian(segments * radiusPerSegment, i * degreesPerSection)
                });
        }

        for (int s = 1; s <= segments; s++)
        {
            LineRenderer temp = NewLine();
            temp.positionCount = sections;
            temp.loop = true;
            for (int i = 0; i < sections; i++)
            {
                temp.SetPosition(i, PolarToCartesian(s * radiusPerSegment, i * degreesPerSection));
            }
        }

        transform.Rotate(0, 0, 90, Space.Self);
    }
    
    Vector2 PolarToCartesian(float r, float angle, bool radians = false)
    {
        if (!radians)
            angle = angle * Mathf.Deg2Rad;

        return new Vector2(
            Mathf.Cos(angle) * r,
            Mathf.Sin(angle) * r
            );
    }

    LineRenderer NewLine()
    {
        LineRenderer temp = new GameObject("WebSegment").AddComponent<LineRenderer>();
        temp.transform.SetParent(this.transform);
        temp.transform.localPosition = Vector3.zero;
        temp.startWidth = 0.05f;
        temp.endWidth = 0.05f;
        temp.material = lineMaterial;
        temp.useWorldSpace = false;
        return temp;
    }
}