namespace BoletoBus.Web.Models
{
    public class Class
    {

        public class Rootobject
        {
            public bool success { get; set; }
            public object message { get; set; }
            public Datum[] data { get; set; }
        }

        public class Datum
        {
            public int id { get; set; }
            public string nombre { get; set; }
            public string cargo { get; set; }
        }

    }
}
