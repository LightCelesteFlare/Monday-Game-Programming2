using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Week3 : MonoBehaviour
{
    // Unused code
    /*
    
    // Vectors
    public Vector3 velocity;


    Vector3 Cohesion()
    {
        Vector3 cohesionVector = new Vector3();
        int countSurvivors = 0;
        var neighbors = level.GetNeighbors(this, conf.cohesionRadius);
        if (neighbors.Count == 0)
            return cohesionVector;
        foreach (var survivor in neighbors)
        {
            if (isInFOV(survivor.transform.position))
            {
                cohesionVector += survivor.transform.position;
                countSurvivors++;
            }
        }
        if (countSurvivors == 0)
            return cohesionVector;
        cohesionVector /= countSurvivors;
        cohesionVector = cohesionVector - transform.position;
        cohesionVector = Vector3.Normalize(cohesionVector);
        return cohesionVector;
    }

    Vector3 Alignment()
    {
        Vector3 alignVector = new Vector3();
        var survivors = level.GetNeighbors(this, conf.alignmentRadius);
        if (survivors.Count == 0)
            return alignVector;
        foreach (var survivor in survivors)
        {
            if (isInFOV(survivor.transform.position))
                alignVector += survivor.velocity;
        }
        return alignVector.normalized;
    }

    Vector3 Separation()
    {
        Vector3 separationVector = new Vector3();
        var survivors = level.GetNeighbors(this, conf.separationRadius);
        if (survivors.Count == 0)
            return separationVector;
        foreach (var survivor in survivors)
        {
            if (isInFOV(survivor.transform.position))
                separationVector += survivor.velocity;
        }
        return separationVector.normalized;
    }

    virtual protected Vector3 Combine()
    {
        Vector3 finalVec = conf.cohesionPriority * Cohesion() + conf.alignmentPriority * Alignment()
            + conf.separationPriority * Separation();
        return finalVec;
    }

    bool isInFOV(Vector3 vec)
    {
        return Vector3.Angle(velocity, vec - Survivor.transform.position) <= conf.maxFOV;
    }
     
     
     
     
     
     
     
     
     
     */
}

