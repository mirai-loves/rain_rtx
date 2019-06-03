﻿using System;

namespace RainRTX
{
    public struct RayHit
    {
        public bool intersected;
        public Color24 color;
        public float specular;
        public Vector3 normal;
        public Vector3 position;
    }
}
