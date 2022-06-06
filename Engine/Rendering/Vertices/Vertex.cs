using OpenTK.Mathematics;

namespace EngineSigma.Engine.Rendering.Vertices;

public readonly struct Vertex
{
    private readonly Vector2 _position;
    private readonly Vector2 _texCoord;
    private readonly Color4 _color;

    public static readonly VertexInfo VertexInfo = new VertexInfo(typeof(Vertex),
        new VertexAttribute("Position", 0, 2, 0),
        new VertexAttribute("TexCoord", 1, 2, 2 * sizeof(float)),
        new VertexAttribute("Color", 2, 4, 4 * sizeof(float)));

    public Vertex(Vector2 position, Vector2 texCoord, Color4 color)
    {
        _position = position;
        _texCoord = texCoord;
        _color = color;
    }
}