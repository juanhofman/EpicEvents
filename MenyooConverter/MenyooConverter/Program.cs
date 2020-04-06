using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace MenyooConverter
{
    struct Data
    {
        public string x;
        public string y;
        public string z;

        public string Pitch;
        public string Roll;
        public string Yaw;

        public string AnimDict;
        public string AnimName;

        public string Frozen;
        public string Model;

        public Data(string x, string y, string z, string pitch, string roll, string yaw, string animDict, string animName, string frozen, string model)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            Pitch = pitch;
            Roll = roll;
            Yaw = yaw;
            AnimDict = animDict;
            AnimName = animName;
            Frozen = frozen;
            Model = model;
        }
    }

    class Program
    {
        public static string File = "";

        [STAThread]
        static void Main(string[] args)//Posistion, Rotation, Animation, Frozen
        {
            bool m_Loop = true;
            while (m_Loop)
            {
                switch (Console.ReadLine().ToLower())
                {
                    case "setfile":

                        using (OpenFileDialog openFileDialog = new OpenFileDialog())
                        {
                            openFileDialog.InitialDirectory = @"D:\SteamLibrary\steamapps\common\Grand Theft Auto V\menyooStuff\Spooner";
                            openFileDialog.Filter = "xml files (*.xml)|*.xml";
                            openFileDialog.FilterIndex = 2;
                            openFileDialog.RestoreDirectory = true;

                            if (openFileDialog.ShowDialog() == DialogResult.OK)
                            {
                                //Get the path of specified file
                                File = openFileDialog.FileName;
                            }

                            Console.Clear();
                            Console.WriteLine("File selected was " + File);
                        }

                        break;

                    case "genfile":

                        List<Data> m_data = new List<Data>();

                        if (File == "")
                        {
                            Console.WriteLine("file is empty, use setfile to set a file\n\n");
                            continue;
                        }

                        string x = "";
                        string y = "";
                        string z = "";

                        string Pitch = "";
                        string Roll = "";
                        string Yaw = "";

                        string AnimDict = "";
                        string AnimName = "";
                        string Frozen = "";
                        string Model = "";

                        using (XmlReader reader = XmlReader.Create(File))
                        {
                            while (reader.Read())
                            {
                                if (reader.IsStartElement())
                                {
                                    switch (reader.Name)
                                    {
                                        case "ModelHash":
                                            Model = reader.ReadInnerXml();
                                            break;
                                        case "FrozenPos":
                                            Frozen = reader.ReadInnerXml();
                                            break;
                                        case "X":
                                            x = reader.ReadInnerXml() + "f";
                                            break;
                                        case "Y":
                                            y = reader.ReadInnerXml() + "f";
                                            break;
                                        case "Z":
                                            z = reader.ReadInnerXml() + "f";
                                            break;
                                        case "Pitch":
                                            Pitch = reader.ReadInnerXml() + "f";
                                            break;
                                        case "Roll":
                                            Roll = reader.ReadInnerXml() + "f";
                                            break;
                                        case "Yaw":
                                            Yaw = reader.ReadInnerXml() + "f";
                                            break;
                                        case "AnimDict":
                                            AnimDict = reader.ReadInnerXml();
                                            break;
                                        case "AnimName":
                                            AnimName = reader.ReadInnerXml();
                                            break;
                                    }
                                }
                                else if (reader.Name == "Placement" && !reader.IsStartElement())
                                {
                                    m_data.Add(new Data(x, y, z, Pitch, Roll, Yaw, AnimDict, AnimName, Frozen, Model));

                                    x = "";
                                    y = "";
                                    z = "";

                                    Pitch = "";
                                    Roll = "";
                                    Yaw = "";

                                    AnimDict = "";
                                    AnimName = "";
                                    Frozen = "";
                                    Model = "";
                                }
                            }
                        }

                        Console.WriteLine("Found " + m_data.Count + " items.\n");

                        Console.WriteLine("Please enter an format type: ");
                        switch (Console.ReadLine())
                        {
                            default://new LocationItem(0,0,0,0,0,0,"", "", false, 0x6546)

                                string s = "";
                                foreach (Data d in m_data)
                                {
                                    s += "new LocationItem(";
                                    s += d.x + ", ";
                                    s += d.y + ", ";
                                    s += d.z + ", ";

                                    s += d.Roll + ", ";
                                    s += d.Pitch + ", ";
                                    s += d.Yaw + ", ";

                                    s += '"' + d.AnimDict + '"' + ", ";
                                    s += '"' + d.AnimName + '"' + ", ";

                                    s += d.Frozen + ", ";
                                    s += d.Model + "),\n";
                                }

                                Console.WriteLine(s);
                                Clipboard.SetText(s);

                                break;
                        }

                        break;

                    case "exit":
                        m_Loop = false;
                        break;

                    default:
                        Console.Clear();
                        break;
                }
            }
        }
    }
}
