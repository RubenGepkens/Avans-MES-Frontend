using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Opc.Ua;
using Opc.Ua.Client;
using Opc.Ua.Configuration;

using System.Windows.Forms;

namespace FrontEnd
{
	class OPC
	{
        public string strServerAddress { get; set; }
        public int intServerPort { get; set; }
        public bool blnConnectionStatus { get; }

        private ApplicationInstance application = new ApplicationInstance();
        private ConfiguredEndpoint endpoint;

        public OPC(string IstrServerAddress, int IintServerPort)
        {
            strServerAddress = IstrServerAddress;
            intServerPort = IintServerPort;

            try
            {
                Console.WriteLine("Trying to connect to OPC...");

                // Define the UA Client application                
                //ApplicationInstance application = new ApplicationInstance();
                application.ApplicationName = "FrontEnd";
                application.ApplicationType = ApplicationType.Client;

                // load the application configuration.
                application.LoadApplicationConfiguration("FrontEnd.Config.xml", silent: false);

                // check the application certificate.
                application.CheckApplicationInstanceCertificate(silent: false, minimumKeySize: 0);

                EndpointConfiguration endpointConfiguration = EndpointConfiguration.Create(application.ApplicationConfiguration);

                //var endpointDescription = CoreClientUtils.SelectEndpoint("opc.tcp://192.168.8.145:4840", false);
                //var endpointDescription = CoreClientUtils.SelectEndpoint("opc.tcp://192.168.2.112:4840", false);

                string strConnection = "opc.tcp://" + strServerAddress + ":" + intServerPort.ToString();
                var endpointDescription = CoreClientUtils.SelectEndpoint(strConnection, false);

                //ConfiguredEndpoint endpoint = new ConfiguredEndpoint(null, endpointDescription, endpointConfiguration);
                endpoint = new ConfiguredEndpoint(null, endpointDescription, endpointConfiguration);

                //UAClient uaClient = new UAClient(application.ApplicationConfiguration);
                application.ApplicationConfiguration.CertificateValidator.CertificateValidation += CertificateValidation;

                // Check if a connection could be made.
                blnConnectionStatus = CheckConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception: " + ex.Message, "OPC connection issue: E200", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void CertificateValidation(CertificateValidator sender, CertificateValidationEventArgs e)
        {
            bool certificateAccepted = true;

            // ****
            // Implement a custom logic to decide if the certificate should be
            // accepted or not and set certificateAccepted flag accordingly.
            // The certificate can be retrieved from the e.Certificate field
            // ***

            ServiceResult error = e.Error;
            while (error != null)
            {
                Console.WriteLine(error);
                error = error.InnerResult;
            }

            if (certificateAccepted)
            {
                Console.WriteLine("Untrusted Certificate accepted. SubjectName = {0}", e.Certificate.SubjectName);
            }

            e.AcceptAll = certificateAccepted;
        }

        /// <summary>
        /// Example function
        /// </summary>
        /// <param name="application"></param>
        /// <param name="endpoint"></param>
        private void makeSession()
        {
            //start session to the OPC server
            using (var session = Session.Create(application.ApplicationConfiguration, endpoint, false, false, application.ApplicationName, 30 * 60 * 1000, new UserIdentity(), null).GetAwaiter().GetResult())
            {
                Console.WriteLine("Connected.");


                bool data = (bool)session.ReadValue(@"ns=3;s=""db_OPCdata"".""lijn1"".""PackML_Bakken"".""I_b_Cmd_Start""").Value;

                // ns=3;s="Clock_2.5Hz"
                bool data2 = (bool)session.ReadValue(@"ns=3;s=""Clock_2.5Hz""").Value;
                
                Console.WriteLine("OPCZOOI: {0}", data2);
                //float cableLength = (float)session.ReadValue("ns=6;s=::Blob:Cables.CableLength").Value;
                //float pixeltomm = (float)session.ReadValue("ns=6;s=::Blob:Cables.PixelToMM").Value;
                //long orderNumber = Convert.ToInt64((double)session.ReadValue("ns=6;s=::Blob:Cables.OrderNumber").Value);
                //long purchaseNumber = Convert.ToInt64((double)session.ReadValue("ns=6;s=::Blob:Cables.PurchaseNumber").Value);
                //long roleNumber = Convert.ToInt64((double)session.ReadValue("ns=6;s=::Blob:Cables.RoleNumber").Value);
                //string generalMark = (string)session.ReadValue("ns=6;s=::Blob:Cables.GeneralMark").Value;


                //Write to node
                IList<NodeId> nodeIds = new List<NodeId>();
                nodeIds.Add(new NodeId(@"ns=3;s=""db_OPCdata"".""lijn1"".""PackML_Verpakken"".""I_b_Cmd_Start"""));
                nodeIds.Add(new NodeId(@"ns=3;s=""db_OPCdata"".""lijn1"".""PackML_Bakken"".""I_b_Cmd_Start"""));

                object[] values = { true, false };

                WriteValueCollection nodesToWrite = new WriteValueCollection();

                for (int i = 0; i < nodeIds.Count; i++)
                {
                    WriteValue bWriteValue = new WriteValue();
                    bWriteValue.NodeId = nodeIds[i];
                    bWriteValue.AttributeId = Attributes.Value;
                    bWriteValue.Value = new DataValue();
                    bWriteValue.Value.Value = values[i];
                    nodesToWrite.Add(bWriteValue);
                }


                // Write the node attributes
                StatusCodeCollection results = null;
                DiagnosticInfoCollection diagnosticInfos;

                // Call Write Service
                session.Write(null,
                                nodesToWrite,
                                out results,
                                out diagnosticInfos);

                foreach (StatusCode writeResult in results)
                {
                    Console.WriteLine("     {0}", writeResult);
                }

            }
        }

        public bool CheckConnection()
        {
            try
            {
                using (var session = Session.Create(application.ApplicationConfiguration, endpoint, false, false, application.ApplicationName, 30 * 60 * 1000, new UserIdentity(), null).GetAwaiter().GetResult())
                {                    
                    bool blnAlwaysTrue = (bool)session.ReadValue(@"ns=3;s=""AlwaysTRUE""").Value;                    
                    return true;
                }
            } catch ( Exception ex )
            {
                MessageBox.Show("Exception: " + ex.Message, "OPC connection issue: CheckConnection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="application"></param>
        /// <param name="endpoint"></param>
        public List<string> GetRealtimeData()
        {
            List<string> lstRetVal = new List<string> { };
            try
            {
                //start session to the OPC server
                using (var session = Session.Create(application.ApplicationConfiguration, endpoint, false, false, application.ApplicationName, 30 * 60 * 1000, new UserIdentity(), null).GetAwaiter().GetResult())
                {
                    //Read nodes
                    IList<Type> types = new List<Type>();
                    IList<NodeId> nodeIdsRead = new List<NodeId>();
                    List<object> readValues;
                    List<ServiceResult> readResult;

                    types.Add(typeof(Int16));
                    types.Add(typeof(Int16));
                    types.Add(typeof(Int16));
                    types.Add(typeof(Int16));
                    types.Add(typeof(Int16));
                    types.Add(typeof(Int16));

                    nodeIdsRead.Add(new NodeId(@"ns=3;s=""db_OPCdata"".""lijn1"".""PackMl_Deegverwerking"".""O_i_State"""));
                    nodeIdsRead.Add(new NodeId(@"ns=3;s=""db_OPCdata"".""lijn1"".""PackML_Bakken"".""O_i_State"""));
                    nodeIdsRead.Add(new NodeId(@"ns=3;s=""db_OPCdata"".""lijn1"".""PackML_Verpakken"".""O_i_State"""));

                    nodeIdsRead.Add(new NodeId(@"ns=3;s=""db_OPCdata"".""lijn2"".""PackMl_Deegverwerking"".""O_i_State"""));
                    nodeIdsRead.Add(new NodeId(@"ns=3;s=""db_OPCdata"".""lijn2"".""PackML_Bakken"".""O_i_State"""));
                    nodeIdsRead.Add(new NodeId(@"ns=3;s=""db_OPCdata"".""lijn2"".""PackML_Verpakken"".""O_i_State"""));

                    session.ReadValues(nodeIdsRead, types, out readValues, out readResult);

                    foreach (var value in readValues)
                    {
                        short sValue = (short)value;
                        lstRetVal.Add(GetPackMLSate(sValue));
                    }
                    return lstRetVal;
                }
            } catch (Exception ex)
            {
                MessageBox.Show("Exception: " + ex.Message, "OPC connection issue: CheckConnection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return lstRetVal;
            }
        }

        private string GetPackMLSate(short IintState)
        {
            switch (IintState)
            {
                case 0:
                    return "Resetting";
                case 10:
                    return "Idle";
                case 20:
                    return "Starting";
                case 30:
                    return "Execute";
                case 40:
                    return "Completing";
                case 50:
                    return "Complete";
                case 60:
                    return "Holding";
                case 70:
                    return "Hold";
                case 80:
                    return "Unhold";
                case 90:
                    return "Stopping";
                case 100:
                    return "Stopped";
                default:
                    return "Unknown status";
            }
        }
    }
}