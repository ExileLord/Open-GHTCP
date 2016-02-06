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

		public Vector3(float float_0, float float_1, float float_2)
		{
			this.X = float_0;
			this.Y = float_1;
			this.Z = float_2;
		}

		public override string ToString()
		{
			return string.Format("({0}, {1}, {2})", this.X, this.Y, this.Z);
		}

		public override int GetHashCode()
		{
			return this.X.GetHashCode() ^ this.Y.GetHashCode() ^ this.Z.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			return obj is Vector3 && this.Equals((Vector3)obj);
		}

		public bool Equals(Vector3 other)
		{
			return this.X == other.X && this.Y == other.Y && this.Z == other.Z;
		}
	}
}
