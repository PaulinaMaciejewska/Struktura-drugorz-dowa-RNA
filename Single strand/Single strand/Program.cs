using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Single_Strand
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (string plik in Directory.GetFiles(Directory.GetCurrentDirectory(), "*.bpseq"))
            {
                string plik2 = plik.Replace(".bpseq", ".strands");
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

                    string ciąg = "";
                    string pierwszy = "";
                    string ostatni = "";
                    for (int j = 0; j < bpseq.Count; j++)
                    {
                        int z = j + 1;
                        if (j == 0)
                        {
                            if (bpseq[j][2] == "0" || bpseq[z][2] == "0")
                            {
                                ciąg = bpseq[j][0] + "-" + bpseq[j][1];
                                pierwszy = bpseq[j][0];
                            }
                        }
                        if (j != 0)
                        {
                            if (z != bpseq.Count)
                            {
                                if (bpseq[j][2] != "0" && bpseq[j - 1][2] != "0" && bpseq[j + 1][2] == "0")
                                {
                                    ciąg = bpseq[j][0] + "-" + bpseq[j][1];
                                    pierwszy = bpseq[j][0];
                                }
                                if (bpseq[j][2] == "0")
                                {
                                    ciąg += bpseq[j][1];
                                    ostatni = bpseq[j][2];
                                }
                                if (bpseq[j][2] != "0" && bpseq[j - 1][2] == "0")
                                {
                                    ciąg += bpseq[j][1];
                                    ostatni = bpseq[j][2];

                                    if (bpseq[j][2] != "0" && pierwszy != ostatni)
                                    {
                                        if (bpseq[j - 1][2] == "0" && bpseq[j + 1][2] == "0")
                                        {
                                            ciąg += "-" + bpseq[j][0];
                                            Console.WriteLine(ciąg);
                                            sw.WriteLine(ciąg);
                                            ciąg = bpseq[j][0] + "-" + bpseq[j][1];
                                        }
                                        else
                                        {
                                            ciąg += "-" + bpseq[j][0];
                                            Console.WriteLine(ciąg);
                                            sw.WriteLine(ciąg);
                                        }
                                    }
                                }
                            }
                            else
                            {
                                if (bpseq[j][2] == "0")
                                {
                                    ciąg += bpseq[j][1] + "-" + bpseq[j][0];
                                    Console.WriteLine(ciąg);
                                    sw.WriteLine(ciąg);
                                }
                            }
                        }
                    }
                }
                sw.Close();
                fs.Close();
            }
        }
    }
}
