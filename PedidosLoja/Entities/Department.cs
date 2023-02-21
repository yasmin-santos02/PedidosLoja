namespace PedidosLoja.Entities
{
    internal class Department
    {
        public string Name { get; set; }
      
        //construtores
        public Department()
        {

        }

        public Department(string name)
        {
            Name = name;
        }
    }
}
