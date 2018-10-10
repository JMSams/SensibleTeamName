using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderWeb : MonoBehaviour
{
    public float radiusPerSegment = 1f;
    public int segments = 7;

    public int sections = 8;
    float degreesPerSection { get { return 360f / sections; } }

    public float lineWidth = 0.02f;
    public Material lineMaterial;

    [HideInInspector]
    public List<LineRenderer> lines;

    public void CreateWeb()
    {
        if (lines != null)
        {
            foreach (LineRenderer line in lines)
            {
                DestroyImmediate(line.gameObject);
            }
        }

        lines = new List<LineRenderer>();

        for (int i = 0; i < sections; i++)
        {
            LineRenderer temp = NewLine();
            temp.SetPositions(new Vector3[]
                {
                    Vector3.zero,
                    PolarToCartesian(segments * radiusPerSegment, i * degreesPerSection)
                });
            lines.Add(temp);
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
            lines.Add(temp);
        }

        transform.localRotation = Quaternion.Euler(0f, 0f, -90f);
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
        temp.startWidth = lineWidth;
        temp.endWidth = lineWidth;
        temp.material = lineMaterial;
        temp.useWorldSpace = false;
        return temp;
    }
}