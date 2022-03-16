using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Hairpins
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (string plik in Directory.GetFiles(Directory.GetCurrentDirectory(), "*.bpseq"))
            {
                List<string> hairpins = new List<string>();
                string plik2 = plik.Replace(".bpseq", ".hairpins");
                string wynik = plik2;
                FileStream fi = new FileStream(wynik, FileMode.Create, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fi);

                FileStream fs = new FileStream(plik, FileMode.Open, FileAccess.Read);
                using (StreamReader sr = new StreamReader(fs))
                {
                    string[] line = File.ReadAllLines(plik);
                    List<List<string>> bpseq = new List<List<string>>();
                    for(int i=0;i<line.Length; i++)
                    {
                        string[] linia2 = line[i].ToString().Split(" ");
                        List<string> linia = new List<string>();
                        for(int j=0; j<linia2.Length; j++)
                        {
                            linia.Add(linia2[j]);
                        }
                        bpseq.Add(linia);
                    }

                    for (int i = 0; i < bpseq.Count; i++)
                    {
                        if (Convert.ToInt32(bpseq[i][0]) < Convert.ToInt32(bpseq[i][2]))
                        {
                            int counter = 0;
                            string ciąg = "";
                            for (int k = Convert.ToInt32(bpseq[i][0]); k < Convert.ToInt32(bpseq[i][2]); k++)
                            {
                                if (bpseq[k][2] == "0")
                                {
                                    ciąg += bpseq[k][1];
                                    counter++;
                                }
                            }
                            if (counter == Convert.ToInt32(bpseq[i][2]) - 1 - Convert.ToInt32(bpseq[i][0]))
                            {
                                Console.WriteLine(bpseq[i][0] + "-" + bpseq[i][1] + ciąg + bpseq[Convert.ToInt32(bpseq[i][2])-1][1] + "-" + bpseq[Convert.ToInt32(bpseq[i][2])-1][0]);
                                sw.WriteLine(bpseq[i][0] + "-" + bpseq[i][1] + ciąg + bpseq[Convert.ToInt32(bpseq[i][2]) - 1][1] + "-" + bpseq[Convert.ToInt32(bpseq[i][2]) - 1][0]);
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


