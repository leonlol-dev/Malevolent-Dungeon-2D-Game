using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DemonBaseState
{
    public abstract void Start();
    public abstract void UpdateState();
    public abstract void EnterState();
    public abstract void FixedUpdateState();
    public abstract void OnTriggerEnter(Collider other);
}
