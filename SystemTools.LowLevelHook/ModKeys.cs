using System;

namespace SystemTools.LowLevelHook
{
	[Flags]
	public enum ModKeys : uint
	{
		None = 0u,
		Alt = 1u,
		Ctrl = 2u,
		Shift = 4u,
		Win = 8u
	}
}
