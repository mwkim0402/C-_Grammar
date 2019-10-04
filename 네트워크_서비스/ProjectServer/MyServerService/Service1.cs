using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using MyServerLibrary;


namespace MyServerService
{
    public partial class Service1 : ServiceBase
    {
        MyServer server;
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            server = new MyServer();
            server.ServerStart();
        }

        protected override void OnStop()
        {
            server.ServerStop();
        }
    }
}
