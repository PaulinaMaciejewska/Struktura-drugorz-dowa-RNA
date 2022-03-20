using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Stems
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (string plik in Directory.GetFiles(Directory.GetCurrentDirectory(), "*.bpseq"))
            {
                string plik2 = plik.Replace(".bpseq", ".stems");
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

                    string ciąg1="";
                    string ciąg2="";
                    
                    for (int j=0; j<bpseq.Count; j++)
                    {
                        int z = j + 1;
                        if (Convert.ToInt32(bpseq[j][0]) < Convert.ToInt32(bpseq[j][2]))
                        {
                            if (j == 0)
                            {
                                ciąg1 = bpseq[j][0] + "-" + bpseq[j][1];
                                ciąg2 = bpseq[Convert.ToInt32(bpseq[j][2]) - 1][0] + "-" + bpseq[Convert.ToInt32(bpseq[j][2]) - 1][1];
                            }
                            if (j != 0)
                            {
                                if (Convert.ToInt32(bpseq[j - 1][2]) != Convert.ToInt32(bpseq[j][2]) + 1)
                                {
                                    ciąg1 = bpseq[j][0] + "-" + bpseq[j][1];
                                    ciąg2 = bpseq[Convert.ToInt32(bpseq[j][2]) - 1][0] + "-" + bpseq[Convert.ToInt32(bpseq[j][2]) - 1][1];
                                }
                            }
                            if(z != bpseq.Count)
                            {
                                if (Convert.ToInt32(bpseq[z][2]) == (Convert.ToInt32(bpseq[j][2]) - 1) && Convert.ToInt32(bpseq[z][0]) == (Convert.ToInt32(bpseq[j][0]) + 1))
                                {
                                    ciąg1 += bpseq[z][1];
                                    ciąg2 += bpseq[Convert.ToInt32(bpseq[z][2]) - 1][1];
                                }
                            }   
                            if (Convert.ToInt32(bpseq[j+1][2]) != Convert.ToInt32(bpseq[j][2])-1)
                            {
                                ciąg1 += "-"+ bpseq[j][0];
                                ciąg2 += "-"+ bpseq[Convert.ToInt32(bpseq[j][2]) - 1][0];
                                Console.WriteLine(ciąg1 + " " + ciąg2);
                                sw.WriteLine(ciąg1 + " " + ciąg2);
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


