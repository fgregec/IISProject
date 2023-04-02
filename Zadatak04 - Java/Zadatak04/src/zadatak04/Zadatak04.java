package zadatak04;

import java.io.File;
import java.io.IOException;
import javax.xml.XMLConstants;
import javax.xml.transform.Source;
import javax.xml.transform.stream.StreamSource;
import javax.xml.validation.Schema;
import javax.xml.validation.SchemaFactory;
import javax.xml.validation.Validator;
import org.xml.sax.SAXException;


public class Zadatak04 {


    public static void main(String[] args) throws SAXException {
            File xmlFile = new File("C:\\TastyGeneratedXPATH.xml");
            Source xmlSource = new StreamSource(xmlFile);
            
            File xsdFile = new File("src/Data/Tasty.xsd");
            Source xsdSource = new StreamSource(xsdFile);
            
            SchemaFactory schemaFactory = SchemaFactory.newInstance(XMLConstants.W3C_XML_SCHEMA_NS_URI);
            Schema schema = schemaFactory.newSchema(xsdSource);
            
            Validator validator = schema.newValidator();
            
            try {
                validator.validate(xmlSource);
                System.out.println("XML file is valid!");
            } catch (SAXException | IOException ex) {
                System.out.println("Xml file is NOT valid!");
            }
    }
    
}
