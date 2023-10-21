namespace MiapiEpe2.Modelo
{
    public class Empresas
    {
        public string? NombreCliente { get; set; }
        public string? ApePaterno { get; set; }
        public string? ApeMaterno { get; set; }
        public int? EdadCliente { get; set; }
        public string? RutCliente { get; set; }
        public string? NombreEmpresa { get; set; }
        public string? RutEmpresa { get; set; }
        public string? GiroEmpresa { get; set; }
        public float TotalVentas { get; set; }
        public float MontoVentas { get; set; }
        public float? MontoIVAaPagar { get; set; }
        public float MontoUtilidades { get; set; }

        internal static object FirstOrDefault(Func<object, bool> value)
        {
            throw new NotImplementedException();
        }

        internal object Find(Func<object, bool> value)
        {
            throw new NotImplementedException();
        }
    }
}

