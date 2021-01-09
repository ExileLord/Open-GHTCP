using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GHNamespace9;
using GHNamespaceE;

namespace GHNamespaceC
{
    // I'm not positive this has to do with pak files yet
    public class ZzPakNode1 : TreeNode
    {
        public bool Bool0;

        public ZzPakNode1() : this("newfolder")
        {
            ImageIndex = 38;
            SelectedImageIndex = 38;
        }

        public ZzPakNode1(bool bool1) : this("(Unknown)")
        {
            ImageIndex = 38;
            SelectedImageIndex = 38;
            Bool0 = bool1;
        }

        public ZzPakNode1(string string0) : base(string0)
        {
            Name = string0;
            ImageIndex = 38;
            SelectedImageIndex = 38;
        }

        public void zzCreateQbFileFrom(string string0, ZzGenericNode1 class3080)
        {
            method_1(string0, new Class309(string0, class3080));
        }

        public void method_1<T>(string string0, T gparam0) where T : TreeNode
        {
            ZzPakNode1 @class = string.IsNullOrEmpty(string0) ? this : method_2(KeyGenerator.smethod_10(string0));
            if (@class.Nodes.ContainsKey(gparam0.Text))
            {
                @class.Nodes.RemoveByKey(gparam0.Text);
            }
            @class.Nodes.Add(gparam0);
            if (gparam0 is INterface12)
            {
                TreeNode treeNode = this;
                int level = treeNode.Level;
                while (level-- != 0)
                {
                    treeNode = treeNode.Parent;
                }
                ZzPakNode2 class2 = treeNode as ZzPakNode2;
                INterface12 @interface = class2.method_10(string0);
                if (@interface == null)
                {
                    class2.List0.Add(gparam0 as INterface12);
                    return;
                }
                class2.List0[class2.List0.IndexOf(@interface)] = (gparam0 as INterface12);
            }
        }

        public virtual string vmethod_0()
        {
            if (Parent == null)
            {
                return "";
            }
            return ((ZzPakNode1) Parent).vmethod_0() + Text + "\\";
        }

        public ZzPakNode1 method_2(string string0)
        {
            if (string.IsNullOrEmpty(string0))
            {
                return this;
            }
            List<string> list = new List<string>(string0.Split(new[]
            {
                '\\',
                '/'
            }, StringSplitOptions.RemoveEmptyEntries));
            ZzPakNode1 @class;
            if (Nodes.ContainsKey(list[0]) && Nodes[list[0]] is ZzPakNode1)
            {
                @class = (ZzPakNode1) Nodes[list[0]];
                list.RemoveAt(0);
                @class = ((list.Count > 0) ? @class.method_3(list) : @class);
            }
            else
            {
                @class = new ZzPakNode1(list[0]);
                list.RemoveAt(0);
                Nodes.Add(@class);
                @class = ((list.Count > 0) ? @class.method_3(list) : @class);
            }
            return @class;
        }

        public ZzPakNode1 method_3(List<string> list0)
        {
            if (list0.Count == 0)
            {
                return this;
            }
            if (!Nodes.ContainsKey(list0[0]) || !(Nodes[list0[0]] is ZzPakNode1))
            {
                ZzPakNode1 @class = new ZzPakNode1(list0[0]);
                list0.RemoveAt(0);
                Nodes.Add(@class);
                return @class.method_3(list0);
            }
            if (list0.Count == 1)
            {
                return (ZzPakNode1) Nodes[list0[0]];
            }
            string key = list0[0];
            list0.RemoveAt(0);
            return ((ZzPakNode1) Nodes[key]).method_3(list0);
        }
    }
}