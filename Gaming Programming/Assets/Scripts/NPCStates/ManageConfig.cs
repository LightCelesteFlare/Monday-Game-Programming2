using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageConfig : MonoBehaviour {
    public float maxFOV = 180;

    // Cohesion Variables
    public float cohesionRadius = 15;
    public float cohesionPriority = 60;

    // Alignment Variables
    public float alignmentRadius = 10;
    public float alignmentPriority = 90;

    // Separation Variables
    public float separationRadius = 12;
    public float separationPriority = 90;
}
