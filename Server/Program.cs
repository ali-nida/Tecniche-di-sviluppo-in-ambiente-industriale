using System;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace Server 
{
    class Program
    {
        static void Main(string[] args)
        {
            // Step 1: Create a URI to serve as the base address.
            Uri baseAddress = new Uri("http://localhost:59302");

            // Step 2: Create a ServiceHost instance.
            ServiceHost selfHost = new ServiceHost(typeof(ECommerce), baseAddress);

            try
            {
                // Step 3: Add a service endpoint.
                selfHost.AddServiceEndpoint(typeof(IECommerce), new WSHttpBinding(), "ECommerce");

                // Step 4: Enable metadata exchange.
                ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = true;
                selfHost.Description.Behaviors.Add(smb);

                // Step 5: Start the service.
                selfHost.Open();
                Console.WriteLine("The service is ready.");

                // Close the ServiceHost to stop the service.
                Console.WriteLine("Press any button to terminate the service.");
                Console.WriteLine();
                Console.ReadLine();
                selfHost.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                selfHost.Abort();
                Console.ReadLine();
            }
        }
    }
}