﻿using BizHawk.Common.BizInvoke;
using BizHawk.Emulation.Cores.Waterbox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BizHawk.Emulation.Cores.Consoles.Sega.PicoDrive
{
	public abstract class LibPicoDrive : LibWaterboxCore
	{
		[StructLayout(LayoutKind.Sequential)]
		public new class FrameInfo : LibWaterboxCore.FrameInfo
		{
			public int Buttons;
		}

		[UnmanagedFunctionPointer(CC)]
		public delegate void CDReadCallback(int lba, IntPtr dest, bool audio);

		[BizImport(CC)]
		public abstract bool Init(bool cd);

		[BizImport(CC)]
		public abstract void SetCDReadCallback(CDReadCallback callback);
	}
}