using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataMiningAprioriAlgorithm
{
    public partial class Form1 : Form
    {
        static Dictionary<string, long> dataholder = new Dictionary<string, long>();
        static Dictionary<string, long> dataholder2 = new Dictionary<string, long>();
        static Dictionary<string, long> dataholder3 = new Dictionary<string, long>();
        static Dictionary<string, long> Confidence = new Dictionary<string, long>();
        static Dictionary<string, long> dataholder4 = new Dictionary<string, long>();

        static List<String> linebylinecapture = new List<string>();
        static Dictionary<string, long> itemset1 = new Dictionary<string, long>();
        static int countdata;

        static String dbselection;
        static int support, confidence;
        public Form1(String dbselect, int sup, int confi)
        {
            dbselection = dbselect;
            support = sup;
            confidence = confi;

            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                long occurrances = 1;
                label7.Text = support.ToString() + "%";
                label8.Text = confidence.ToString() + "%";


                listView1.AutoArrange = false;
                foreach (string data in File.ReadAllLines("c:\\users\\soory_000\\documents\\visual studio 2012\\Projects\\DataMiningAprioriAlgorithm\\DataMiningAprioriAlgorithm\\" + dbselection + ".txt"))
                {
                    String contents = data;
                    String trimmedcontents = "";
                    if (contents != "")
                        trimmedcontents = contents.Substring(4);

                    linebylinecapture.Add(data);
                    linebylinecapture.Remove(",");


                    String[] strings = trimmedcontents.Split(' ');


                    for (int i = 0; i < strings.Length; i++)
                    {
                        if (dataholder.ContainsKey(strings[i]))
                        {
                            dataholder[strings[i]] = dataholder[strings[i]] + 1;

                        }
                        else
                        {
                            dataholder.Add(strings[i], occurrances);

                        }

                    }
                }

                for (int i = 0; i < linebylinecapture.Count; i++)
                    linebylinecapture.Remove("");
              //  dataholder.OrderBy(x => x.Key);
                countdata = linebylinecapture.Count;
                int occur = 1;
                foreach (var items in dataholder.Keys)
                {
                    listView3.Items.Add(items);
                }

                foreach (var items in dataholder)
                {
                    long valuess = (items.Value * 100 / countdata);
                    if (items.Key != "" && valuess >= support)
                    {
                        itemset1.Add(items.Key, valuess);
                        listView1.Items.Add(string.Format("{0} . {1} : {2}", occur, items.Key.ToString(), valuess));
                        occur++;
                    }


                }
            }

            catch (Exception exp)
            {

            }
            dataholder.Remove("");
            int supp = 1;
            List<String> linewordskeeper = new List<string>();
            for (int items = 0; items < itemset1.Count - 1; items++)
            {
                String keyvalue = itemset1.ElementAt(items).Key;
                for (int j = items + 1; j < itemset1.Count; j++)
                {
                    String couplevalue = keyvalue + " " + itemset1.ElementAt(j).Key;

                    for (int i = 0; i < linebylinecapture.Count; i++)

                        if (linebylinecapture[i].Contains(keyvalue) && linebylinecapture[i].Contains(itemset1.ElementAt(j).Key))
                        {
                            if (dataholder2.ContainsKey(couplevalue))
                            {
                                dataholder2[couplevalue] = dataholder2[couplevalue] + 1;
                            }
                            else
                                dataholder2.Add(couplevalue, supp);
                        }


                }
            }

            foreach (var items in dataholder2)
            {
                string data = items.Key;
                int length = data.IndexOf(" ");
                string firsthalf = data.Substring(0, length);
                string arrow = items.Key.Replace(" ", "-------->");
                long valuess = (items.Value * 100 / countdata);

            }

            foreach (var items1 in dataholder)
            {
                foreach (var items in dataholder2)
                {
                    
                    string data = items.Key;
                    int length = data.IndexOf(" ");
                    string firsthalf = data.Substring(0, length);
                    string arrow = items.Key.Replace(" ", "-------->");
                    long valuess = (items.Value * 100 / countdata);

                    if (items1.Key.Equals(firsthalf))
                    {
                        long conficheck = items.Value * 100 / items1.Value;
                        if (valuess >= support)
                            listView4.Items.Add(arrow +"["+valuess +"]"+ "[" + Convert.ToInt32(conficheck) + "]");
                        
                    }
                }
            }
        }
        
    }
    
}
