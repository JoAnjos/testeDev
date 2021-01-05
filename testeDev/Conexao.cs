using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace testeDev
{
    public class Conexao
    {
        public string conec = "SERVER=localhost; DATABASE=testeDev; UID=root; PWD=usuario; PORT=3306;";
        public MysqlConnection con = null;
    }
}