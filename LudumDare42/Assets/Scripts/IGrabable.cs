using System;
using UnityEngine;

interface IGrabable
{
    void SetHighlighted(bool highlighted);
    Transform GetTransform();
    int GetMassValue();
}
