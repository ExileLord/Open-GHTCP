using System;
using System.Collections.Generic;
using ns5;
using SharpAudio.ADI.OpenAL;

namespace ns6
{
	public class Class120 : IDisposable
	{
		private enum Enum13
		{
			Const0,
			Const1
		}

		private bool _bool0;

		private bool _bool1;

		private IntPtr _intptr0;

		private Struct62 _struct620;

		private bool _bool2;

		private string _string0;

		private static readonly object Object0;

		private static readonly List<string> List0;

		private static readonly Dictionary<Struct62, Class120> Dictionary0;

		private static bool _bool3;

		private static Enum13 _enum130;

		static Class120()
		{
			Object0 = new object();
			List0 = new List<string>();
			Dictionary0 = new Dictionary<Struct62, Class120>();
			_bool3 = true;
			smethod_0();
		}

		public Class120() : this(null, 0, 0, false, true)
		{
		}

		public Class120(string string1, int int0, int int1, bool bool4, bool bool5)
		{
			method_0(string1, int0, int1, bool4, bool5);
		}

		private static void smethod_0()
		{
			lock (Object0)
			{
				if (List0.Count == 0)
				{
					try
					{
						if (OpenAl.alcIsExtensionPresent(IntPtr.Zero, "ALC_ENUMERATION_EXT"))
						{
							_enum130 = Enum13.Const1;
							List0.AddRange(OpenAl.smethod_1(IntPtr.Zero, Enum8.Const1));
						}
						else
						{
							_enum130 = Enum13.Const0;
						}
						foreach (var arg650 in List0)
						{
						}
					}
					catch (DllNotFoundException)
					{
						_bool3 = false;
					}
				}
			}
		}

		private void method_0(string string1, int int0, int int1, bool bool4, bool bool5)
		{
			if (!_bool3)
			{
				throw new DllNotFoundException("openal32.dll");
			}
			if (_enum130 == Enum13.Const1 && List0.Count == 0)
			{
				throw new NotSupportedException("No audio hardware is available.");
			}
			if (_bool2)
			{
				throw new NotSupportedException("Multiple AudioContexts are not supported.");
			}
			if (int0 < 0)
			{
				throw new ArgumentOutOfRangeException("freq", int0, "Should be greater than zero.");
			}
			if (int1 < 0)
			{
				throw new ArgumentOutOfRangeException("refresh", int1, "Should be greater than zero.");
			}
			if (!string.IsNullOrEmpty(string1))
			{
				_intptr0 = OpenAl.alcOpenDevice(string1);
			}
			if (_intptr0 == IntPtr.Zero)
			{
				_intptr0 = OpenAl.alcOpenDevice(null);
			}
			if (_intptr0 == IntPtr.Zero)
			{
				OpenAl.alcOpenDevice(OpenAl.smethod_0(IntPtr.Zero, Enum7.Const0));
			}
			if (_intptr0 == IntPtr.Zero && List0.Count > 0)
			{
				_intptr0 = OpenAl.alcOpenDevice(List0[0]);
			}
			if (_intptr0 == IntPtr.Zero)
			{
				throw new Exception2(string.Format("Audio device '{0}' does not exist or is tied up by another application.", string.IsNullOrEmpty(string1) ? "default" : string1));
			}
			method_1();
			var list = new List<int>();
			if (int0 != 0)
			{
				list.Add(4103);
				list.Add(int0);
			}
			if (int1 != 0)
			{
				list.Add(4104);
				list.Add(int1);
			}
			list.Add(4105);
			list.Add(bool4 ? 1 : 0);
			if (bool5 && OpenAl.alcIsExtensionPresent(_intptr0, "ALC_EXT_EFX"))
			{
				int item;
				OpenAl.alcGetIntegerv(_intptr0, Enum9.Const7, 1, out item);
				list.Add(131075);
				list.Add(item);
			}
			list.Add(0);
			_struct620 = OpenAl.alcCreateContext(_intptr0, list.ToArray());
			if (Struct62.smethod_1(_struct620, Struct62.Struct620))
			{
				OpenAl.alcCloseDevice(_intptr0);
				throw new Exception3("The audio context could not be created with the specified parameters.");
			}
			method_1();
			if (List0.Count > 0)
			{
				method_4();
			}
			method_1();
			_string0 = OpenAl.smethod_0(_intptr0, Enum7.Const5);
			int num;
			OpenAl.alcGetIntegerv(_intptr0, Enum9.Const2, 4, out num);
			if (num > 0)
			{
				var array = new int[num];
				OpenAl.alcGetIntegerv(_intptr0, Enum9.Const3, array.Length * 4, out array[0]);
				var array2 = array;
				for (var i = 0; i < array2.Length; i++)
				{
					var num2 = array2[i];
					var @enum = (Enum6)num2;
					if (@enum == Enum6.Const2)
					{
						method_5(true);
					}
				}
			}
			lock (Object0)
			{
				Dictionary0.Add(_struct620, this);
				_bool2 = true;
			}
		}

		private void method_1()
		{
			var alcError = OpenAl.alcGetError(_intptr0);
			if (alcError != AlcError.NoError)
			{
				throw new Exception3(alcError.ToString());
			}
		}

		private static void smethod_1(Class120 class1200)
		{
			lock (Object0)
			{
				if (!OpenAl.alcMakeContextCurrent((class1200 != null) ? class1200._struct620 : Struct62.Struct620))
				{
					//Delegate129.delegate129_0;
					//"ALC {0} error detected at {1}.";
					OpenAl.alcGetError((class1200 != null) ? Struct62.smethod_0(class1200._struct620) : IntPtr.Zero).ToString();
					if (class1200 == null)
					{
						//"null";
					}
					else
					{
						class1200.ToString();
					}
					throw null;
				}
			}
		}

		public bool method_2()
		{
			bool result;
			lock (Object0)
			{
				if (Dictionary0.Count == 0)
				{
					result = false;
				}
				else
				{
					result = (smethod_2() == this);
				}
			}
			return result;
		}

		public void method_3(bool bool4)
		{
			if (bool4)
			{
				smethod_1(this);
				return;
			}
			smethod_1(null);
		}

		public void method_4()
		{
			smethod_1(this);
		}

		private void method_5(bool bool4)
		{
			_bool1 = bool4;
		}

		public static Class120 smethod_2()
		{
			Class120 result;
			lock (Object0)
			{
				if (Dictionary0.Count == 0)
				{
					result = null;
				}
				else
				{
					Class120 @class;
					Dictionary0.TryGetValue(OpenAl.alcGetCurrentContext(), out @class);
					result = @class;
				}
			}
			return result;
		}

		public void Dispose()
		{
			method_6(true);
			GC.SuppressFinalize(this);
		}

		private void method_6(bool bool4)
		{
			if (!_bool0)
			{
				if (method_2())
				{
					method_3(false);
				}
				if (Struct62.smethod_2(_struct620, Struct62.Struct620))
				{
					Dictionary0.Remove(_struct620);
					OpenAl.alcDestroyContext(_struct620);
				}
				if (_intptr0 != IntPtr.Zero)
				{
					OpenAl.alcCloseDevice(_intptr0);
				}
				_bool0 = true;
			}
		}

		~Class120()
		{
			method_6(false);
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
			return string.Format("{0} (handle: {1}, device: {2})", _string0, _struct620, _intptr0);
		}
	}
}
