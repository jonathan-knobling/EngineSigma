﻿using OpenTK.Graphics.OpenGL4;

namespace EngineSigma.Core.Rendering;

internal class GLStateHandler : IGLStateHandler
{
    private readonly IGLWrapper _glWrapper;

    public Handle ActiveTexture { get; private set; }
    public Handle ActiveVertexArray { get; private set; }
    public Handle ActiveVertexBuffer { get; private set; }
    public Handle ActiveIndexBuffer { get; private set; }

    public GLStateHandler(IGLWrapper glWrapper)
    {
        _glWrapper = glWrapper;
        ActiveTexture = new Handle();
        ActiveVertexArray = new Handle();
        ActiveVertexBuffer = new Handle();
        ActiveIndexBuffer = new Handle();
    }
    
    public void UseTexture(Handle handle)
    {
        if (ActiveTexture == handle) return;
        _glWrapper.ActiveTexture(TextureUnit.Texture0);
        _glWrapper.BindTexture(TextureTarget.Texture2D, handle);
        ActiveTexture = handle;
    }

    public void UseVertexArray(Handle handle)
    {
        if (ActiveVertexArray == handle) return;
        _glWrapper.BindVertexArray(handle);
        ActiveVertexArray = handle;
    }

    public void UseVertexBuffer(Handle handle)
    {
        if (ActiveVertexBuffer == handle) return;
        _glWrapper.BindBuffer(BufferTarget.ArrayBuffer, handle);
        ActiveVertexBuffer = handle;
    }

    public void UseIndexBuffer(Handle handle)
    {
        if (ActiveIndexBuffer == handle) return;
        _glWrapper.BindBuffer(BufferTarget.ElementArrayBuffer, handle);
        ActiveIndexBuffer = handle;
    }
}