using Newtonsoft.Json;
using NLog;
using NTST.ScriptLinkService.Objects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;


namespace ScriptLinkStub
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]

    

    public class R69CheckScriptLink : System.Web.Services.WebService
    {

        private static Logger log = LogManager.GetCurrentClassLogger();
        
        [WebMethod]
        public string GetVersion()
        {
            log.Debug("SDJL GetVersion Debug 1.0");
            return "1.0";
        }


        class R69CheckConfig
        {
            public HashSet<string> R69Allowed = new HashSet<string>();
            public HashSet<string> R69NotAllowed = new HashSet<string>();

            private static R69CheckConfig instance = null;


            public HashSet<string> GetR69Allowed()
            {
                return R69Allowed;
            }

            public void SetR69Allowed(HashSet<string> set)
            {
                R69Allowed = set;
            }

            public HashSet<string> GetR69NotAllowed()
            {
                return R69NotAllowed;
            }

            public void SetR69NotAllowed(HashSet<string> set)
            {
                R69NotAllowed = set;
            }

            private static void init()
            {
                using (FileStream fs = File.OpenRead("C:\\inetpub\\wwwroot\\R69Check\\R69Check.json"))
                {
                    using (StreamReader configStreamReader = new StreamReader(fs))
                    {
                        string configStr = configStreamReader.ReadToEnd();
                        log.Debug("SDJL: configStr = '" + configStr + "'");
                        instance = JsonConvert.DeserializeObject<R69CheckConfig>(configStr);
                        log.Debug("SDJL AfterConfigRead");
                        log.Debug("Config R69Allowed = '" + instance.GetR69Allowed().ToString());
                        log.Debug("Config R69NotAllowed = '" + instance.GetR69NotAllowed().ToString());
                        log.Debug("Config R69Allowed.Count = " + instance.GetR69Allowed().Count());
                        log.Debug("Config R69NotAllowed.Count = " + instance.GetR69NotAllowed().Count());
                    }
                }
            }

            public static R69CheckConfig getInstance()
            {
                if (instance == null)
                {
                    init();
                }
                return instance;
            }



        }


        [WebMethod]
        public OptionObject2015 RunScript(OptionObject2015 inputObject, String scriptParameter)
        {
            OptionObject2015 returnObject = new OptionObject2015();
            //Add your script call(s) here
            return returnObject;
        }
    }
}
