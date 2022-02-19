using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
//using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using static AmongUsRegionsEditor.RegionInfoJson;

namespace AmongUsRegionsEditor
{
    public partial class formAURE : Form
    {
        string titleText = $"Among Us Region Editor(for 2022-2-8 or newer on PC) v{System.Reflection.Assembly.GetEntryAssembly().GetName().Version}";
        string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\..\LocalLow\Innersloth\Among Us\regionInfo.json";
        string testpath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\..\LocalLow\Innersloth\Among Us\regionInfoTest.json";
        //string regiontype = null;
        string dnstype = "DnsRegionInfo, Assembly-CSharp";
        string statictype = "StaticRegionInfo, Assembly-CSharp";
        string staticHTTPtype = "StaticHttpRegionInfo, Assembly-CSharp";

        int lastUsedRegionNumber = -1;

        public formAURE()
        {
            InitializeComponent();
        }

        private void formAURE_Load(object sender, EventArgs e)
        {
            this.Text = titleText;
            //startup graphics mods to enable easy editing and correct startup positions.
            gbEditingArea.SetBounds(6, 43, 770, 169);
            this.Height = 500;
            gbCustomRegions.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            Root jroot = DeserializeRoot(path);
            lastUsedRegionNumber = (int)jroot.CurrentRegionIdx;
            CreateRegionTables();
            DeserializeRegions(jroot.Regions);
            ImportOnLoad();
        }

        public Root DeserializeRoot(string jsonpath)
        {
            using (StreamReader r = new StreamReader(jsonpath))
            {

                string json = r.ReadToEnd();
                r.Dispose();
                //string json = DeserializeFromStream(r);
                //txtFullJson.Text = json.ToString();
                /*works but trying other way         dynamic array = JsonConvert.DeserializeObject(json);
                         foreach (var item in array)
                         {
                             txtFullJson.AppendText("\n" + item.ToString());
                             //Console.WriteLine("{0} {1}", item.temp, item.vcc);
                         }*/
                Root jsonroot = JsonConvert.DeserializeObject<Root>(json);
                //Root jsonroot = System.Text.Json.JsonSerializer.Deserialize<Root>(json);
                //List<Root> Root = JsonConvert.DeserializeObject<List<Root>>(json);
                return jsonroot;
            }
        }

        public void DeserializeRegions(List<Region> regions)
        {
            List<Dictionary<string, string>> regiondata = new List<Dictionary<string, string>>();
            //List<Dictionary<string, dynamic>> dnsregiondata = new List<Dictionary<string, dynamic>>();
            //List<Dictionary<string, dynamic>> staticregiondata = new List<Dictionary<string, dynamic>>();
            Dictionary<string, string> reg = new Dictionary<string, string>();
            string regiontype = null;
            int addedrownumber = 0;
            List<Server> servers = new List<Server>();
            
            foreach (Region r in regions)
            {
                bool httpflag = false;
                if (r.Servers==null)
                //if (r.PingServer == null)
                {
                    regiontype = dnstype;
                    servers = null;
                }
                else
                {
                    foreach(Server s in r.Servers)
                    {
                        if(s.Ip.Contains("http"))
                        {
                            httpflag = true;
                            break;
                        }
                    }
                    if(httpflag)
                    {
                        regiontype = staticHTTPtype;
                    }
                    else
                    {
                        regiontype = statictype;
                    }
                    servers = r.Servers;
                }

                AddDataToRegionTables(addedrownumber, false, regiontype, r.Fqdn, r.DefaultIp, r.Port.ToString(),r.useDtls, r.Name, r.PingServer, servers, r.TranslateName.ToString());
                addedrownumber = addedrownumber + 1;
                /*if (r.Type == "DnsRegionInfo, Assembly-CSharp")
                {
                //dns server type
                reg.Clear();
                reg.Add("type", r.type);
                    reg.Add("Fqdn", r.Fqdn);
                    reg.Add("DefaultIp",r.DefaultIp);
                    reg.Add("Port",r.Port.ToString());
                    reg.Add("Name",r.Name);
                    reg.Add("TranslateName",r.TranslateName.ToString());
                    regiondata.Add(reg);
                //Console.WriteLine(reg.);
                    //dnsregiondata.Add(reg);
                }
                else if (r.Type == "StaticRegionInfo, Assembly-CSharp")
                {
                    //static server type
                    reg.Add("type", r.Type);
                    reg.Add("Name", r.Name);
                    reg.Add("PingServer", r.PingServer);
                    reg.Add("Servers", r.Servers);
                    reg.Add("TranslateName", r.TranslateName);
                    regiondata.Add(reg);
                    //staticregiondata.Add(reg);
                }
                else
                {
                    //error
                }*/

            }
            //cant sort because of buttons
            //dgvCustomRegions.Sort(dgvCustomRegions.Columns[dgvCustomRegions.Columns.Count-3],ListSortDirection.Descending);
            //Console.WriteLine(dgvRegions.Columns.Count);
        }

        internal int imp = 0;
        bool saveFlag = false;

        internal void AddDataToRegionTables(int row, bool imported, string type, string fqdn, string defaultip, string port, string usedtls, string name, string pingserver, List<Server> serversdata, string translatename)
        {
            if (imported)
            {
                //do nothing here yet... currently doing this in the import function but ideally want to colour in the rows to show they are imported.
            }
            if (type == staticHTTPtype)
            {
                //new statichttp region type
                /*            dgvOfficialRegions.Columns.Add("$Type", "$Type");
            //dgvOfficialRegions.Columns[0].Visible = false;
            dgvOfficialRegions.Columns.Add("Name", "Name");
            dgvOfficialRegions.Columns.Add("PingServer", "PingServer");
            dgvOfficialRegions.Columns.Add("Server.Name", "Server.Name");
            dgvOfficialRegions.Columns.Add("Server.Ip", "Server.Ip");
            dgvOfficialRegions.Columns.Add("Server.Port", "Server.Port");
            dgvOfficialRegions.Columns.Add("TranslateName", "TranslateName");*/
                foreach (Server server in serversdata)
                {
                    dgvOfficialRegions.Rows.Add("staticHTTP", name,pingserver,server.Name, server.Ip, server.Port, server.UseDtls, server.Players,server.ConnectionFailures, translatename, "", "");
                }
        }
            else if(type==dnstype)
            {
                //we dont support static regions atm, only DNS regions.
                //this is now old.
                if (fqdn == "na.mm.among.us" || fqdn == "eu.mm.among.us" || fqdn == "as.mm.among.us")
                {
                    //Console.WriteLine(fqdn);
                    dgvOfficialRegions.Rows.Add("DNS", fqdn, defaultip, port, usedtls, name, translatename);
                    /*using (var dgvrow = dgvRegions.Rows[row])
                    {
                        dgvrow.ReadOnly = true;
                        dgvrow.DefaultCellStyle.BackColor = System.Drawing.Color.Gray;
                        dgvrow.Frozen = true;
                        //dgvrow.Visible = false;
                    }*/
                }
                else
                {
                int officialrows = dgvOfficialRegions.Rows.Count;
                int customrows = dgvCustomRegions.Rows.Count;
                dgvCustomRegions.Rows.Add("DNS", fqdn, defaultip, port, usedtls, name, translatename, "", "");
                dgvCustomRegions.Rows[customrows].Cells[7] = GenerateButton(7, "Edit Region");
                dgvCustomRegions.Rows[customrows].Cells[8] = GenerateButton(8, "Remove Region");
                dgvCustomRegions.Rows[customrows].Cells[9] = GenerateButton(9, "Export Region");
                }
            }
            else if(type==statictype)
            {
                saveFlag = true;
                //basic supported conversion of old static regions.
                int officialrows = dgvOfficialRegions.Rows.Count;
                int customrows = dgvCustomRegions.Rows.Count;
                foreach (Server server in serversdata)
                {
                    dgvCustomRegions.Rows.Add("DNS", server.Ip, server.Ip, server.Port, "false", server.Name, translatename, "", "");
                    dgvCustomRegions.Rows[customrows].Cells[7] = GenerateButton(7, "Edit Region");
                    dgvCustomRegions.Rows[customrows].Cells[8] = GenerateButton(8, "Remove Region");
                    dgvCustomRegions.Rows[customrows].Cells[9] = GenerateButton(9, "Export Region");
                }
            }
            //for once we support static regions, if we ever choose to do so.
            //dgvRegions.Rows.Add(type, fqdn, defaultip, port, name, translatename, pingserver);

            //resizing dgv's so they look nice and neat
            ResetDgvHeightAndWidth(dgvOfficialRegions, 0, 0);
            ResetDgvHeightAndWidth(dgvCustomRegions, 21, 0);
            if(saveFlag==true)
            {
                WriteRegionInfoJson();
                saveFlag = false;
            }
        }

        private void ResetDgvHeightAndWidth(DataGridView dgvtable, int extrawidth, int extraheight)
        {
            int width = 0;
            int height = 0;
            foreach (DataGridViewColumn c in dgvtable.Columns)
            {
                if (c.Visible == true)
                {
                    width = width + c.Width;
                }
            }
            dgvtable.Width = width;
            foreach (DataGridViewRow r in dgvtable.Rows)
            {
                if (r.Visible == true)
                {
                    height = height + r.Height;
                }
            }
            height = height + dgvtable.ColumnHeadersHeight;
            this.Width = width + extrawidth+200;
            //this.Height = height + extraheight+200;
        }

        public void CreateRegionTables()
        {
            /*dgvOfficialRegions.Columns.Add("$Type", "$Type");
            dgvOfficialRegions.Columns[0].Visible = false;
            dgvOfficialRegions.Columns.Add("Fqdn", "DNS");
            dgvOfficialRegions.Columns.Add("DefaultIp", "DefaultIp");
            dgvOfficialRegions.Columns.Add("Port", "Port");
            dgvOfficialRegions.Columns.Add("UseDTLS", "UseDTLS");
            dgvOfficialRegions.Columns.Add("Name", "Name");
            dgvOfficialRegions.Columns.Add("TranslateName", "TranslateName");
            dgvOfficialRegions.Columns[6].Visible = false;*/

            //new statichttpformat
            dgvOfficialRegions.AutoSizeColumnsMode = (DataGridViewAutoSizeColumnsMode)DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvOfficialRegions.Columns.Add("$Type", "$Type");
            dgvOfficialRegions.Columns[0].Visible = false;
            dgvOfficialRegions.Columns.Add("Name", "Name");
            dgvOfficialRegions.Columns.Add("PingServer", "PingServer");
            dgvOfficialRegions.Columns.Add("Server.Name", "Server.Name");
            dgvOfficialRegions.Columns[3].Visible = false;
            dgvOfficialRegions.Columns.Add("Server.Ip", "Server.Ip");
            dgvOfficialRegions.Columns.Add("Server.Port", "Server.Port");
            dgvOfficialRegions.Columns.Add("Server.UseDtls", "Server.UseDtls");
            dgvOfficialRegions.Columns.Add("Server.Players", "Server.Players");
            dgvOfficialRegions.Columns[7].Visible = false;
            dgvOfficialRegions.Columns.Add("Server.ConnectionFailures", "Server.ConnectionFailures");
            dgvOfficialRegions.Columns[8].Visible = false;
            dgvOfficialRegions.Columns.Add("TranslateName", "TranslateName");
            //dgvOfficialRegions.Columns[6].Visible = false;

            dgvCustomRegions.Columns.Add("$Type", "$Type");
            dgvCustomRegions.Columns[0].Visible = false;
            dgvCustomRegions.Columns.Add("Fqdn", "DNS");
            dgvCustomRegions.Columns.Add("DefaultIp", "DefaultIp");
            dgvCustomRegions.Columns.Add("Port", "Port");
            dgvCustomRegions.Columns.Add("UseDTLS", "UseDTLS");
            dgvCustomRegions.Columns.Add("Name", "Name");
            dgvCustomRegions.Columns.Add("TranslateName", "TranslateName");
            dgvCustomRegions.Columns[6].Visible = false;
            DataGridViewColumn dgvbc = new DataGridViewTextBoxColumn();
            dgvbc.Name = "EditRow";
            dgvbc.HeaderText = "Edit?";
            dgvCustomRegions.Columns.Add(dgvbc);
            DataGridViewColumn dgvbc2 = new DataGridViewTextBoxColumn();
            dgvbc2.Name = "RemoveRow";
            dgvbc2.HeaderText = "Remove?";
            dgvCustomRegions.Columns.Add(dgvbc2);
            DataGridViewColumn dgvbc3 = new DataGridViewTextBoxColumn();
            dgvbc3.Name = "ExportRow";
            dgvbc3.HeaderText = "Export?";
            dgvCustomRegions.Columns.Add(dgvbc3);
            dgvCustomRegions.CellClick += dgvRegions_Click;
            //dgvRegions.Columns[6].ValueType=Type;

            //dgvRegions.Columns.Add("PingServer", "PingServer");
        }

        internal DataGridViewButtonCell GenerateButton(int tag, string textvalue)
        {
            using (DataGridViewButtonCell rb = new DataGridViewButtonCell())
            {
                rb.Value = textvalue;
                rb.Tag = tag.ToString();

                //rb.DataGridView.Click += new EventHandler(DgvButton_Click);
                return rb;
            }
        }

        //this is all automated should never need to change this unless more buttons are added to the table.
        private void dgvRegions_Click(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            try
            {
                if (senderGrid.CurrentCell is DataGridViewButtonCell)
                //if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
                {
                    string sht = senderGrid.Columns[senderGrid.CurrentCell.ColumnIndex].HeaderText;
                    int row = senderGrid.CurrentCell.RowIndex;
                    if (sht.Contains("Edit"))
                    {
                        Console.WriteLine("Editing Row {0}", row + 1);
                        btnEditRegion_Click(sender, e, row);
                    }
                    else if (sht.Contains("Remove"))
                    {
                        Console.WriteLine("Removing Row {0}", row + 1);
                        btnRemoveRegion_Click(sender, e, row);
                    }
                    else if(sht.Contains("Export"))
                    {
                        Console.WriteLine("Exporting Row {0}", row + 1);
                        btnExportRegion_Click(sender, e, row);
                    }
                    else
                    {
                        throw new NotImplementedException();
                    }
                }
                else
                {
                    //do nothing for now...
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR:-\n{0}", ex.ToString());
            }
        }

        //this is just automated formatting on the table, shouldent need changing.
        private void dgvRegions_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            e.CellStyle.BackColor = System.Drawing.Color.White;
            e.CellStyle.ForeColor = System.Drawing.Color.Black;
            e.CellStyle.SelectionBackColor = System.Drawing.Color.White;
            e.CellStyle.SelectionForeColor = System.Drawing.Color.Black;
        }

        private void btnCreateRegion_Click(object sender, EventArgs e)
        {
            gbEditingArea.Text = "Add Region";
            lblRecordToEdit.Text = "-1";
            txtFqdn.Text = "";
            txtFqdn.Enabled = false;
            chkDNS.Checked = false;
            txtIPAddress.Text = "";
            txtPort.Text = "";
            txtRegionDisplayName.Text = "";
            gbOfficialRegions.Enabled = false;
            gbEditingArea.Enabled = true;
            gbOfficialRegions.Visible = false;
            gbEditingArea.Visible = true;
            txtRegionDisplayName.Focus();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            gbEditingArea.Enabled = false;
            gbOfficialRegions.Enabled = true;
            gbEditingArea.Visible = false;
            gbOfficialRegions.Visible = true;

        }

        private void btnEditRegion_Click(object sender, EventArgs e, int row)
        {
            gbEditingArea.Text = "Edit Region";
            lblRecordToEdit.Text = row.ToString();
            txtFqdn.Text = (string)dgvCustomRegions.Rows[row].Cells[1].Value;
            if ((string)dgvCustomRegions.Rows[row].Cells[1].Value == (string)dgvCustomRegions.Rows[row].Cells[2].Value)
            {
                txtFqdn.Text = "";
                txtFqdn.Enabled = false;
                chkDNS.Checked = false;
                txtRegionDisplayName.Focus();
            }
            else
            {
                txtFqdn.Focus();
            }
            txtIPAddress.Text = (string)dgvCustomRegions.Rows[row].Cells[2].Value;
            txtPort.Text = (string)dgvCustomRegions.Rows[row].Cells[3].Value;
            txtRegionDisplayName.Text = (string)dgvCustomRegions.Rows[row].Cells[5].Value;
            gbOfficialRegions.Enabled = false;
            gbEditingArea.Enabled = true;
            gbOfficialRegions.Visible = false;
            gbEditingArea.Visible = true;
        }

        private void btnRemoveRegion_Click(object sender, EventArgs e, int row)
        {
            var senderGrid = (DataGridView)sender;
            string removekey = (string)senderGrid.Rows[row].Cells[8].Value;
            if (removekey.Contains("Remove"))
            {
                senderGrid.Rows[row].Cells[8].Value = "Confirm?";
            }
            else
            {
                dgvCustomRegions.Rows.RemoveAt(row);
                ResetDgvHeightAndWidth(dgvCustomRegions, 21, 0);
                WriteRegionInfoJson();
            }
        }

        private void btnExportRegion_Click(object sender, EventArgs e, int row)
        {
            var type = dnstype;
            var fqdn = (string)dgvCustomRegions.Rows[row].Cells[1].Value;
            var ipaddress = (string)dgvCustomRegions.Rows[row].Cells[2].Value;
            var port = Int32.Parse((string)dgvCustomRegions.Rows[row].Cells[3].Value);
            var usedtls = (string)dgvCustomRegions.Rows[row].Cells[4].Value;
            var name = (string)dgvCustomRegions.Rows[row].Cells[5].Value;
            var translatename = Int32.Parse((string)dgvCustomRegions.Rows[row].Cells[6].Value);
            if(!Directory.Exists(@".\Export"))
            {
                Directory.CreateDirectory(@".\Export\");
            }

            JObject dnsregion = DNSRegion(type, fqdn, ipaddress, port,usedtls, name, translatename);
            File.WriteAllText(@".\Export\AmongUsRegion-"+name+".aur", JsonConvert.SerializeObject(dnsregion));
            MessageBox.Show($"{name} was successfully Exported, please check 'Export' folder");
        }

        private void ImportOnLoad()
        {
            if(!Directory.Exists(@".\Import\"))
            {
                Directory.CreateDirectory(@".\Import\");
            }
            var importFiles = Directory.EnumerateFiles(@".\Import\");
            int filecount = 0;
            List<string> regionnames = new List<string>();
            foreach (var file in importFiles)
            {
                using (StreamReader r = new StreamReader(file))
                {
                    string json = r.ReadToEnd();
                    r.Dispose();
                    Region jsonregion = JsonConvert.DeserializeObject<Region>(json);
                    string regiontype = null;
                    if (jsonregion.PingServer == null)
                    {
                        regiontype = dnstype;
                    }
                    else
                    {
                        regiontype = statictype;
                    }
                    regionnames.Add(jsonregion.Name);
                    ManageDnsRegionData(-1, true, regiontype, jsonregion.Fqdn, jsonregion.DefaultIp, jsonregion.Port.ToString(), jsonregion.useDtls,jsonregion.Name, jsonregion.TranslateName.ToString());
                }
                filecount++;
                File.Delete(file);
            }
            if(filecount!=0)
            {
                //not needed? should save on manage dns region data?
                //WriteRegionInfoJson();
                string listofregions = "";
                foreach(string region in regionnames)
                {
                    listofregions += $"{region}, ";
                }
                MessageBox.Show($"{filecount} Regions were imported upon loading this program!...{listofregions}","Importing Success",MessageBoxButtons.OK);
            }
        }

        private void btnSaveDetails_Click(object sender, EventArgs e)
        {
            gbEditingArea.Enabled = false;
            gbOfficialRegions.Enabled = true;
            gbEditingArea.Visible = false;
            gbOfficialRegions.Visible = true;
            int rownum = Int32.Parse(lblRecordToEdit.Text);
            string regiontype = dnstype;
            string regionfqdn = txtFqdn.Text;
            string regiondefaultip = txtIPAddress.Text;
            if (regionfqdn == "" || chkDNS.Checked == false)
            {
                regionfqdn = regiondefaultip;
            }
            string regionport = txtPort.Text;
            string regionusedtls = "false";
            string regionname = txtRegionDisplayName.Text;
            string regiontranslatename = "1003";
            ManageDnsRegionData((int)rownum, false, regiontype, regionfqdn, regiondefaultip, regionport, regionusedtls, regionname, regiontranslatename);
        }

        internal void ManageDnsRegionData(int row, bool imported, string type, string fqdn, string defaultip, string port, string usedtls, string name, string translatename)
        {
            if (row == -1)
            {
                AddDataToRegionTables(dgvCustomRegions.Rows.Count,imported, type, fqdn, defaultip, port,usedtls, name, null, null, translatename);
                //dgvCustomRegions.Rows.Add(type, fqdn, defaultip, port, name, translatename,"","");
                //dgvCustomRegions.Rows[dgvCustomRegions.Rows.Count-1].Cells[6] = GenerateButton(row, "Edit");
                //dgvCustomRegions.Rows[dgvCustomRegions.Rows.Count - 1].Cells[7] = GenerateButton(row, "Remove");
            }
            else
            {
                dgvCustomRegions.Rows[row].Cells[0].Value = type;
                dgvCustomRegions.Rows[row].Cells[1].Value = fqdn;
                dgvCustomRegions.Rows[row].Cells[2].Value = defaultip;
                dgvCustomRegions.Rows[row].Cells[3].Value = port;
                dgvCustomRegions.Rows[row].Cells[4].Value = usedtls;
                dgvCustomRegions.Rows[row].Cells[5].Value = name;
                dgvCustomRegions.Rows[row].Cells[6].Value = translatename;
            }
            WriteRegionInfoJson();
        }

        private void chkDNS_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDNS.Checked == true)
            {
                txtFqdn.Enabled = true;
                txtFqdn.Focus();
            }
            else
            {
                txtFqdn.Enabled = false;
                txtRegionDisplayName.Focus();
            }
        }

        private JObject DNSRegion(string type, string fqdn, string defaultip, int port, string usedtls, string name, int translatename)
        {
            JObject DNSRegion = new JObject(
                new JProperty("$type", type),
                new JProperty("Fqdn", fqdn),
                new JProperty("DefaultIp", defaultip),
                new JProperty("Port", port),
                new JProperty("UseDtls", usedtls),
                new JProperty("Name", name),
                new JProperty("TranslateName", translatename)
                );
            return DNSRegion;
        }

        private JObject StaticHTTPRegion(string type, string name, string pingserver, List<JObject> servers,int translatename)
        {
            JObject StaticHTTPRegion = new JObject(
                new JProperty("$type", type),
                new JProperty("Name", name),
                new JProperty("PingServer", pingserver),
                new JProperty("Servers", servers),
                new JProperty("TranslateName", translatename)
                );
            return StaticHTTPRegion;
        }

        private JObject Server(string name, string ip, int port,bool usedtls,int players, int connectionfailures)
        {
            JObject Server = new JObject(
                new JProperty("Name", name),
                new JProperty("Ip", ip),
                new JProperty("Port", port),
                new JProperty("UseDtls", usedtls),
                new JProperty("Players", players),
                new JProperty("ConnectionFailures", connectionfailures)
                );
            return Server;
        }

        private void WriteRegionInfoJson()
        {//disable saving for now
            
            List<JObject> RegionList = new List<JObject>();

            //FORMAT:- type, name, pingserver,servers, translatename
            List<Tuple<string, string, string, List<JObject>, int>> staticHttpRegions = new List<Tuple<string, string, string, List<JObject>, int>>();

            foreach (DataGridViewRow r in dgvOfficialRegions.Rows)
            {
                /* this needs changing
                string type = dnstype;
                string fqdn = (string)r.Cells[1].Value;
                string ipaddress = (string)r.Cells[2].Value;
                int port = (int)Int32.Parse(r.Cells[3].Value.ToString());
                string usedtls = (string)r.Cells[4].Value;
                string name = (string)r.Cells[5].Value;
                int translatename = (int)Int32.Parse(r.Cells[6].Value.ToString());
                RegionList.Add(DNSRegion(type, fqdn, ipaddress, port, usedtls, name, translatename));*/
                //dgvOfficialRegions.Rows.Add("staticHTTP", name, pingserver, server.Name, server.Ip, server.Port, server.UseDtls, server.Players, server.ConnectionFailures, translatename, "", "");

                List<JObject> servers = new List<JObject>();
                List<Server> realServers = new List<Server>();
                bool replaceFlag = false;
                string type = staticHTTPtype;
                string name = (string)r.Cells[1].Value;
                string pingserver = (string)r.Cells[2].Value;
                var OldRegion = new JObject();

                foreach (var reg in staticHttpRegions)
                {
                    if (pingserver == reg.Item3)
                    {
                        replaceFlag = true;
                        servers = reg.Item4;
                        OldRegion = StaticHTTPRegion(reg.Item1,reg.Item2,reg.Item3,reg.Item4,reg.Item5);
                        break;
                    }
                }

                foreach(var newS in servers)
                {
                    Server oldS = new Server();
                    oldS.Name = (string)newS.Property("Name").Value;
                    oldS.Ip = (string)newS.Property("Ip").Value;
                    oldS.Port = (int)newS.Property("Port").Value;
                    oldS.UseDtls = (bool)newS.Property("UseDtls").Value;
                    oldS.Players = (int)newS.Property("Players").Value;
                    oldS.ConnectionFailures = (int)newS.Property("ConnectionFailures").Value;
                }


                Server s = new Server();
                s.Name = (string)r.Cells[3].Value;
                s.Ip = (string)r.Cells[4].Value;
                s.Port = (int)r.Cells[5].Value;
                s.UseDtls = (bool)r.Cells[6].Value;
                s.Players = (int)r.Cells[7].Value;
                s.ConnectionFailures = (int)r.Cells[8].Value;
                realServers.Add(s);

                /*Server s = new Server();
                s.Name = (string)r.Cells[3].Value;
                s.Ip = (string)r.Cells[4].Value;
                s.Port = (int)r.Cells[5].Value;
                s.UseDtls = (bool)r.Cells[6].Value;
                s.Players = (int)r.Cells[7].Value;
                s.ConnectionFailures = (int)r.Cells[8].Value;
                servers.Add(s);*/
                servers.Add(Server((string)r.Cells[3].Value, (string)r.Cells[4].Value, (int)r.Cells[5].Value, (bool)r.Cells[6].Value, (int)r.Cells[7].Value, (int)r.Cells[8].Value));

                int translatename = Convert.ToInt32(r.Cells[9].Value.ToString());
                if (replaceFlag)
                {
                    RegionList.Remove(OldRegion);
                }
                RegionList.Add(StaticHTTPRegion(type, name, pingserver, servers, (int)translatename));
            }

            foreach (DataGridViewRow r in dgvCustomRegions.Rows)
            {
                string type = dnstype;
                string fqdn = (string)r.Cells[1].Value;
                string ipaddress = (string)r.Cells[2].Value;
                int port = (int)Int32.Parse(r.Cells[3].Value.ToString());
                string usedtls = (string)r.Cells[4].Value;
                string name = (string)r.Cells[5].Value;
                int translatename = (int)Int32.Parse(r.Cells[6].Value.ToString());
                RegionList.Add(DNSRegion(type, fqdn, ipaddress, port, usedtls, name, translatename));
            }

            if(lastUsedRegionNumber>RegionList.Count-1)
            {
                lastUsedRegionNumber = RegionList.Count-1;
            }

            JObject Root = new JObject(
                new JProperty("CurrentRegionIdx", (int)lastUsedRegionNumber),
                new JProperty("Regions",RegionList)
                );

            File.WriteAllText(path, JsonConvert.SerializeObject(Root));
            
        }

        //no longer required?
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = false;
            lblSavedRIJ.Text = "Saving RegionInfo.json";
            WriteRegionInfoJson();
            lblSavedRIJ.Text = "RegionInfo.json Saved";
            //lblSavedRIJ.Text = clearLabelOnTimer(lblSavedRIJ);
            btnSave.Enabled = true;
        }

        /*private string clearLabelOnTimer(Label label)
        {
            bool flag = false;
            DateTime end = DateTime.UtcNow.AddSeconds(10);
            while(flag==false)
            {
                if(end<=DateTime.UtcNow)
                {
                    flag = true;
                }
            }

            flag = false;
            return "";
        }*/
    }
}
