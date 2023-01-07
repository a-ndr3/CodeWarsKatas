using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace check1
{
    internal class CodeWars_SmallFuInterp
    {
        public abstract class Commands
        {
            public abstract void CommandArrowRight();
            public abstract void CommandArrowLeft();
            public abstract void CommandFlipTheBit();
            public abstract void CommandJumpPast();
            public abstract void CommandJumpBack();
        }
        public class SmallF
        {
            private string Code;
            private string Tape;
            public SmallF(string code, string tape)
            {
                this.Code = code;
                this.Tape = tape;
            }




        }
        public static string Interpreter(string code, string tape)
        {
            return null;
        }
    }
}
