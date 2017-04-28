using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using GHNamespace9;
using GHNamespaceE;

namespace GHNamespaceC
{
	public class ZonePakLoader
	{
		public delegate void Delegate8(TreeNode rootNode);

		public delegate void Delegate9(int percentCompleted, string fileName);

		private Delegate8 _delegate80;

		private Delegate9 _delegate90;

		private readonly string _dataDirectory;

		public void method_0(Delegate8 delegate81)
		{
			var @delegate = _delegate80;
			Delegate8 delegate2;
			do
			{
				delegate2 = @delegate;
				var value = (Delegate8)Delegate.Combine(delegate2, delegate81);
				@delegate = Interlocked.CompareExchange(ref _delegate80, value, delegate2);
			}
			while (@delegate != delegate2);
		}

		public void method_1(Delegate9 delegate91)
		{
			var @delegate = _delegate90;
			Delegate9 delegate2;
			do
			{
				delegate2 = @delegate;
				var value = (Delegate9)Delegate.Combine(delegate2, delegate91);
				@delegate = Interlocked.CompareExchange(ref _delegate90, value, delegate2);
			}
			while (@delegate != delegate2);
		}

		public ZonePakLoader(string dataDirectory)
		{
			_dataDirectory = dataDirectory;
		}

		public void method_2()
		{
			_delegate90(0, "*.tex.xen");
			var treeNode = new TreeNode("Data");
			var files = Directory.GetFiles(_dataDirectory.Remove(_dataDirectory.Length - 1), "*.tex.xen", SearchOption.AllDirectories);
			var array = files;
			for (var i = 0; i < array.Length; i++)
			{
				var text = array[i];
				method_3(treeNode, new List<string>(text.Substring(_dataDirectory.Length).Split(new[]
				{
					'\\',
					'/'
				}, StringSplitOptions.RemoveEmptyEntries))).ToolTipText = text;
			}

			_delegate90(1, "*.img.xen");
			files = Directory.GetFiles(_dataDirectory.Remove(_dataDirectory.Length - 1), "*.img.xen", SearchOption.AllDirectories);
			var array2 = files;
			for (var j = 0; j < array2.Length; j++)
			{
				var text2 = array2[j];
				method_3(treeNode, new List<string>(text2.Substring(_dataDirectory.Length).Split(new[]
				{
					'\\',
					'/'
				}, StringSplitOptions.RemoveEmptyEntries))).ToolTipText = text2;
			}

			var num = QbSongClass1.AddKeyToDictionary(".tex");
			var num2 = QbSongClass1.AddKeyToDictionary(".img");
			files = Directory.GetFiles(_dataDirectory.Remove(_dataDirectory.Length - 1), "*.pak.xen", SearchOption.AllDirectories);
			var num3 = 0;
			var array3 = files;
			for (var k = 0; k < array3.Length; k++)
			{
				var text3 = array3[k];
				_delegate90(1 + (int)(98.0 * ++num3 / files.Length), KeyGenerator.GetFileName(text3));
				try
				{
					using (var @class = File.Exists(text3.Replace(".pak.xen", ".pab.xen")) ? new ZzPabNode(text3, text3.Replace(".pak.xen", ".pab.xen"), false) : new ZzPakNode2(text3, false))
					{
						var list = new List<TreeNode>();
						foreach (var current in @class.List0)
						{
							var num4 = current.imethod_7();
							if (current.imethod_4() == num || current.imethod_4() == num2)
							{
								list.Add(new TreeNode(QbSongClass1.ContainsKey(num4) ? KeyGenerator.GetFileName(QbSongClass1.GetDictString(num4)) : KeyGenerator.ValToHex32Bit(num4))
								{
									ToolTipText = text3,
									Tag = num4
								});
							}
						}
						if (list.Count > 0)
						{
							method_3(treeNode, new List<string>(text3.Substring(_dataDirectory.Length).Split(new[]
							{
								'\\',
								'/'
							}, StringSplitOptions.RemoveEmptyEntries))).Nodes.AddRange(list.ToArray());
						}
					}
				}
				catch
				{
				}
				GC.Collect();
			}
			_delegate80(treeNode);
		}

		public TreeNode method_3(TreeNode treeNode0, List<string> list0)
		{
			if (list0.Count == 0)
			{
				return treeNode0;
			}
			string text;
			if (!treeNode0.Nodes.ContainsKey(list0[0]))
			{
				text = list0[0];
				list0.RemoveAt(0);
				treeNode0.Nodes.Add(text, text);
				return method_3(treeNode0.Nodes[text], list0);
			}
			if (list0.Count == 1)
			{
				return treeNode0.Nodes[list0[0]];
			}
			text = list0[0];
			list0.RemoveAt(0);
			return method_3(treeNode0.Nodes[text], list0);
		}
	}
}
