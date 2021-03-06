using ns16;
using ns20;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace ns19
{
	public class ZonePakLoader
	{
		public delegate void Delegate8(TreeNode rootNode);

		public delegate void Delegate9(int percentCompleted, string fileName);

		private ZonePakLoader.Delegate8 delegate8_0;

		private ZonePakLoader.Delegate9 delegate9_0;

		private string _dataDirectory;

		public void method_0(ZonePakLoader.Delegate8 delegate8_1)
		{
			ZonePakLoader.Delegate8 @delegate = this.delegate8_0;
			ZonePakLoader.Delegate8 delegate2;
			do
			{
				delegate2 = @delegate;
				ZonePakLoader.Delegate8 value = (ZonePakLoader.Delegate8)Delegate.Combine(delegate2, delegate8_1);
				@delegate = Interlocked.CompareExchange<ZonePakLoader.Delegate8>(ref this.delegate8_0, value, delegate2);
			}
			while (@delegate != delegate2);
		}

		public void method_1(ZonePakLoader.Delegate9 delegate9_1)
		{
			ZonePakLoader.Delegate9 @delegate = this.delegate9_0;
			ZonePakLoader.Delegate9 delegate2;
			do
			{
				delegate2 = @delegate;
				ZonePakLoader.Delegate9 value = (ZonePakLoader.Delegate9)Delegate.Combine(delegate2, delegate9_1);
				@delegate = Interlocked.CompareExchange<ZonePakLoader.Delegate9>(ref this.delegate9_0, value, delegate2);
			}
			while (@delegate != delegate2);
		}

		public ZonePakLoader(string DataDirectory)
		{
			this._dataDirectory = DataDirectory;
		}

		public void method_2()
		{
			this.delegate9_0(0, "*.tex.xen");
			TreeNode treeNode = new TreeNode("Data");
			string[] files = Directory.GetFiles(this._dataDirectory.Remove(this._dataDirectory.Length - 1), "*.tex.xen", SearchOption.AllDirectories);
			string[] array = files;
			for (int i = 0; i < array.Length; i++)
			{
				string text = array[i];
				this.method_3(treeNode, new List<string>(text.Substring(this._dataDirectory.Length).Split(new char[]
				{
					'\\',
					'/'
				}, StringSplitOptions.RemoveEmptyEntries))).ToolTipText = text;
			}

			this.delegate9_0(1, "*.img.xen");
			files = Directory.GetFiles(this._dataDirectory.Remove(this._dataDirectory.Length - 1), "*.img.xen", SearchOption.AllDirectories);
			string[] array2 = files;
			for (int j = 0; j < array2.Length; j++)
			{
				string text2 = array2[j];
				this.method_3(treeNode, new List<string>(text2.Substring(this._dataDirectory.Length).Split(new char[]
				{
					'\\',
					'/'
				}, StringSplitOptions.RemoveEmptyEntries))).ToolTipText = text2;
			}

			int num = QbSongClass1.AddKeyToDictionary(".tex");
			int num2 = QbSongClass1.AddKeyToDictionary(".img");
			files = Directory.GetFiles(this._dataDirectory.Remove(this._dataDirectory.Length - 1), "*.pak.xen", SearchOption.AllDirectories);
			int num3 = 0;
			string[] array3 = files;
			for (int k = 0; k < array3.Length; k++)
			{
				string text3 = array3[k];
				this.delegate9_0(1 + (int)(98.0 * (double)(++num3) / (double)files.Length), KeyGenerator.GetFileName(text3));
				try
				{
					using (zzPakNode2 @class = File.Exists(text3.Replace(".pak.xen", ".pab.xen")) ? new zzPabNode(text3, text3.Replace(".pak.xen", ".pab.xen"), false) : new zzPakNode2(text3, false))
					{
						List<TreeNode> list = new List<TreeNode>();
						foreach (Interface12 current in @class.list_0)
						{
							int num4 = current.imethod_7();
							if (current.imethod_4() == num || current.imethod_4() == num2)
							{
								list.Add(new TreeNode(QbSongClass1.ContainsKey(num4) ? KeyGenerator.GetFileName(QbSongClass1.GetDictString(num4)) : KeyGenerator.ValToHex32bit(num4))
								{
									ToolTipText = text3,
									Tag = num4
								});
							}
						}
						if (list.Count > 0)
						{
							this.method_3(treeNode, new List<string>(text3.Substring(this._dataDirectory.Length).Split(new char[]
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
			this.delegate8_0(treeNode);
		}

		public TreeNode method_3(TreeNode treeNode_0, List<string> list_0)
		{
			if (list_0.Count == 0)
			{
				return treeNode_0;
			}
			string text;
			if (!treeNode_0.Nodes.ContainsKey(list_0[0]))
			{
				text = list_0[0];
				list_0.RemoveAt(0);
				treeNode_0.Nodes.Add(text, text);
				return this.method_3(treeNode_0.Nodes[text], list_0);
			}
			if (list_0.Count == 1)
			{
				return treeNode_0.Nodes[list_0[0]];
			}
			text = list_0[0];
			list_0.RemoveAt(0);
			return this.method_3(treeNode_0.Nodes[text], list_0);
		}
	}
}
