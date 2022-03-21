using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace FCFS
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (string plik in Directory.GetFiles(Directory.GetCurrentDirectory(), "*.bpseq"))
            {
                string plik2 = plik.Replace(".bpseq", ".dbn");
                string wynik = plik2;
                FileStream fi = new FileStream(wynik, FileMode.Create, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fi);

                FileStream fs = new FileStream(plik, FileMode.Open, FileAccess.Read);
                using (StreamReader sr = new StreamReader(fs))
                {
                    string[] line = File.ReadAllLines(plik);
                    List<List<string>> bpseq = new List<List<string>>();
                    for (int i = 0; i < line.Length; i++)
                    {
                        string[] linia2 = line[i].ToString().Split(" ");
                        List<string> linia = new List<string>();
                        for (int k = 0; k < linia2.Length; k++)
                        {
                            linia.Add(linia2[k]);
                        }
                        bpseq.Add(linia);
                    }
                    List<string> stem1 = new List<string>();
                    List<List<string>> stemy = new List<List<string>>();
                    List<string> niesparowane = new List<string>();
                    int Counter = 0;
                    for (int j = 0; j < bpseq.Count; j++)
                    {
                        int z = j + 1;
                        if (bpseq[j][2] == "0")
                        {
                            niesparowane.Add(bpseq[j][0]);
                        }
                        if (bpseq[j][2] != "0" && Convert.ToInt32(bpseq[j][0]) < Convert.ToInt32(bpseq[j][2]))
                        {
                            if (j == 0)
                            {
                                stem1.Clear();
                                stem1.Add(bpseq[j][0]);
                                stem1.Add(bpseq[j][2]);
                                Counter++;
                                if (bpseq[j + 1][2] == "0")
                                {
                                    stem1.Add(Counter.ToString());
                                    List<string> stem2 = new List<string>(stem1);
                                    stemy.Add(stem2);
                                    Counter = 0;
                                }
                            }
                            else
                            {
                                if (z != bpseq.Count)
                                {
                                    if (Convert.ToInt32(bpseq[j][2]) != Convert.ToInt32(bpseq[j - 1][2]) - 1)
                                    {
                                        stem1.Clear();
                                        stem1.Add(bpseq[j][0]);
                                        stem1.Add(bpseq[j][2]);
                                        Counter++;

                                        if (Convert.ToInt32(bpseq[j][2]) != Convert.ToInt32(bpseq[j + 1][2]) + 1)
                                        {
                                            stem1.Add(Counter.ToString());
                                            List<string> stem2 = new List<string>(stem1);
                                            stemy.Add(stem2);
                                            Counter = 0;
                                        }
                                    }
                                    if (Convert.ToInt32(bpseq[j][2]) == (Convert.ToInt32(bpseq[j - 1][2]) - 1))
                                    {
                                        Counter++;
                                        if (Convert.ToInt32(bpseq[j][2]) != Convert.ToInt32(bpseq[j + 1][2]) + 1)
                                        {
                                            stem1.Add(Counter.ToString());
                                            List<string> stem2 = new List<string>(stem1);
                                            stemy.Add(stem2);
                                            Counter = 0;
                                        }
                                    }
                                }
                            }
                        }
                    }


                    List<int> order = new List<int>();
                    int order1 = 0;
                    for (int i = 0; i < stemy.Count; i++)
                    {
                        if (i == 0)
                        {
                            order.Add(0);
                        }
                        else
                        {
                            for (int j = 0; j < i; j++)
                            {
                                if (Convert.ToInt32(stemy[i][0]) > Convert.ToInt32(stemy[j][0]) && Convert.ToInt32(stemy[i][1]) < Convert.ToInt32(stemy[j][1])
                                    || Convert.ToInt32(stemy[i][0]) > Convert.ToInt32(stemy[j][1])
                                    || Convert.ToInt32(stemy[i][0]) < Convert.ToInt32(stemy[j][0]) && Convert.ToInt32(stemy[i][1]) > Convert.ToInt32(stemy[j][1]))
                                {
                                    order1 = order1;
                                }
                                else
                                {
                                    if (order1 == order[j])
                                    {
                                        order1 = order[j] + 1;
                                    }
                                }
                            }
                            order.Add(order1);
                            order1 = 0;
                        }
                    }
                    string dot_bracket = "";
                    string sekwencja = "";

                    for (int i = 0; i < bpseq.Count; i++)
                    {
                        sekwencja += bpseq[i][1];
                        if (niesparowane.Contains(bpseq[i][0]))
                        {
                            dot_bracket += ".";
                        }
                        if (Convert.ToInt32(bpseq[i][0]) < Convert.ToInt32(bpseq[i][2]))
                        {
                            for (int j = 0; j < stemy.Count; j++)
                            {
                                if (bpseq[i][0] == stemy[j][0])
                                {
                                    int counter = 0;
                                    if (order[j] == 0)
                                    {
                                        while (counter < Convert.ToInt32(stemy[j][2]))
                                        {
                                            dot_bracket += "(";
                                            counter++;
                                        }
                                        break;
                                    }
                                    if (order[j] == 1)
                                    {
                                        while (counter < Convert.ToInt32(stemy[j][2]))
                                        {
                                            dot_bracket += "[";
                                            counter++;
                                        }
                                        break;
                                    }
                                    if (order[j] == 2)
                                    {
                                        while (counter < Convert.ToInt32(stemy[j][2]))
                                        {
                                            dot_bracket += "{";
                                            counter++;
                                        }
                                        break;
                                    }
                                    if (order[j] == 3)
                                    {
                                        while (counter < Convert.ToInt32(stemy[j][2]))
                                        {
                                            dot_bracket += "A";
                                            counter++;
                                        }
                                        break;
                                    }
                                }
                            }
                        }
                        else
                        {
                            for (int j = 0; j < stemy.Count; j++)
                            {
                                if (bpseq[i][0] == stemy[j][1])
                                {
                                    int counter = 0;
                                    if (order[j] == 0)
                                    {
                                        while (counter < Convert.ToInt32(stemy[j][2]))
                                        {
                                            dot_bracket += ")";
                                            counter++;
                                        }
                                        break;
                                    }
                                    if (order[j] == 1)
                                    {
                                        while (counter < Convert.ToInt32(stemy[j][2]))
                                        {
                                            dot_bracket += "]";
                                            counter++;
                                        }
                                        break;
                                    }
                                    if (order[j] == 2)
                                    {
                                        while (counter < Convert.ToInt32(stemy[j][2]))
                                        {
                                            dot_bracket += "}";
                                            counter++;
                                        }
                                        break;
                                    }
                                    if (order[j] == 3)
                                    {
                                        while (counter < Convert.ToInt32(stemy[j][2]))
                                        {
                                            dot_bracket += "a";
                                            counter++;
                                        }
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    Console.WriteLine(sekwencja);
                    Console.WriteLine(dot_bracket);

                    sw.WriteLine(sekwencja);
                    sw.WriteLine(dot_bracket);

                    sw.Close();
                    fs.Close();
                }
            }
        }
    }
}
