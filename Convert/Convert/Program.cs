using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Convert
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (string plik in Directory.GetFiles(Directory.GetCurrentDirectory(), "*.dbn"))
            {
                string plik2 = plik.Replace(".dbn", ".bpseq");
                string wynik = plik2;
                FileStream fi = new FileStream(wynik, FileMode.Create, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fi);

                FileStream fs = new FileStream(plik, FileMode.Open, FileAccess.Read);
                using (StreamReader sr = new StreamReader(fs))
                {
                    string[] line = File.ReadAllLines(plik);

                    string[] nukleotydy = new string[line[0].Length];
                    string[] znaki = new string[line[1].Length];

                    int indeks = 0;
                    foreach (var znak in line[0])
                    {
                        nukleotydy[indeks] = znak.ToString();
                        indeks++;
                    }
                    int ind = 0;
                    foreach (var znak in line[1])
                    {
                        znaki[ind] = znak.ToString();
                        ind++;
                    }
                    List<int> znak1 = new List<int>(); // (
                    List<int> znak2 = new List<int>(); // [
                    List<int> znak3 = new List<int>(); // {
                    List<int> znak4 = new List<int>(); // <
                    List<int> znak5 = new List<int>(); // )
                    List<int> znak6 = new List<int>(); // ]
                    List<int> znak7 = new List<int>(); // }
                    List<int> znak8 = new List<int>(); // >
                    List<int> znak9 = new List<int>(); // A
                    List<int> znak10 = new List<int>(); // a
                    int size = nukleotydy.Length + 2;
                    List<List<int>> pary = new List<List<int>>();
                    int nr = 1;
                    for (int i = 0; i < nukleotydy.Length; i++)
                    {
                        if (znaki[i] == "(")
                        {
                            znak1.Add(i + 1);
                        }
                        if (znaki[i] == "[")
                        {
                            znak2.Add(i + 1);

                        }
                        if (znaki[i] == "{")
                        {
                            znak3.Add(i + 1);
                        }
                        if (znaki[i] == "<")
                        {
                            znak4.Add(i + 1);
                        }
                        if (znaki[i] == ")")
                        {
                            znak5.Add(i + 1);
                        }
                        if (znaki[i] == "]")
                        {
                            znak6.Add(i + 1);
                        }
                        if (znaki[i] == "}")
                        {
                            znak7.Add(i + 1);
                        }
                        if (znaki[i] == ">")
                        {
                            znak8.Add(i + 1);
                        }
                        if (znaki[i] == "A")
                        {
                            znak9.Add(i + 1);
                        }
                        if (znaki[i] == "a")
                        {
                            znak10.Add(i + 1);
                        }

                    }
                    for (int i = 0; i < nukleotydy.Length; i++)
                    {
                        if (znaki[i] == "(")
                        {
                            for (int j = 0; j < znak5.Count; j++)
                            {
                                if (znak1.Count > 1)
                                {
                                    if (znak5[j] > znak1[znak1.Count - 1])
                                    {
                                        List<int> para = new List<int>();
                                        para.Add(znak5[j]);
                                        para.Add(znak1[znak1.Count - 1]);
                                        pary.Add(para);
                                        znak5.RemoveAt(j);
                                        znak1.RemoveAt(znak1.Count - 1);
                                        break;
                                    }
                                }
                                else
                                {
                                    if (znak5[j] > znak1[0])
                                    {
                                        List<int> para = new List<int>();
                                        para.Add(znak5[j]);
                                        para.Add(znak1[0]);
                                        pary.Add(para);
                                        znak5.RemoveAt(j);
                                        znak1.RemoveAt(0);
                                        break;
                                    }
                                }
                            }
                        }
                        if (znaki[i] == "[")
                        {
                            for (int j = 0; j < znak6.Count; j++)
                            {
                                if (znak2.Count > 1)
                                {
                                    if (znak6[j] > znak2[znak2.Count - 1])
                                    {
                                        List<int> para = new List<int>();
                                        para.Add(znak6[j]);
                                        para.Add(znak2[znak2.Count - 1]);
                                        pary.Add(para);
                                        znak6.RemoveAt(j);
                                        znak2.RemoveAt(znak2.Count - 1);
                                        break;
                                    }
                                }
                                else
                                {
                                    if (znak6[j] > znak2[0])
                                    {
                                        List<int> para = new List<int>();
                                        para.Add(znak6[j]);
                                        para.Add(znak2[0]);
                                        pary.Add(para);
                                        znak6.RemoveAt(j);
                                        znak2.RemoveAt(0);
                                        break;
                                    }
                                }

                            }
                        }
                        if (znaki[i] == "{")
                        {
                            for (int j = 0; j < znak7.Count; j++)
                            {
                                if (znak3.Count > 1)
                                {
                                    if (znak7[j] > znak3[znak3.Count - 1])
                                    {
                                        List<int> para = new List<int>();
                                        para.Add(znak7[j]);
                                        para.Add(znak3[znak3.Count - 1]);
                                        pary.Add(para);
                                        znak7.RemoveAt(j);
                                        znak3.RemoveAt(znak3.Count - 1);

                                        break;
                                    }
                                }
                                else
                                {
                                    if (znak7[j] > znak3[0])
                                    {
                                        List<int> para = new List<int>();
                                        para.Add(znak7[j]);
                                        para.Add(znak3[0]);
                                        pary.Add(para);
                                        znak7.RemoveAt(j);
                                        znak3.RemoveAt(0);

                                        break;
                                    }
                                }

                            }
                        }
                        if (znaki[i] == "<")
                        {
                            for (int j = 0; j < znak8.Count; j++)
                            {
                                if (znak4.Count > 1)
                                {
                                    if (znak8[j] > znak4[znak4.Count - 1])
                                    {
                                        List<int> para = new List<int>();
                                        para.Add(znak8[j]);
                                        para.Add(znak4[znak4.Count - 1]);
                                        pary.Add(para);
                                        znak8.RemoveAt(j);
                                        znak4.RemoveAt(znak4.Count - 1);

                                        break;
                                    }
                                }
                                else
                                {
                                    if (znak8[j] > znak4[0])
                                    {
                                        List<int> para = new List<int>();
                                        para.Add(znak8[j]);
                                        para.Add(znak4[0]);
                                        pary.Add(para);
                                        znak8.RemoveAt(j);
                                        znak4.RemoveAt(0);

                                        break;
                                    }
                                }

                            }
                        }
                        if (znaki[i] == "A")
                        {
                            for (int j = 0; j < znak10.Count; j++)
                            {
                                if (znak9.Count > 1)
                                {
                                    if (znak10[j] > znak9[znak9.Count - 1])
                                    {
                                        List<int> para = new List<int>();
                                        para.Add(znak10[j]);
                                        para.Add(znak9[znak9.Count - 1]);
                                        pary.Add(para);
                                        znak10.RemoveAt(j);
                                        znak9.RemoveAt(znak9.Count - 1);

                                        break;
                                    }
                                }
                                else
                                {
                                    if (znak10[j] > znak9[0])
                                    {
                                        List<int> para = new List<int>();
                                        para.Add(znak10[j]);
                                        para.Add(znak9[0]);
                                        pary.Add(para);
                                        znak10.RemoveAt(j);
                                        znak9.RemoveAt(0);

                                        break;
                                    }
                                }
                            }
                        }
                    }

                    for (int i = 0; i < nukleotydy.Length; i++)
                    {
                        if (znaki[i] == ".")
                        {
                            sw.WriteLine((nr).ToString() + " " + nukleotydy[i] + " 0");
                            nr++;
                        }
                        if (znaki[i] == "(")
                        {
                            for (int k = 0; k < pary.Count; k++)
                            {
                                for (int m = 0; m < pary[k].Count; m++)
                                {
                                    if (pary[k][m] == i + 1)
                                    {
                                        sw.WriteLine((nr).ToString() + " " + nukleotydy[i] + " " + pary[k][0].ToString());
                                        nr++;
                                    }
                                }
                            }
                        }
                        if (znaki[i] == "[")
                        {
                            for (int k = 0; k < pary.Count; k++)
                            {
                                for (int m = 0; m < pary[k].Count; m++)
                                {
                                    if (pary[k][m] == i + 1)
                                    {
                                        sw.WriteLine((nr).ToString() + " " + nukleotydy[i] + " " + pary[k][0].ToString());
                                        nr++;
                                    }
                                }
                            }
                        }
                        if (znaki[i] == "{")
                        {
                            for (int k = 0; k < pary.Count; k++)
                            {
                                for (int m = 0; m < pary[k].Count; m++)
                                {
                                    if (pary[k][m] == i + 1)
                                    {
                                        sw.WriteLine((nr).ToString() + " " + nukleotydy[i] + " " + pary[k][0].ToString());
                                        nr++;
                                    }
                                }
                            }
                        }
                        if (znaki[i] == "<")
                        {
                            for (int k = 0; k < pary.Count; k++)
                            {
                                for (int m = 0; m < pary[k].Count; m++)
                                {
                                    if (pary[k][m] == i + 1)
                                    {
                                        sw.WriteLine((nr).ToString() + " " + nukleotydy[i] + " " + pary[k][0].ToString());
                                        nr++;
                                    }
                                }
                            }
                        }
                        if (znaki[i] == "A")
                        {
                            for (int k = 0; k < pary.Count; k++)
                            {
                                for (int m = 0; m < pary[k].Count; m++)
                                {
                                    if (pary[k][m] == i + 1)
                                    {
                                        sw.WriteLine((nr).ToString() + " " + nukleotydy[i] + " " + pary[k][0].ToString());
                                        nr++;
                                    }
                                }
                            }
                        }
                        if (znaki[i] == ")")
                        {
                            for (int k = 0; k < pary.Count; k++)
                            {
                                for (int m = 0; m < pary[k].Count; m++)
                                {
                                    if (pary[k][m] == i + 1)
                                    {
                                        sw.WriteLine((nr).ToString() + " " + nukleotydy[i] + " " + pary[k][1].ToString());
                                        nr++;
                                    }
                                }
                            }
                        }
                        if (znaki[i] == "]")
                        {
                            for (int k = 0; k < pary.Count; k++)
                            {
                                for (int m = 0; m < pary[k].Count; m++)
                                {
                                    if (pary[k][m] == i + 1)
                                    {
                                        sw.WriteLine((nr).ToString() + " " + nukleotydy[i] + " " + pary[k][1].ToString());
                                        nr++;
                                    }
                                }
                            }
                        }
                        if (znaki[i] == "}")
                        {
                            for (int k = 0; k < pary.Count; k++)
                            {
                                for (int m = 0; m < pary[k].Count; m++)
                                {
                                    if (pary[k][m] == i + 1)
                                    {
                                        sw.WriteLine((nr).ToString() + " " + nukleotydy[i] + " " + pary[k][1].ToString());
                                        nr++;
                                    }
                                }
                            }
                        }
                        if (znaki[i] == ">")
                        {
                            for (int k = 0; k < pary.Count; k++)
                            {
                                for (int m = 0; m < pary[k].Count; m++)
                                {
                                    if (pary[k][m] == i + 1)
                                    {
                                        sw.WriteLine((nr).ToString() + " " + nukleotydy[i] + " " + pary[k][1].ToString());
                                        nr++;
                                    }
                                }
                            }
                        }
                        if (znaki[i] == "a")
                        {
                            for (int k = 0; k < pary.Count; k++)
                            {
                                for (int m = 0; m < pary[k].Count; m++)
                                {
                                    if (pary[k][m] == i + 1)
                                    {
                                        sw.WriteLine((nr).ToString() + " " + nukleotydy[i] + " " + pary[k][1].ToString());
                                        nr++;
                                    }
                                }
                            }
                        }
                    }
                }
                sw.Close();
                fi.Close();
            }
        }
    }
}


