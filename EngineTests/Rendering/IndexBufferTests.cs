﻿using EngineSigma.Core.Rendering;
using FluentAssertions;
using NSubstitute;
using NSubstitute.ReceivedExtensions;
using OpenTK.Graphics.OpenGL4;
using Buffer = System.Buffer;

namespace EngineTests.Rendering;

public class IndexBufferTests
{
    private const int Handle = 69;
    
    [Fact]
    public void IndexBufferCtorTest()
    {
        //Arrange
        var glWrapper = Substitute.For<IGLWrapper>();
        var data = new uint[32];
        glWrapper.GenBuffer().Returns(Handle);

        //Act
        var iBuffer = new IndexBuffer(glWrapper,data);
        
        //Assert
        glWrapper.Received(1).GenBuffer();
        glWrapper.Received(1).BindBuffer(BufferTarget.ElementArrayBuffer, Handle);
        glWrapper.Received(1).BufferData(BufferTarget.ElementArrayBuffer, Buffer.ByteLength(data), data, BufferUsageHint.StaticDraw);
        iBuffer.Handle.Should().Be(Handle);
    }

    [Fact]
    public void Bind_ShouldBindIndexBuffer()
    {
        //Arrange
        var glWrapper = Substitute.For<IGLWrapper>();
        glWrapper.GenBuffer().Returns(Handle);
        var data = new uint[32];
        var iBuffer = new IndexBuffer(glWrapper,data);
        
        //Act
        iBuffer.Bind();
        
        //Assert
        glWrapper.Received(2).BindBuffer(BufferTarget.ElementArrayBuffer, Handle);
    }

    [Fact]
    public void UnBind_ShouldUnBindBuffer()
    {
        //Arrange
        var glWrapper = Substitute.For<IGLWrapper>();
        glWrapper.GenBuffer().Returns(Handle);
        var data = new uint[32];
        var iBuffer = new IndexBuffer(glWrapper,data);
        
        //Act
        iBuffer.UnBind();
        
        //Assert
        glWrapper.Received(1).BindBuffer(BufferTarget.ElementArrayBuffer, 0);
    }

    [Fact]
    public void Dispose_ShouldDeleteBuffer()
    {
        //Arrange
        var glWrapper = Substitute.For<IGLWrapper>();
        glWrapper.GenBuffer().Returns(Handle);
        var data = new uint[32];
        var iBuffer = new IndexBuffer(glWrapper,data);
        
        //Act
        iBuffer.Dispose();
        
        //Assert
        glWrapper.Received(1).DeleteBuffer(Handle);
    }
    
    [Fact]
    public void Dispose_ShouldReturn_WhenAlreadyDisposed()
    {
        //Arrange
        var glWrapper = Substitute.For<IGLWrapper>();
        glWrapper.GenBuffer().Returns(Handle);
        var data = new uint[32];
        var iBuffer = new IndexBuffer(glWrapper,data);
        
        //Act
        iBuffer.Dispose();
        iBuffer.Dispose();
        
        //Assert
        glWrapper.Received(1).DeleteBuffer(Handle);
    }
}