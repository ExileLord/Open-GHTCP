using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ns16;
using ns20;

namespace ns19
{
    //I'm not positive this has to do with pak files yet

	public class zzPakNode1 : TreeNode
	{
		public bool bool_0;

		public zzPakNode1() : this("newfolder")
		{
			ImageIndex = 38;
			SelectedImageIndex = 38;
		}

		public zzPakNode1(bool bool_1) : this("(Unknown)")
		{
			ImageIndex = 38;
			SelectedImageIndex = 38;
			bool_0 = bool_1;
		}

		public zzPakNode1(string string_0) : base(string_0)
		{
			Name = string_0;
			ImageIndex = 38;
			SelectedImageIndex = 38;
		}

		public void method_0(string string_0, zzGenericNode1 class308_0)
		{
			method_1(string_0, new Class309(string_0, class308_0));
		}

		public void method_1<T>(string string_0, T gparam_0) where T : TreeNode
		{
			var @class = string.IsNullOrEmpty(string_0) ? this : method_2(KeyGenerator.smethod_10(string_0));
			if (@class.Nodes.ContainsKey(gparam_0.Text))
			{
				@class.Nodes.RemoveByKey(gparam_0.Text);
			}
			@class.Nodes.Add(gparam_0);
			if (gparam_0 is Interface12)
			{
				TreeNode treeNode = this;
				var level = treeNode.Level;
				while (level-- != 0)
				{
					treeNode = treeNode.Parent;
				}
				var class2 = treeNode as zzPakNode2;
				var @interface = class2.method_10(string_0);
				if (@interface == null)
				{
					class2.list_0.Add(gparam_0 as Interface12);
					return;
				}
				class2.list_0[class2.list_0.IndexOf(@interface)] = (gparam_0 as Interface12);
			}
		}

		public virtual string vmethod_0()
		{
			if (Parent == null)
			{
				return "";
			}
			return ((zzPakNode1)Parent).vmethod_0() + Text + "\\";
		}

		public zzPakNode1 method_2(string string_0)
		{
			if (string.IsNullOrEmpty(string_0))
			{
				return this;
			}
			var list = new List<string>(string_0.Split(new[]
			{
				'\\',
				'/'
			}, StringSplitOptions.RemoveEmptyEntries));
			zzPakNode1 @class;
			if (Nodes.ContainsKey(list[0]) && Nodes[list[0]] is zzPakNode1)
			{
				@class = (zzPakNode1)Nodes[list[0]];
				list.RemoveAt(0);
				@class = ((list.Count > 0) ? @class.method_3(list) : @class);
			}
			else
			{
				@class = new zzPakNode1(list[0]);
				list.RemoveAt(0);
				Nodes.Add(@class);
				@class = ((list.Count > 0) ? @class.method_3(list) : @class);
			}
			return @class;
		}

		public zzPakNode1 method_3(List<string> list_0)
		{
			if (list_0.Count == 0)
			{
				return this;
			}
			if (!Nodes.ContainsKey(list_0[0]) || !(Nodes[list_0[0]] is zzPakNode1))
			{
				var @class = new zzPakNode1(list_0[0]);
				list_0.RemoveAt(0);
				Nodes.Add(@class);
				return @class.method_3(list_0);
			}
			if (list_0.Count == 1)
			{
				return (zzPakNode1)Nodes[list_0[0]];
			}
			var key = list_0[0];
			list_0.RemoveAt(0);
			return ((zzPakNode1)Nodes[key]).method_3(list_0);
		}
	}
}
