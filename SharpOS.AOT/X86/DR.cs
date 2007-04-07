/**
 *  (C) 2006-2007 The SharpOS Project Team - http://www.sharpos.org
 * 
 *  Licensed under the terms of the GNU GPL License version 2.
 * 
 *  Author: Mircea-Cristian Racasan <darx_kies@gmx.net>
 * 
 */

using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using SharpOS.AOT.IR;
using SharpOS.AOT.IR.Instructions;
using SharpOS.AOT.IR.Operands;
using SharpOS.AOT.IR.Operators;
using Mono.Cecil;
using Mono.Cecil.Cil;
using Mono.Cecil.Metadata;

namespace SharpOS.AOT.X86
{
    public class DR
    {
        public static readonly DRType DR0 = new DRType("DR0", 0);
        public static readonly DRType DR1 = new DRType("DR1", 1);
        public static readonly DRType DR2 = new DRType("DR2", 2);
        public static readonly DRType DR3 = new DRType("DR3", 3);
        public static readonly DRType DR4 = new DRType("DR4", 4);
        public static readonly DRType DR6 = new DRType("DR6", 6);
        public static readonly DRType DR7 = new DRType("DR7", 7);

        public static DRType GetByID(object value)
        {
            if (value is DRType == true)
            {
                return value as DRType;
            }

            if (value is SharpOS.AOT.IR.Operands.Field == false)
            {
                throw new Exception("'" + value.ToString() + "' is not supported.");
            }

            string id = (value as SharpOS.AOT.IR.Operands.Field).Value.ToString();

            if (id.Equals("null") == true)
            {
                return null;
            }

            switch (id.Substring(id.Length - 3))
            {
                case "DR0":
                    return DR.DR0;
                case "DR1":
                    return DR.DR1;
                case "DR2":
                    return DR.DR2;
                case "DR3":
                    return DR.DR3;
                case "DR4":
                    return DR.DR4;
                case "DR6":
                    return DR.DR6;
                case "DR7":
                    return DR.DR7;
                default:
                    throw new Exception("Unknown DR Register '" + id + "'");
            }
        }
    }
}