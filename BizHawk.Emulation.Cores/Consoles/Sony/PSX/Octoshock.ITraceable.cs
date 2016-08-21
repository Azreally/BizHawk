﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BizHawk.Emulation.Common;
using BizHawk.Common.NumberExtensions;

namespace BizHawk.Emulation.Cores.Sony.PSX
{
	public partial class Octoshock
	{
		public ITraceable Tracer { get { return tracer; } }

		public static string TraceHeader = "R3000A: PC, raw bytes, mnemonic, registers (GPRs, lo, hi, sr, cause, epc)";

		public void ShockTraceCallback(IntPtr opaque, uint PC, uint inst, string dis)
		{
			var regs = GetCpuFlagsAndRegisters();
			StringBuilder sb = new StringBuilder();

			foreach (var r in regs)
			{
				if (r.Key != "pc")
					sb.Append(
						string.Format("{0}:{1} ",
						r.Key,
						r.Value.Value.ToHexString(r.Value.BitSize / 4)));
			}

            Tracer.Put(new TraceInfo
			{
				Disassembly = string.Format("{0:X8}:  {1:X8}  {2}", PC, inst, dis.PadRight(20)),
				RegisterInfo = sb.ToString().Trim()
			});
		}
	}
}
