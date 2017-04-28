using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using ns14;
using ns18;

namespace ns16
{
	public class ZzListBox238 : ListBox, INterface11
	{
		private Rectangle _rectangle0 = Rectangle.Empty;

		private readonly ZzDrawingClass230 _class2300;

		private int[] _int0 = new int[0];

		private bool _bool0;

		private string _string0 = "";

		private bool _bool1 = true;

		private bool _bool2 = true;

		private bool _bool3 = true;

		private bool _bool4 = true;

		private EventHandler<EventArgs2> _eventHandler0;

		public ZzListBox238()
		{
			AllowDrop = true;
			_class2300 = new ZzDrawingClass230(this);
		}

		public string imethod_0()
		{
			return _string0;
		}

		public void method_0(string string1)
		{
			_string0 = string1;
		}

		public bool imethod_1()
		{
			return _bool1;
		}

		public void method_1(bool bool5)
		{
			_bool1 = bool5;
		}

		public bool imethod_2()
		{
			return _bool2;
		}

		public void method_2(bool bool5)
		{
			_bool2 = bool5;
		}

		public object[] imethod_3()
		{
			var array = new object[SelectedItems.Count];
			SelectedItems.CopyTo(array, 0);
			return array;
		}

		public void method_3()
		{
			for (var i = SelectedIndices.Count - 1; i >= 0; i--)
			{
				var index = SelectedIndices[i];
				Items.RemoveAt(index);
			}
		}

		public void imethod_4(ref int int1)
		{
			for (var i = SelectedIndices.Count - 1; i >= 0; i--)
			{
				var num = SelectedIndices[i];
				Items.RemoveAt(num);
				if (num < int1)
				{
					int1--;
				}
			}
		}

		public void imethod_5(EventArgs2 eventArgs20)
		{
			var eventHandler = _eventHandler0;
			if (eventHandler != null)
			{
				eventHandler(this, eventArgs20);
			}
		}

		public void method_4(bool bool5)
		{
			_bool3 = bool5;
			AllowDrop = (_bool4 || _bool3);
		}

		public void method_5(bool bool5)
		{
			_bool4 = bool5;
			AllowDrop = (_bool4 || _bool3);
		}

		public void method_6(EventHandler<EventArgs2> eventHandler1)
		{
			var eventHandler = _eventHandler0;
			EventHandler<EventArgs2> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				var value = (EventHandler<EventArgs2>)Delegate.Combine(eventHandler2, eventHandler1);
				eventHandler = Interlocked.CompareExchange(ref _eventHandler0, value, eventHandler2);
			}
			while (eventHandler != eventHandler2);
		}

        protected override void OnDragDrop(DragEventArgs drgevent)
		{
			base.OnDragDrop(drgevent);
			_class2300.method_1();
			var @interface = drgevent.Data.GetData("IDragDropSource") as INterface11;
			var array = @interface.imethod_3();
			var sorted = Sorted;
			Sorted = false;
			var num = method_9(drgevent.Y);
			var num2 = num;
			if (num >= Items.Count)
			{
				Items.AddRange(array);
			}
			else
			{
				var array2 = array;
				for (var i = 0; i < array2.Length; i++)
				{
					var item = array2[i];
					Items.Insert(num++, item);
				}
			}
			Enum34 @enum;
			if (drgevent.Effect == DragDropEffects.Move)
			{
				var num3 = num2;
				@interface.imethod_4(ref num3);
				if (@interface == this)
				{
					num2 = num3;
					@enum = Enum34.Const0;
				}
				else
				{
					@enum = Enum34.Const1;
				}
			}
			else
			{
				@enum = Enum34.Const2;
			}
			ClearSelected();
			if (SelectionMode == SelectionMode.One)
			{
				SelectedIndex = num2;
			}
			else if (SelectionMode != SelectionMode.None)
			{
				for (var j = num2; j < num2 + array.Length; j++)
				{
					SetSelected(j, true);
				}
			}
			Sorted = sorted;
			imethod_5(new EventArgs2
			{
				Enum340 = @enum,
				Interface110 = @interface,
				Interface111 = this,
				Object0 = array
			});
			if (@enum != Enum34.Const0)
			{
				@interface.imethod_5(new EventArgs2
				{
					Enum340 = (@enum == Enum34.Const1) ? Enum34.Const3 : Enum34.Const4,
					Interface110 = @interface,
					Interface111 = this,
					Object0 = array
				});
			}
		}

        protected override void OnDragOver(DragEventArgs drgevent)
		{
			base.OnDragOver(drgevent);
			drgevent.Effect = method_10(drgevent);
			if (drgevent.Effect == DragDropEffects.None)
			{
				return;
			}
			var num = method_9(drgevent.Y);
			if (num != _class2300.method_0())
			{
				_class2300.method_1();
				_class2300.method_2(num);
			}
		}

        protected override void OnDragEnter(DragEventArgs drgevent)
		{
			base.OnDragEnter(drgevent);
			drgevent.Effect = method_10(drgevent);
		}

        protected override void OnDragLeave(EventArgs e)
		{
			base.OnDragLeave(e);
			_class2300.method_1();
		}

        protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			var num = IndexFromPoint(e.Location);
			if (num >= 0 && MouseButtons == MouseButtons.Left && (_bool1 || _bool2 || _bool3) && (GetSelected(num) || ModifierKeys == Keys.Shift))
			{
				method_7(num);
				var dragSize = SystemInformation.DragSize;
				_rectangle0 = new Rectangle(new Point(e.X - dragSize.Width / 2, e.Y - dragSize.Height / 2), dragSize);
			}
		}

        protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);
			_rectangle0 = Rectangle.Empty;
		}

        protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);
			if (_rectangle0 != Rectangle.Empty && !_rectangle0.Contains(e.X, e.Y))
			{
				DoDragDrop(new DataObject("IDragDropSource", this), DragDropEffects.All);
				_rectangle0 = Rectangle.Empty;
			}
		}

        protected override void OnSelectedIndexChanged(EventArgs e)
		{
			base.OnSelectedIndexChanged(e);
			method_8();
		}

		private void method_7(int int1)
		{
			if (SelectionMode == SelectionMode.MultiExtended && ModifierKeys == Keys.None && Array.IndexOf(_int0, int1) >= 0)
			{
				_bool0 = true;
				var array = _int0;
				for (var i = 0; i < array.Length; i++)
				{
					var index = array[i];
					SetSelected(index, true);
				}
				SetSelected(int1, true);
				_bool0 = false;
			}
		}

		private void method_8()
		{
			if (!_bool0 && SelectionMode == SelectionMode.MultiExtended)
			{
				var selectedIndices = SelectedIndices;
				if (_int0.Length != selectedIndices.Count)
				{
					_int0 = new int[selectedIndices.Count];
				}
				SelectedIndices.CopyTo(_int0, 0);
			}
		}

		private int method_9(int int1)
		{
			var num = PointToClient(new Point(0, int1)).Y;
			if (num < 0)
			{
				num = 0;
			}
			else if (num > ClientRectangle.Bottom - 1)
			{
				num = ClientRectangle.Bottom - 1;
			}
			var num2 = IndexFromPoint(0, num);
			if (num2 == -1)
			{
				return Items.Count;
			}
			var itemRectangle = GetItemRectangle(num2);
			if (num > itemRectangle.Top + itemRectangle.Height / 2)
			{
				num2++;
			}
			var num3 = TopIndex + ClientRectangle.Height / ItemHeight;
			if (num2 > num3)
			{
				return num3;
			}
			return num2;
		}

		private DragDropEffects method_10(DragEventArgs dragEventArgs0)
		{
			var result = DragDropEffects.None;
			var @interface = dragEventArgs0.Data.GetData("IDragDropSource") as INterface11;
			if (@interface != null && _string0 == @interface.imethod_0())
			{
				if (@interface == this)
				{
					if (_bool3 && !Sorted)
					{
						result = DragDropEffects.Move;
					}
				}
				else if (_bool4)
				{
					if (@interface.imethod_1() && (!@interface.imethod_2() || dragEventArgs0.KeyState == 9))
					{
						result = DragDropEffects.Copy;
					}
					else if (@interface.imethod_2())
					{
						result = DragDropEffects.Move;
					}
				}
			}
			return result;
		}
	}
}
