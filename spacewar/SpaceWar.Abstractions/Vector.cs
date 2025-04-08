using System.Collections;
namespace SpaceWar.Abstractions;

public class Vector : IEnumerable<int>
{
    private readonly int[] _coordinates;

    public Vector(int[] coordinates)
    {
        _coordinates = coordinates?.ToArray() ?? throw new ArgumentNullException(nameof(coordinates));

        if (_coordinates.Length == 0) throw new ArgumentException("Vector cannot be empty");
    }
    public int Dimention => _coordinates.Length;
    public int this[int index] => _coordinates[index];
    public IEnumerator<int> GetEnumerator() => (_coordinates as IEnumerable<int>).GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    public static Vector operator +(Vector x, Vector y)
    {
        if (x.Dimention != y.Dimention) throw new ArgumentException("Vectors must have same dimensions");

        return new Vector(x._coordinates.Zip(y._coordinates, (a, b) => a + b).ToArray());
    }
    public static bool operator ==(Vector x, Vector y)
    {
        if (ReferenceEquals(x, y)) return true;
        if (x is null || y is null) return false;
        return x._coordinates.SequenceEqual(y._coordinates);
    }
    public static bool operator !=(Vector x, Vector y) => !(x == y);
    public bool Equals(Vector other_vector) => this == other_vector;
    public override bool Equals(object? obj) => obj is Vector other_vector && Equals(other_vector);
    public override int GetHashCode() => _coordinates.Aggregate(17, (hash, val) => unchecked(hash * 23 + val));
}