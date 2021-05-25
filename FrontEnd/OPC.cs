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
        /// <summary>
        /// 
        /// </summary>
        public OPC()
		{
            try
            {
                Console.WriteLine("Trying to connect to OPC...");

                // Define the UA Client application
                ApplicationInstance application = new ApplicationInstance();
                application.ApplicationName = "FrontEnd";
                application.ApplicationType = ApplicationType.Client;

                // load the application configuration.
                application.LoadApplicationConfiguration("FrontEnd.Config.xml", silent: false);              

                // check the application certificate.
                application.CheckApplicationInstanceCertificate(silent: false, minimumKeySize: 0);

                EndpointConfiguration endpointConfiguration = EndpointConfiguration.Create(application.ApplicationConfiguration);

                //var endpointDescription = CoreClientUtils.SelectEndpoint("opc.tcp://192.168.8.145:4840", false);
                var endpointDescription = CoreClientUtils.SelectEndpoint("opc.tcp://192.168.2.112:4840", false);

                ConfiguredEndpoint endpoint = new ConfiguredEndpoint(null, endpointDescription, endpointConfiguration);

                //UAClient uaClient = new UAClient(application.ApplicationConfiguration);
                application.ApplicationConfiguration.CertificateValidator.CertificateValidation += CertificateValidation;

                makeSession(application, endpoint);
            } catch ( Exception ex )
            {
                MessageBox.Show("OPC Error: " + ex.Message, "OPC connection issue", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="application"></param>
        /// <param name="endpoint"></param>
        private static void makeSession(ApplicationInstance application, ConfiguredEndpoint endpoint)
        {
            //start session to the OPC server
            using (var session = Session.Create(application.ApplicationConfiguration, endpoint, false, false, application.ApplicationName, 30 * 60 * 1000, new UserIdentity(), null).GetAwaiter().GetResult())
            {
                Console.WriteLine("Connected.");


                bool data = (bool)session.ReadValue(@"ns=3;s=""db_OPCdata"".""lijn1"".""PackML_Bakken"".""I_b_Cmd_Start""").Value;
                Console.WriteLine("OPCZOOI: {0}", data);
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
    }
}