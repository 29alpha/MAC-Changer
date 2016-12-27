using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Management;
using System.Net.NetworkInformation;
using System.Windows.Forms;

namespace MacChanger
{
    public partial class Form1 : Form
    {
        // Getting the Global IP properties of the Local Machine
        IPGlobalProperties boxProperties = IPGlobalProperties.GetIPGlobalProperties();
        // Creating an array of all the NICs
        NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
        // Create class-scoped variables to hold NIC ID (from NetworkInterface) and Name (Description from WMI Network Adapter)
        string nicID, nicName;
        // Declaring keys in the class scope
        RegistryKey hklm, mackey;
        public Form1()
        {
            InitializeComponent();
            // Escalating privileges to write to HKLM.  Did not resposibly revert.  Bad code monkey.
            new System.Security.Permissions.RegistryPermission(System.Security.Permissions.PermissionState.Unrestricted).Assert();
            // Buiding RegistryKeys (class-scoped), in the same scope as the Assert.
            hklm = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry32);
            mackey = hklm.OpenSubKey(@"SYSTEM\CurrentControlSet\Control\Class\{4D36E972-E325-11CE-BFC1-08002BE10318}", true);
            // Grabbing all the interfaces
            GetNetworkInterfaces();
            }

        private void Form1_Load(object sender, EventArgs e)
        {
            // DataBinding to Form controls
            populateControls();
        }

        protected void GetNetworkInterfaces()
        {
            // IList needed to bind to DataSource
            IList<NetworkInterface> listNics = new List<NetworkInterface>();
            foreach (NetworkInterface nic in nics)
            {
                listNics.Add(nic);
            }
            // Bind the NICs by Name to the Drop Down Box
            // Returns the ID of the selected NIC
            cbNICs.DataSource = listNics;
            cbNICs.DisplayMember = "Description";
            cbNICs.ValueMember = "ID";
            // Event Handler to update Form controls when selection changes
            cbNICs.SelectionChangeCommitted += new EventHandler(populateControls);
        }
        private void populateControls()
        {
            // Setting Revert button to disabled
            btnRevert.Enabled = false;
             NetworkInterface selected = nics[(cbNICs.SelectedIndex)];
            // Setting global variables
            nicID = selected.Id;
            nicName = selected.Description;
            // Updating controls
            lblType.Text = "Network Interface Type: " + selected.NetworkInterfaceType;
            lblIP.Text = "IP Address: " + selected.GetIPProperties().UnicastAddresses[0].Address.MapToIPv4().ToString();
            // TODO: Why doesn't this value update after changing MAC?
            txtMAC.Text = selected.GetPhysicalAddress().ToString();
            // Enabling the Revert button if there is a MAC spoofing key in the Registry
            foreach(string subKeyName in mackey.GetSubKeyNames()) {
                RegistryKey regnic = mackey.OpenSubKey(subKeyName);
                // Fitlering Software Loopback Interfaces, which return null instead of a NetworkInterface
                if((regnic.GetValue("NetCfgInstanceID")) == null) {
                    break;
                    }
                else {
                    // Matching the ID Property of the Network Interface to the RegistryKey value 
                    if(selected.Id == regnic.GetValue("NetCfgInstanceID").ToString()) {
                        if(regnic.GetValue("NetworkAddress") == null) {
                            break;
                            }
                        else {
                            btnRevert.Enabled = true;
                            break;
                            }
                        }
                    }
                }
        }

        // This overload is required to tie the method to an event handler.
        // It just makes a call to the parameterless method.
        private void populateControls(object sender, EventArgs e)
        {
            populateControls();
        }
        private void btnChange_Click(object sender, EventArgs e)
        {
            // Matching the Network Interface ID property to a RegistryKey value
            foreach (string subKeyName in mackey.GetSubKeyNames())
            {
                RegistryKey regnic = hklm.OpenSubKey(@"SYSTEM\CurrentControlSet\Control\Class\{4D36E972-E325-11CE-BFC1-08002BE10318}\" + subKeyName, RegistryKeyPermissionCheck.ReadWriteSubTree);
                if ((string)regnic.GetValue("NetCfgInstanceID") == nicID)
                {
                    // Adding the RegistryKey value to spoof MAC
                    regnic.SetValue("NetworkAddress", txtMAC.Text);
                    // Changes take affect after resetting the Adapter
                    btnChange.Text = "One moment...";
                    resetAdapter();
                    btnChange.Text = "Change MAC";
                    btnRevert.Enabled = true;
                    RefreshInterfaces();
                    break;
                }

            }
        }

        private void RefreshInterfaces() {

            
            }
        private void btnRevert_Click(object sender, EventArgs e)
        {
            // Matching the Network Interface ID property to a RegistryKey value
            foreach (string subKeyName in mackey.GetSubKeyNames())
            {
                RegistryKey regnic = hklm.OpenSubKey(@"SYSTEM\CurrentControlSet\Control\Class\{4D36E972-E325-11CE-BFC1-08002BE10318}\" + subKeyName, RegistryKeyPermissionCheck.ReadWriteSubTree);
                if ((string)regnic.GetValue("NetCfgInstanceID") == nicID)
                {
                    if (regnic.GetValue("NetworkAddress").ToString() == null)
                    {
                        break;
                    }
                    else
                    {
                        // Deleting the RegistryKey Value reverts to the hardware-defined MAC
                        regnic.DeleteValue("NetworkAddress");
                        // Changes take effect after the adapter is reset
                        btnRevert.Text = "One moment....";
                        resetAdapter();
                        btnRevert.Text = "Revert";
                        btnRevert.Enabled = false;
                        break;
                    }
                }

            }
        }
        // Disables and Enables the adapter so the MAC change takes effect
        private void resetAdapter()
        {
            // Getting a collection (of one) Network Adapter from WMI
            ManagementObject currentMObject = new ManagementObject();
            string strWQuery = "SELECT * FROM Win32_NetworkAdapter WHERE Name = " + "'" + nicName + "'";
            ObjectQuery oQuery = new System.Management.ObjectQuery(strWQuery);
            ManagementObjectSearcher oSearcher = new ManagementObjectSearcher(oQuery);
            ManagementObjectCollection coladapters = oSearcher.Get();
            // Disable and Enable the selected adapter.
            foreach (ManagementObject mo in coladapters)
            {
                mo.InvokeMethod("Disable", null);
                mo.InvokeMethod("Enable", null);
            }
        }
    }
        }
    

