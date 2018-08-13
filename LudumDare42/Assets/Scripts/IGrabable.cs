using System;
using UnityEngine;

interface IGrabable
{
    bool IsGrabbed { get; set; }
    void SetHighlighted(bool highlighted);
    Transform GetTransform();
    int GetMassValue();
}
