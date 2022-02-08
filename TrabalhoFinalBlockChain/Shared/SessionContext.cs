using System;
using System.Collections.Generic;
using System.Text;

namespace TrabalhoFinalBlockChain.Shared
{
    public sealed class SessionContext
    {
        private static volatile SessionContext instance;
        private static object sync = new ();

        private SessionContext() { }

        public static SessionContext Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (sync)
                    {
                        if (instance == null)
                        {
                            instance = new SessionContext();
                        }
                    }
                }
                return instance;
            }
        }

        public int? IdUsuario { get; set; }

    }
}
