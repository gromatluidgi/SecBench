﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SecBench.Domain.Entities.Violations
{
    public class CodePosition
    {
        public CodePosition(int line, int column)
        {
            Line = line;
            Column = column;
        }

        public int Line { get; set; }
        public int Column { get; set; }


    }
}
