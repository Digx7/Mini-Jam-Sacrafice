using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpecialEvents : MonoBehaviour
{
}

[System.Serializable]
public class IntEvent : UnityEvent<int>
{
}

[System.Serializable]
public class FloatEvent : UnityEvent<float>
{
}

[System.Serializable]
public class BoolEvent : UnityEvent<bool>
{
}

[System.Serializable]
public class Vector2Event : UnityEvent<Vector2>
{
}
