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
        public string Type;

        public Data(string x, string y, string z, string pitch, string roll, string yaw, string animDict, string animName, string frozen, string model, string type)
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
            Type = type;
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

                        setfile:

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
                            Console.ReadLine();
                            goto genfile;
                        }

                    case "genfile":

                        genfile:

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
                        string Type = "";

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
                                        case "Type":
                                            Type = reader.ReadInnerXml();
                                            break;
                                    }
                                }
                                else if (reader.Name == "Placement" && !reader.IsStartElement())
                                {
                                    m_data.Add(new Data(x, y, z, Pitch, Roll, Yaw, AnimDict, AnimName, Frozen, Model, Type));

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
                                    Type = "";
                                }
                            }
                        }

                        Console.WriteLine("Found " + m_data.Count + " items.\n");

                        string s = "";
                        string space = "                ";

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
                            s += d.Model + ", ";
                            s += "(ObjectType)" + d.Type + "),\n" + space;
                        }

                        s = s.Remove(s.Length - (2 + space.Length));

                        Clipboard.SetText(s);

                        Console.WriteLine("Done, enter for new setfile");
                        Console.ReadLine();
                        goto setfile;

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
