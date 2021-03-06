﻿using System;
using System.Numerics;

namespace RainRTX
{
    public struct RayHit
    {
        public IntersectionType intersection;
        public Color24 specular_vec;
        public Color24 albedo;
        public Vector3 normal;
        public Vector3 position;
    }
}
