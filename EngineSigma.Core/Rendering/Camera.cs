﻿using EngineSigma.Core.Extensions;
using OpenTK.Mathematics;

namespace EngineSigma.Core.Rendering;

public sealed class Camera
{
    public static Camera Instance { get; } = new Camera();

    public Vector2 Position { get; set; }

    public void Move(Vector2 movement)
    {
        Position += movement;
    }

    public Matrix4 ToViewMatrix()
    {
        return Matrix4.CreateTranslation(Position.ToVector3());
    }
    
    //not mark type as beforefieldinit
    static Camera() {}
    //no other instance can be created
    private Camera() {}
}