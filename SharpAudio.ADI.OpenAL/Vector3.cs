using System;
using System.Runtime.InteropServices;

namespace SharpAudio.ADI.OpenAL
{
	[Serializable]
	public struct Vector3 : IEquatable<Vector3>
	{
		public float X;

		public float Y;

		public float Z;

		public static readonly Vector3 UnitX = new Vector3(1f, 0f, 0f);

		public static readonly Vector3 UnitY = new Vector3(0f, 1f, 0f);

		public static readonly Vector3 UnitZ = new Vector3(0f, 0f, 1f);

		public static readonly Vector3 Zero = new Vector3(0f, 0f, 0f);

		public static readonly int SizeInBytes = Marshal.SizeOf(default(Vector3));

		public Vector3(float float0, float float1, float float2)
		{
			X = float0;
			Y = float1;
			Z = float2;
		}

		public override string ToString()
		{
			return string.Format("({0}, {1}, {2})", X, Y, Z);
		}

		public override int GetHashCode()
		{
			return X.GetHashCode() ^ Y.GetHashCode() ^ Z.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			return obj is Vector3 && Equals((Vector3)obj);
		}

		public bool Equals(Vector3 other)
		{
			return X == other.X && Y == other.Y && Z == other.Z;
		}
	}
}
