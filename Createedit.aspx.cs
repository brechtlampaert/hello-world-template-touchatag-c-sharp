using System;
using System.Collections;
using System.Net;
using localhost;
using System.Text;


    public partial class Createedit : System.Web.UI.Page
    {
        private const string APPLICATION_URL = "http://localhost:51207/HelloWorld/HelloWorld.aspx?name=";

        protected void Page_Load(object sender, EventArgs e)
        {
            String applicationRequestId = Request.QueryString["applicationRequestId"];

            if (applicationRequestId == null)
                throw new Exception("No 'applicationRequestId' request parameter found");

            ApplicationManagement a;
            
            try
            {   
                a = new ApplicationManagement();
                a.PreAuthenticate = true;
                a.Credentials = new NetworkCredential("tikiteam", "tikiteam");
                
                                                               
            }
            catch (Exception exc)
            {
                throw exc;
            }

            byte[] value = null;

            value = a.getApplicationConfig(applicationRequestId);

            String name = "";
            if (value != null)
            {
                //this must be an UPDATE
                System.Text.ASCIIEncoding enc = new System.Text.ASCIIEncoding();
                name = enc.GetString(value);
                if (!IsPostBack)
                {
                    NameTextBox.Text = name;
                }
             }
   

        }


        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            String applicationRequestId = Request.QueryString["applicationRequestId"];

            if (applicationRequestId == null)
                throw new Exception("No 'applicationRequestId' request parameter found");

            string name = NameTextBox.Text;

            if (name == null)
            {
                throw new Exception("No 'name' parameter found");
            }

            string urlString = APPLICATION_URL + System.Web.HttpUtility.UrlEncode(name, Encoding.UTF8);

            parameter param = new parameter();
            param.name = "URI";
            param.ItemElementName = ItemChoiceType1.URI;
            param.Item = (string) urlString;
            
            superblock weblinkBlock = new superblock();
            weblinkBlock.@ref = "urn:touchatag:block:web-link-app";
            weblinkBlock.id = "urn:touchatag:block:*";

            //First create a new Array and then assign the 
            //array to the correct property
            parameter[] pams = new parameter[1];
            pams[0] = param;
            weblinkBlock.parameter = pams;
           

            command cmd = new command();
            cmd.id = "default";

            Specification spec = new Specification();

            //First create a new Array and then assign the 
            //array to the correct property
            command[] commands = new command[1];
            commands[0] = cmd;
            spec.application = commands ;

            //First create a new Array and then assign the 
            //array to the correct property
            superblock[] supers = new superblock[1];
            supers[0] = weblinkBlock;
            spec.blueprint = supers;

            HandleRequest handleReq = new HandleRequest();
            handleReq.specification = spec;
            handleReq.applicationConfig = new System.Text.ASCIIEncoding().GetBytes(name);
            handleReq.tikitTransactionId = applicationRequestId;

            ApplicationManagement a;
            
            try
            {
                a.PreAuthenticate = true;
                a = new ApplicationManagement();
                a.Credentials = new NetworkCredential("tikiteam", "tikiteam");
            }
            catch (Exception exc)
            {
                throw exc;
            }
            
           a.updateTransaction(handleReq);

           Response.Redirect("thankyou.aspx");

        }

      
      

    }