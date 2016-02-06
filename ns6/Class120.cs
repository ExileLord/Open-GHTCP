using ns5;
using SharpAudio.ADI.OpenAL;
using System;
using System.Collections.Generic;

namespace ns6
{
	public class Class120 : IDisposable
	{
		private enum Enum13
		{
			const_0,
			const_1
		}

		private bool bool_0;

		private bool bool_1;

		private IntPtr intptr_0;

		private Struct62 struct62_0;

		private bool bool_2;

		private string string_0;

		private static readonly object object_0;

		private static readonly List<string> list_0;

		private static readonly Dictionary<Struct62, Class120> dictionary_0;

		private static bool bool_3;

		private static Class120.Enum13 enum13_0;

		static Class120()
		{
			Class120.object_0 = new object();
			Class120.list_0 = new List<string>();
			Class120.dictionary_0 = new Dictionary<Struct62, Class120>();
			Class120.bool_3 = true;
			Class120.smethod_0();
		}

		public Class120() : this(null, 0, 0, false, true)
		{
		}

		public Class120(string string_1, int int_0, int int_1, bool bool_4, bool bool_5)
		{
			this.method_0(string_1, int_0, int_1, bool_4, bool_5);
		}

		private static void smethod_0()
		{
			lock (Class120.object_0)
			{
				if (Class120.list_0.Count == 0)
				{
					try
					{
						if (Class118.alcIsExtensionPresent(IntPtr.Zero, "ALC_ENUMERATION_EXT"))
						{
							Class120.enum13_0 = Class120.Enum13.const_1;
							Class120.list_0.AddRange(Class118.smethod_1(IntPtr.Zero, Enum8.const_1));
						}
						else
						{
							Class120.enum13_0 = Class120.Enum13.const_0;
						}
						foreach (string arg_65_0 in Class120.list_0)
						{
						}
					}
					catch (DllNotFoundException)
					{
						Class120.bool_3 = false;
					}
				}
			}
		}

		private void method_0(string string_1, int int_0, int int_1, bool bool_4, bool bool_5)
		{
			if (!Class120.bool_3)
			{
				throw new DllNotFoundException("openal32.dll");
			}
			if (Class120.enum13_0 == Class120.Enum13.const_1 && Class120.list_0.Count == 0)
			{
				throw new NotSupportedException("No audio hardware is available.");
			}
			if (this.bool_2)
			{
				throw new NotSupportedException("Multiple AudioContexts are not supported.");
			}
			if (int_0 < 0)
			{
				throw new ArgumentOutOfRangeException("freq", int_0, "Should be greater than zero.");
			}
			if (int_1 < 0)
			{
				throw new ArgumentOutOfRangeException("refresh", int_1, "Should be greater than zero.");
			}
			if (!string.IsNullOrEmpty(string_1))
			{
				this.intptr_0 = Class118.alcOpenDevice(string_1);
			}
			if (this.intptr_0 == IntPtr.Zero)
			{
				this.intptr_0 = Class118.alcOpenDevice(null);
			}
			if (this.intptr_0 == IntPtr.Zero)
			{
				Class118.alcOpenDevice(Class118.smethod_0(IntPtr.Zero, Enum7.const_0));
			}
			if (this.intptr_0 == IntPtr.Zero && Class120.list_0.Count > 0)
			{
				this.intptr_0 = Class118.alcOpenDevice(Class120.list_0[0]);
			}
			if (this.intptr_0 == IntPtr.Zero)
			{
				throw new Exception2(string.Format("Audio device '{0}' does not exist or is tied up by another application.", string.IsNullOrEmpty(string_1) ? "default" : string_1));
			}
			this.method_1();
			List<int> list = new List<int>();
			if (int_0 != 0)
			{
				list.Add(4103);
				list.Add(int_0);
			}
			if (int_1 != 0)
			{
				list.Add(4104);
				list.Add(int_1);
			}
			list.Add(4105);
			list.Add(bool_4 ? 1 : 0);
			if (bool_5 && Class118.alcIsExtensionPresent(this.intptr_0, "ALC_EXT_EFX"))
			{
				int item;
				Class118.alcGetIntegerv(this.intptr_0, Enum9.const_7, 1, out item);
				list.Add(131075);
				list.Add(item);
			}
			list.Add(0);
			this.struct62_0 = Class118.alcCreateContext(this.intptr_0, list.ToArray());
			if (Struct62.smethod_1(this.struct62_0, Struct62.struct62_0))
			{
				Class118.alcCloseDevice(this.intptr_0);
				throw new Exception3("The audio context could not be created with the specified parameters.");
			}
			this.method_1();
			if (Class120.list_0.Count > 0)
			{
				this.method_4();
			}
			this.method_1();
			this.string_0 = Class118.smethod_0(this.intptr_0, Enum7.const_5);
			int num;
			Class118.alcGetIntegerv(this.intptr_0, Enum9.const_2, 4, out num);
			if (num > 0)
			{
				int[] array = new int[num];
				Class118.alcGetIntegerv(this.intptr_0, Enum9.const_3, array.Length * 4, out array[0]);
				int[] array2 = array;
				for (int i = 0; i < array2.Length; i++)
				{
					int num2 = array2[i];
					Enum6 @enum = (Enum6)num2;
					if (@enum == Enum6.const_2)
					{
						this.method_5(true);
					}
				}
			}
			lock (Class120.object_0)
			{
				Class120.dictionary_0.Add(this.struct62_0, this);
				this.bool_2 = true;
			}
		}

		private void method_1()
		{
			AlcError alcError = Class118.alcGetError(this.intptr_0);
			if (alcError != AlcError.NoError)
			{
				throw new Exception3(alcError.ToString());
			}
		}

		private static void smethod_1(Class120 class120_0)
		{
			lock (Class120.object_0)
			{
				if (!Class118.alcMakeContextCurrent((class120_0 != null) ? class120_0.struct62_0 : Struct62.struct62_0))
				{
					//Delegate129.delegate129_0;
					//"ALC {0} error detected at {1}.";
					Class118.alcGetError((class120_0 != null) ? Struct62.smethod_0(class120_0.struct62_0) : IntPtr.Zero).ToString();
					if (class120_0 == null)
					{
						//"null";
					}
					else
					{
						class120_0.ToString();
					}
					throw null;
				}
			}
		}

		public bool method_2()
		{
			bool result;
			lock (Class120.object_0)
			{
				if (Class120.dictionary_0.Count == 0)
				{
					result = false;
				}
				else
				{
					result = (Class120.smethod_2() == this);
				}
			}
			return result;
		}

		public void method_3(bool bool_4)
		{
			if (bool_4)
			{
				Class120.smethod_1(this);
				return;
			}
			Class120.smethod_1(null);
		}

		public void method_4()
		{
			Class120.smethod_1(this);
		}

		private void method_5(bool bool_4)
		{
			this.bool_1 = bool_4;
		}

		public static Class120 smethod_2()
		{
			Class120 result;
			lock (Class120.object_0)
			{
				if (Class120.dictionary_0.Count == 0)
				{
					result = null;
				}
				else
				{
					Class120 @class;
					Class120.dictionary_0.TryGetValue(Class118.alcGetCurrentContext(), out @class);
					result = @class;
				}
			}
			return result;
		}

		public void Dispose()
		{
			this.method_6(true);
			GC.SuppressFinalize(this);
		}

		private void method_6(bool bool_4)
		{
			if (!this.bool_0)
			{
				if (this.method_2())
				{
					this.method_3(false);
				}
				if (Struct62.smethod_2(this.struct62_0, Struct62.struct62_0))
				{
					Class120.dictionary_0.Remove(this.struct62_0);
					Class118.alcDestroyContext(this.struct62_0);
				}
				if (this.intptr_0 != IntPtr.Zero)
				{
					Class118.alcCloseDevice(this.intptr_0);
				}
				this.bool_0 = true;
			}
		}

		~Class120()
		{
			this.method_6(false);
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			return base.Equals(obj);
		}

		public override string ToString()
		{
			return string.Format("{0} (handle: {1}, device: {2})", this.string_0, this.struct62_0, this.intptr_0);
		}
	}
}
