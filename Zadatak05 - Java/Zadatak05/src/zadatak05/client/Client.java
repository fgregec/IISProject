package zadatak05.client;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.net.MalformedURLException;
import java.net.URL;
import java.util.logging.Level;
import java.util.logging.Logger;
import org.apache.xmlrpc.XmlRpcException;
import org.apache.xmlrpc.client.XmlRpcClient;
import org.apache.xmlrpc.client.XmlRpcClientConfigImpl;



public class Client {

    public static void main(String[] args) {   
        try {
            //Connecting RPC jar service and server
            XmlRpcClientConfigImpl config = new XmlRpcClientConfigImpl();
            config.setServerURL(new URL("http://localhost:8088"));
            config.setEnabledForExceptions(true);
            config.setContentLengthOptional(false);
            config.setEnabledForExtensions(true);

            XmlRpcClient client = new XmlRpcClient();
            client.setConfig(config);

            BufferedReader reader = new BufferedReader(
                    new InputStreamReader(System.in));
            String finished;
            do {
                String city = "Zadar";
                Object[] parameters = new Object[]{city};
                System.out.println(client.execute("WeatherTools.get", parameters));

                System.out.println("\nDo you wish to continue? \nY : N");
                finished = reader.readLine();
            } while ("Y".equals(finished));

        } catch (MalformedURLException | XmlRpcException ex) {
            Logger.getLogger(Client.class.getName()).log(Level.SEVERE, null, ex);
        } catch (IOException ex) {
            Logger.getLogger(Client.class.getName()).log(Level.SEVERE, null, ex);
        }
    }
    }
    

