using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace check1
{
    public abstract class Command
    {
        private int x; private int y;

        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }

        public abstract int Execute();
    }

    public class AsmMov : Command
    {
        public AsmMov(int _x, int _y)
        {
            this.X = _y;
        }

        public override int Execute()
        {
            return this.X;
        }
    }

    public class AsmInc : Command
    {
        public AsmInc(int _x)
        {
            this.X = _x;
        }

        public override int Execute()
        {
            //Type t = this.X.GetType();

            //PropertyInfo prop = t.GetProperty("X");

            //object x = prop.GetValue(X);

            return this.X + 1;
        }
    }

    public class AsmDec : Command
    {
        public AsmDec(int _x)
        {
            this.X = _x;
        }

        public override int Execute()
        {
            return this.X - 1;
        }
    }

    public class AsmJnz : Command
    {
        public AsmJnz(int _x)
        {
            this.X = _x;
        }

        public override int Execute()
        {
            return this.X;
        }
    }


    public class Task
    {
        public string command;
        public string ch;
        public int? data;
        public string dataM;

        public Task(string item)
        {
            var splitted = item.Split(" ");
            command = splitted[0];
            ch = splitted[1];

            if (splitted.Length > 2)
            {
                if (int.TryParse(splitted[2], out int data))
                {
                    this.data = data;
                }
                else
                {
                    this.dataM = splitted[2];
                    this.data = null;
                }
            }
            else data = null;
        }
    }

    public class Prog
    {
        public List<Task> taskList;
        public Prog(string[] _prog)
        {
            taskList = new List<Task>();

            foreach (var item in _prog)
            {
                taskList.Add(new Task(item));
            }
        }
    }

    public class Assembler
    {
        private static string[] str = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        public Dictionary<string, int> keys;
        public Assembler(string[] program)
        {
            var pr = new Prog(program);
            keys = new Dictionary<string, int>();

            //foreach (var item in pr.taskList.Select(key => key.ch).Distinct())
            //{
            //    if (!str.Contains(item))
            //    keys.Add(item.ToString(), 0);
            //}

            var curCh = ""; var x = 0;
            for (int i = 0; i < pr.taskList.Count; i++)
            {
                curCh = pr.taskList[i].ch;

                if (!str.Contains(curCh))
                {
                    keys.TryAdd(curCh, x);
                }
                
                keys.TryGetValue(curCh, out x);

                switch (pr.taskList[i].command)
                {
                    case "mov":
                        {
                            AsmMov mov = new AsmMov(x, pr.taskList[i].data ?? keys[pr.taskList[i].dataM]);
                            x = mov.Execute();
                            break;
                        }
                    case "inc":
                        {
                            AsmInc inc = new AsmInc(x);
                            x = inc.Execute();
                            break;
                        }
                    case "dec":
                        {
                            AsmDec dec = new AsmDec(x);
                            x = dec.Execute();
                            break;
                        }
                    case "jnz":
                        {
                            int tmp = 0;
                            if (str.Contains(pr.taskList[i].ch))
                            {
                                tmp = pr.taskList[i].data.Value;
                            }
                            else
                            {
                                AsmJnz jnz = new AsmJnz(pr.taskList[i].data ?? keys[pr.taskList[i].dataM]);
                                tmp = jnz.Execute();
                            }
                            
                            if (x != 0 || str.Contains(pr.taskList[i].ch))
                            {
                                if (tmp > 0)
                                { 
                                    i += tmp - 1; 
                                }
                                else
                                {
                                    i -= Math.Abs(tmp) + 1;
                                }
                            }
                            break;
                        }
                }
                if (!str.Contains(curCh))
                {
                    keys[curCh] = x;
                }
            }
        }

    }

    public static class CodeWars_AssemblerInterpriter
    {
        public static Dictionary<string, int> Interpret(string[] prog)
        {
            return new Assembler(prog).keys;
        }
    }



}
