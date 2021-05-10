using System.Collections;
using System.Collections.Generic;
using FixMath.NET;
using UnityEngine;

public class MathCalculator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Fix64 GetDirectionofPointtoSegment(FixVector2 Pt1, FixVector2 Pt2, FixVector2 Pt3)
    {
        return (Pt3.x - Pt1.x)*(Pt2.y - Pt1.y) - (Pt2.x - Pt1.x)*(Pt3.y - Pt1.y);
    }

    public bool IsPointInRectDefinedbyTwoPoints(FixVector2 Pt1, FixVector2 Pt2, FixVector2 Pt3)
    {
        Fix64 MinX = 0;
        Fix64 MaxX = 0;
        Fix64 MinY = 0;
        Fix64 MaxY = 0;
        if (Pt1.x >= Pt2.x)
        {
            MinX = Pt2.x;
            MaxX = Pt1.x;
        }
        else
        {
            MinX = Pt1.x;
            MaxX = Pt2.x;
        }

        if (Pt1.y >= Pt2.y)
        {
            MinY = Pt2.y;
            MaxY = Pt1.y;
        }
        else
        {
            MinY = Pt1.y;
            MaxY = Pt2.y;
        }
        if (Pt3.x >= MinX && Pt3.x <= MaxX && Pt3.y >= MinY && Pt3.y <= MaxY)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void GetReflectDirWithDirAndBaseLine(FixVector3 OriginDir, FixVector2 NormalVector, ref FixVector3 ReflectDir)
    {
        FixVector2 DotProductX = OriginDir.x * NormalVector.x;
        FixVector2 DotProductY = OriginDir.y * NormalVector.y;
        NormalVector.Normalize();
        ReflectDir.x = OriginDir.x - NormalVector.x*DotProductX*2;
        ReflectDir.y = OriginDir.y - NormalVector.y*DotProductY*2;
    }

    public bool IsSegmentsInterscet(FixVector2 Pt1, FixVector2 Pt2, FixVector2 Pt3, FixVector2 Pt3)
    {
        Fix64 DirPt3toLine1 = GetDirectionofPointtoSegment(Pt1, Pt2, Pt3);
        Fix64 DirPt4toLine1 = GetDirectionofPointtoSegment(Pt1, Pt2, Pt4);
        Fix64 DirPt1toLine2 = GetDirectionofPointtoSegment(Pt3, Pt4, Pt1);
        Fix64 DirPt2toLine2 = GetDirectionofPointtoSegment(Pt3, Pt4, Pt2);

        if (DirPt3toLine1 > 0 && DirPt4toLine1 < 0 && DirPt1toLine2 > 0 && DirPt2toLine2 < 0) return true;
        else if (DirPt3toLine1 < 0 && DirPt4toLine1 > 0 && DirPt1toLine2 > 0 && DirPt2toLine2 < 0) return true;
        else if (DirPt3toLine1 > 0 && DirPt4toLine1 < 0 && DirPt1toLine2 < 0 && DirPt2toLine2 > 0) return true;
        else if (DirPt3toLine1 < 0 && DirPt4toLine1 > 0 && DirPt1toLine2 < 0 && DirPt2toLine2 > 0) return true;
        else if (DirPt3toLine1 == 0 && IsPointInRectDefinedbyTwoPoints(Pt1, Pt2, Pt3)) return true;
        else if (DirPt4toLine1 == 0 && IsPointInRectDefinedbyTwoPoints(Pt1, Pt2, Pt4)) return true;
        else if (DirPt1toLine2 == 0 && IsPointInRectDefinedbyTwoPoints(Pt3, Pt4, Pt1)) return true;
        else if (DirPt2toLine2 == 0 && IsPointInRectDefinedbyTwoPoints(Pt3, Pt4, Pt2)) return true;
        else return false;
    }
}
